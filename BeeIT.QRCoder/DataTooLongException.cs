using System;
using System.Collections.Generic;

namespace BeeIT.QRCoder
{
    /// <summary>
    /// The exception that is thrown when the supplied data does not fit in the QR code.
    /// </summary>
    /// <remarks>
    /// Ways to handle this exception include:
    /// <ul>
    ///   <li>Decrease the error correction level (if it was greater than <see cref="QrCode.Ecc.Low"/>)</li>
    ///   <li>Increase the <c>maxVersion</c> argument (if it was less than <see cref="QrCode.MaxVersion"/>).
    ///       This advice applies to the advanced factory functions
    ///       <see cref="QrCode.EncodeSegments"/> and
    ///       <see cref="QrSegmentAdvanced.MakeSegmentsOptimally(string, QrCode.Ecc, int, int)"/> only.
    ///       Other factory functions automatically try all versions up to <see cref="QrCode.MaxVersion"/>.</li>
    ///   <li>Split the text into several segments and encode them using different encoding modes
    ///     (see <see cref="QrSegmentAdvanced.MakeSegmentsOptimally(string, QrCode.Ecc, int, int)"/>.)</li>
    ///   <li>Make the text or binary data shorter.</li>
    ///   <li>Change the text to fit the character set of a particular segment mode (e.g. alphanumeric).</li>
    ///   <li>Reject the data and notify the caller/user.</li>
    /// </ul>
    /// </remarks>
    /// <seealso cref="QrCode.EncodeText(string, QrCode.Ecc)"/>
    /// <seealso cref="QrCode.EncodeBinary(byte[], QrCode.Ecc)"/>
    /// <seealso cref="QrCode.EncodeSegments(List{QrSegment}, QrCode.Ecc, int, int, int, bool)"/>
    /// <seealso cref="QrCode.GenerateQrCode(string)"/>
    /// <seealso cref="QrCode.GenerateQrCode(string, string, int, int)"/>
    /// <seealso cref="QrCode.GenerateQrCodeWithImage(string, string, string, int, int)"/>
    /// <seealso cref="QrSegmentAdvanced.MakeSegmentsOptimally(string, QrCode.Ecc, int, int)"/>
    public class DataTooLongException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTooLongException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DataTooLongException(string message)
            : base(message)
        { }
    }
}