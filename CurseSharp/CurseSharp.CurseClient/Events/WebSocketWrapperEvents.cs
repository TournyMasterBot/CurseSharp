using System;

namespace CuseSharp.Sockets
{
    public partial class WebSocketWrapper
    {        
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
        /// 
        /// </summary>
        public event EventHandler<SocketMessageReceivedEventArgs> MessageReceived;
    }
}
