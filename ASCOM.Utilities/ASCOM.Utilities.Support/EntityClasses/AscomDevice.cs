﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ASCOM.Utilities.Support
{
    /// <summary>
    /// ASCOM device entity class
    /// </summary>
    public class AscomDevice
    {
        /// <summary>
        /// Default initialiser
        /// </summary>
        public AscomDevice() { }

        /// <summary>
        /// Initialise the ASCOM device name, ASCOM device type and ASCOM device unique ID, plus
        /// the Alpaca API device number, unique ID, device IP endpoint, Alpaca unique ID, interface version and status message
        /// </summary>
        /// <param name="ascomDdeviceName">ASCOM device name</param>
        /// <param name="ascomDeviceType">ASCOM device type</param>
        /// <param name="alpacaDeviceNumber">Alpaca API device number</param>
        /// <param name="uniqueId">ASCOM device unique ID</param>
        /// <param name="ipEndPoint">Alpaca device IP endpoint</param>
        /// <param name="hostName">ALapca device host name</param>
        /// <param name="alpacaUniqueId">Alpaca device unique ID</param>
        /// <param name="interfaceVersion">Supported Alpaca interface version</param>
        /// <param name="statusMessage">ALapca device status message</param>
        public AscomDevice(string ascomDdeviceName, string ascomDeviceType, int alpacaDeviceNumber, string uniqueId, IPEndPoint ipEndPoint, string hostName, int interfaceVersion, string statusMessage)
        {
            AscomDeviceName = ascomDdeviceName;
            AscomDeviceType = ascomDeviceType;
            AlpacaDeviceNumber = alpacaDeviceNumber;
            UniqueId = uniqueId;
            IPEndPoint = ipEndPoint;
            HostName = hostName;
            InterfaceVersion = interfaceVersion;
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// ASCOM device name
        /// </summary>
        public string AscomDeviceName { get; set; }

        /// <summary>
        /// ASCOM device type
        /// </summary>
        public string AscomDeviceType { get; set; }

        /// <summary>
        /// Alpaca API device number
        /// </summary>
        public int AlpacaDeviceNumber { get; set; }

        /// <summary>
        /// ASCOM device unique ID
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// Alpaca device IP endpoint
        /// </summary>
        public IPEndPoint IPEndPoint { get; set; }

        /// <summary>
        /// Alpaca device host name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// SUpported Alpaca interface version
        /// </summary>
        public int InterfaceVersion { get; set; }

        /// <summary>
        /// Alpaca device status message
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
