using CurseSharp.CurseClient.Models;
using CurseSharp.CurseClient.Sessions;
using CurseSharp.CurseClient.WebSocketModels;
using CurseSharp.Logging;
using Newtonsoft.Json;
using System;
using WebSocket4Net;
using static CurseSharp.CurseClient.Models.Enums;

namespace CuseSharp.Sockets
{
    public partial class WebSocketWrapper : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        private WebSocket Socket;
        /// <summary>
        /// Used primarily in debugging, allows you to track the specific socket ID
        /// </summary>
        public string SocketID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Returns true if the socket state is open, otherwise false
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return Socket != null && Socket.State == WebSocketState.Open ? true : false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public WebSocketWrapper(string url)
        {
            SocketID = Guid.NewGuid().ToString();
            URL = url;
            Socket = new WebSocket(url);
            HookupEvents();
        }

        /// <summary>
        /// Hooks up events to automatically be redirected to the interface's events.
        /// </summary>
        private void HookupEvents()
        {
            Socket.MessageReceived += (sender, e) =>
            {
#if VERBOSE_LOGGING
                Log.Verbose($"< {e.Message}");
#endif
                MessageNotificationModel channelMessage = null;
                try
                {
                    channelMessage = JsonConvert.DeserializeObject<MessageNotificationModel>(e.Message);
                }
                catch(Exception)
                {
                    return;
                }

                var args = new SocketMessageReceivedEventArgs()
                {
                    SocketID = this.SocketID,
                    MessageType = NotificationType.ConversationMessageNotification,
                    Body = channelMessage.Body
                };

                // Specific event message notifications
                switch(channelMessage.TypeID)
                {
                    case NotificationType.ConversationMessageNotification:
                    {
                        // Raw socket message notification
                        if(MessageReceived != null)
                        {
                            MessageReceived?.Invoke(this, args);
                        }

                        break;
                    }
                    case NotificationType.FriendshipChangeNotification:
                    {
                        break;
                    }
                }

            };

            Socket.Error += (sender, e) =>
            {
                // Nobody is listening.
                if(SocketError == null)
                {
#if VERBOSE_LOGGING
                    Log.Verbose($"Socket Error Received, but nobody was listening. SocketID: {SocketID}, Message evaporated: {e.Exception}");
#endif
                    return;
                }

                var args = new SocketErrorEventArgs()
                {
                    SocketID = this.SocketID,
                    ErrorMessage = e.Exception
                };

                SocketError?.Invoke(this, args);
            };

            Socket.Closed += (sender, e) =>
            {
                // Nobody is listening.
                if(SocketClosed == null)
                {
#if VERBOSE_LOGGING
                    Log.Verbose($"Socket Closed Received, but nobody was listening. SocketID: {SocketID}");
#endif
                    return;
                }

                var args = new SocketClosedEventArgs()
                {
                    SocketID = this.SocketID
                };
                SessionState.ConnectionStatus = BotConnectionStatus.Disconnected;
                SocketClosed?.Invoke(this, args);
            };

            Socket.Opened += (sender, e) =>
            {
                // Nobody is listening.
                if(SocketOpened == null)
                {
#if VERBOSE_LOGGING
                    Log.Verbose($"Socket Opened Received, but nobody was listening. SocketID: {SocketID}");
#endif
                }
                var args = new SocketOpenedEventArgs()
                {
                    SocketID = SocketID
                };

                SessionState.ConnectionStatus = BotConnectionStatus.Connected;
                SocketOpened?.Invoke(this, args);
            };

            Socket.DataReceived += (sender, e) =>
            {
                if(SocketData == null)
                {
#if VERBOSE_LOGGING
                    Log.Verbose($"Socket Data Received, but nobody was listening. SocketID: {SocketID}, Data: {e.Data}");
#endif
                }

                var args = new SocketDataReceivedEventArgs()
                {
                    SocketID = this.SocketID,
                    Data = e.Data
                };
                SocketData?.Invoke(this, args);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public void Connect()
        {
            try
            {
                Socket.Open();
            }
            catch(Exception){ }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            try
            {
                Socket.Close();
            }
            catch(Exception) { }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Send(string data)
        {
            try
            {
#if VERBOSE_LOGGING
                Log.Verbose($"> {data}");
#endif

                Socket.Send(data);
            }
            catch(Exception) { }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if(IsAlive)
            {
                try
                {
                    Socket.Close();
                }
                catch(Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }

            if(Socket != null)
            {
                try
                {
                    Socket.Dispose();
                }
                catch(Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }
    }
}
