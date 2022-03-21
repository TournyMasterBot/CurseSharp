using System;
using static CurseSharp.CurseClient.Models.Enums;

namespace CuseSharp.Sockets
{
    public partial class WebSocketWrapper
    {
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
            public string Body;
        }

    }
}
