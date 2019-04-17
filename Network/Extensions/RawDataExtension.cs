﻿using Network.Converter;
using Network.Packets;

namespace Network.Extensions
{
    /// <summary>
    /// Provides additional functionality to the <see cref="RawData"/> class.
    /// </summary>
    /// <remarks>
    /// The methods in this class function as shortcuts to calling the relevant <see cref="RawDataConverter"/> method.
    /// </remarks>
    public static class RawDataExtension
    {
        #region Methods

        /// <inheritdoc cref="RawDataConverter.ToBoolean"/>
        public static bool ToBoolean(this RawData rawData)
        {
            return RawDataConverter.ToBoolean(rawData);
        }

        #region Unsigned Integer Conversion

        /// <inheritdoc cref="RawDataConverter.ToUInt8"/>
        public static byte ToUInt8(this RawData rawData)
        {
            return RawDataConverter.ToUInt8(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUInt16"/>
        public static ushort ToUInt16(this RawData rawData)
        {
            return RawDataConverter.ToUInt16(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUInt32"/>
        public static uint ToUInt32(this RawData rawData)
        {
            return RawDataConverter.ToUInt32(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUInt64"/>
        public static ulong ToUInt64(this RawData rawData)
        {
            return RawDataConverter.ToUInt64(rawData);
        }

        #endregion Unsigned Integer Conversion

        #region Signed Integer Conversion

        /// <inheritdoc cref="RawDataConverter.ToInt8"/>
        public static sbyte ToInt8(this RawData rawData)
        {
            return RawDataConverter.ToInt8(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToInt16"/>
        public static short ToInt16(this RawData rawData)
        {
            return RawDataConverter.ToInt16(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToInt32"/>
        public static int ToInt32(this RawData rawData)
        {
            return RawDataConverter.ToInt32(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToInt64"/>
        public static long ToInt64(this RawData rawData)
        {
            return RawDataConverter.ToInt64(rawData);
        }

        #endregion Signed Integer Conversion

        #region String Conversion

        #region Unicode Encoding

        /// <inheritdoc cref="RawDataConverter.ToUTF16_BigEndian_String"/>
        public static string ToUTF16_BigEndian_String(this RawData rawData)
        {
            return RawDataConverter.ToUTF16_BigEndian_String(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUTF16_LittleEndian_String"/>
        public static string ToUTF16_LittleEndian_String(this RawData rawData)
        {
            return RawDataConverter.ToUTF16_LittleEndian_String(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUnicodeString"/>
        public static string ToUnicodeString(this RawData rawData)
        {
            return RawDataConverter.ToUnicodeString(rawData);
        }

        #endregion Unicode Encoding

        #region UTFXXX Encoding

        /// <inheritdoc cref="RawDataConverter.ToUTF32String"/>
        public static string ToUTF32String(this RawData rawData)
        {
            return RawDataConverter.ToUTF32String(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUTF8String"/>
        public static string ToUTF8String(this RawData rawData)
        {
            return RawDataConverter.ToUTF8String(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToUTF7String"/>
        public static string ToUTF7String(this RawData rawData)
        {
            return RawDataConverter.ToUTF7String(rawData);
        }

        #endregion UTFXXX Encoding

        /// <inheritdoc cref="RawDataConverter.ToASCIIString"/>
        public static string ToASCIIString(this RawData rawData)
        {
            return RawDataConverter.ToASCIIString(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToChar"/>
        public static char ToChar(this RawData rawData)
        {
            return RawDataConverter.ToChar(rawData);
        }

        #endregion String Conversion

        #region Floating Point Conversion

        /// <inheritdoc cref="RawDataConverter.ToSingle"/>
        public static float ToSingle(this RawData rawData)
        {
            return RawDataConverter.ToSingle(rawData);
        }

        /// <inheritdoc cref="RawDataConverter.ToDouble"/>
        public static double ToDouble(this RawData rawData)
        {
            return RawDataConverter.ToDouble(rawData);
        }

        #endregion Floating Point Conversion

        #endregion Methods
    }
}