using System;

namespace Mov.Mobility.Service.Omron
{
    public class ArclEventArgs : EventArgs
    {
        /// <summary>
        /// The message.
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get { return _message; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="msg">The Arcl message.</param>
        public ArclEventArgs(string msg)
        {
            _message = msg;
        }
    }//end ArclEventArgs
}
