using CurseSharp.CurseClient.WebSocketModels;
using CurseSharp.Logging;
using Newtonsoft.Json;
using System;
using WebSocket4Net;
using static CurseSharp.CurseClient.Models.Enums;

namespace CuseSharp.Sockets
{
    public class WebSocketWrapper : IDisposable
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
        public event EventHandler<SocketMessageReceivedEventArgs> MessageReceived;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<SocketClosedEventArgs> SocketClosed;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<SocketOpenedEventArgs> SocketOpened;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<SocketErrorEventArgs> SocketError;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<SocketDataReceivedEventArgs> SocketData;

        /// <summary>
        /// An internal GUID to uniquely identify the socket, mostly used for debugging.
        /// </summary>
        public class SocketOpenedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class SocketClosedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class SocketErrorEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public Exception ErrorMessage { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class SocketDataReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public byte[] Data { get; set; }
        }

        /// <summary>
        /// When a socket message is received, capture the message type body contents
        /// </summary>
        public class SocketMessageReceivedEventArgs : EventArgs
        {
            public string SocketID { get; set; }
            public NotificationType MessageType;
            public Body Body;
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
                // Nobody is listening.
                if(MessageReceived == null)
                {
#if VERBOSE_LOGGING
                    Log.Verbose($"Socket Message Received, but nobody was listening. SocketID: {SocketID}, Message evaporated: {e.Message}");
#endif
                    return;
                }

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
                    Log.Error($"Json Deserialization Broke while parsing message for SocketID {SocketID}: {Environment.NewLine}{e.Message}");
                    return;
                }

                SocketMessageReceivedEventArgs args;
                if(channelMessage != null && channelMessage.Body != null && channelMessage.Body.ServerID != null)
                {
                    args = new SocketMessageReceivedEventArgs()
                    {
                        SocketID = this.SocketID,
                        MessageType = NotificationType.ConversationMessageNotification,
                        Body = channelMessage.Body
                    };
                    MessageReceived?.Invoke(this, args);
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
