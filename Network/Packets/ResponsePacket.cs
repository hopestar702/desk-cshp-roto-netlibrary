﻿namespace Network.Packets
{
    /// <summary>
    /// Represents a response to a <see cref="RequestPacket"/>.
    /// </summary>
    /// <remarks>
    /// For the packet to be handled correctly, the handled <see cref="RequestPacket"/> must be given in the constructor.
    /// </remarks>
    public class ResponsePacket : Packet
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePacket"/> class.
        /// </summary>
        /// <param name="packet">The <see cref="RequestPacket"/> that is being handled.</param>
        public ResponsePacket(RequestPacket packet)
        {
            ID = packet.ID;
        }

        #endregion Constructors
    }
}