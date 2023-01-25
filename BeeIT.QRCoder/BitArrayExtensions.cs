using System;
using System.Collections;

namespace BeeIT.QRCoder
{
    /// <summary>
    /// Extension methods for the <see cref="BitArray"/> class.
    /// </summary>
    public static class BitArrayExtensions
    {

        /// <summary>
        /// Appends the specified number bits of the specified value to this bit array.
        /// <para>
        /// The least significant bits of the specified value are added. They are appended in reverse order,
        /// from the most significant to the least significant one, i.e. bits 0 to <i>len-1</i>
        /// are appended in the order <i>len-1</i>, <i>len-2</i> ... 1, 0.
        /// </para>
        /// <para>
        /// Requires 0 &#x2264; len &#x2264; 31, and 0 &#x2264; val &lt; 2<sup>len</sup>.
        /// </para>
        /// </summary>
        /// <param name="bitArray">The BitArray instance that this method extends.</param>
        /// <param name="val">The value to append.</param>
        /// <param name="len">The number of low-order bits in the value to append.</param>
        /// <exception cref="ArgumentOutOfRangeException">Value or number of bits is out of range.</exception>
        public static void AppendBits(this BitArray bitArray, uint val, int len)
        {
            if (len < 0 || len > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(len), "'len' out of range");
            }

            if (val >> len != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(val), "'val' out of range");
            }

            var bitLength = bitArray.Length;
            bitArray.Length = bitLength + len;
            var mask = 1U << (len - 1);
            for (var i = bitLength; i < bitLength + len; i++) // Append bit by bit
            {
                if ((val & mask) != 0)
                {
                    bitArray.Set(i, true);
                }

                mask >>= 1;
            }
        }


        /// <summary>
        /// Appends the content of the specified bit array to the end of this array.
        /// </summary>
        /// <param name="bitArray">The BitArray instance that this method extends.</param>
        /// <param name="otherArray">The bit array to append</param>
        /// <exception cref="ArgumentNullException">If <c>bitArray</c> is <c>null</c>.</exception>
        public static void AppendData(this BitArray bitArray, BitArray otherArray)
        {
            Objects.RequireNonNull(otherArray);
            var bitLength = bitArray.Length;
            bitArray.Length = bitLength + otherArray.Length;
            for (var i = 0; i < otherArray.Length; i++, bitLength++)  // Append bit by bit
            {
                if (otherArray[i])
                {
                    bitArray.Set(bitLength, true);
                }
            }
        }

    }
}