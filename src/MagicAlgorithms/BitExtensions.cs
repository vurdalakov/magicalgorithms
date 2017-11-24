using System;
using System.Reflection;

namespace Vurdalakov
{
    public static class BitExtensions
    {
        // IsOnlyOneBitSet --------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Detects if only one bit is set in an Int32 integer.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static Boolean IsOnlyOneBitSet(this Int32 value)
        {
            return (value != 0) && (0 == (value & (value - 1)));
        }

        /// <summary>
        /// Detects if only one bit is set in an UInt32 integer.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static Boolean IsOnlyOneBitSet(this UInt32 value)
        {
            return (value != 0) && (0 == (value & (value - 1)));
        }

        /// <summary>
        /// Detects if only one bit is set in an Int64 integer.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static Boolean IsOnlyOneBitSet(this Int64 value)
        {
            return (value != 0) && (0 == (value & (value - 1)));
        }

        /// <summary>
        /// Detects if only one bit is set in an UInt64 integer.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static Boolean IsOnlyOneBitSet(this UInt64 value)
        {
            return (value != 0) && (0 == (value & (value - 1)));
        }

        /// <summary>
        /// Detects if only one bit is set in a [Flags] enumerable.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static Boolean IsOnlyOneBitSet(this Enum value)
        {
            var underlyingType = value.GetType().GetEnumUnderlyingType();

            // most common case; using dynamics is expensive
            if (underlyingType == typeof(int))
            {
                return Convert.ToInt32(value).IsOnlyOneBitSet();
            }

            var methods = typeof(BitExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var method in methods)
            {
                if (method.Name.Equals("IsOnlyOneBitSet") && (method.GetParameters()[0].ParameterType == underlyingType))
                {
                    dynamic dynValue = Convert.ChangeType(value, underlyingType);
                    return (Boolean)method.Invoke(null, new object[] { dynValue });
                }
            }

            throw new ArgumentException($"Enumeration underlying type is not supported ({underlyingType.FullName})");
        }

        // GetMostSignificantBitSet -----------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the most significant 1 bit of the given Int32 value.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns>The most significant 1 bit (highest numbered element of a bit set).</returns>
        public static UInt32 GetMostSignificantBitSet(this Int32 value)
        {
            return GetMostSignificantBitSet(unchecked((UInt32)value));
        }

        /// <summary>
        /// Returns the most significant 1 bit of the given UInt32 value.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns>The most significant 1 bit (highest numbered element of a bit set).</returns>
        public static UInt32 GetMostSignificantBitSet(this UInt32 value)
        {
            value |= (value >> 1);
            value |= (value >> 2);
            value |= (value >> 4);
            value |= (value >> 8);
            value |= (value >> 16);
            return (value & ~(value >> 1));
        }

        /// <summary>
        /// Returns the most significant 1 bit of the given Int64 value.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns>The most significant 1 bit (highest numbered element of a bit set).</returns>
        public static UInt64 GetMostSignificantBitSet(this Int64 value)
        {
            return GetMostSignificantBitSet(unchecked((UInt64)value));
        }

        /// <summary>
        /// Returns the most significant 1 bit of the given UInt64 value.
        /// </summary>
        /// <param name="value">Value to test.</param>
        /// <returns>The most significant 1 bit (highest numbered element of a bit set).</returns>
        public static UInt64 GetMostSignificantBitSet(this UInt64 value)
        {
            value |= (value >> 1);
            value |= (value >> 2);
            value |= (value >> 4);
            value |= (value >> 8);
            value |= (value >> 16);
            value |= (value >> 32);
            return (value & ~(value >> 1));
        }
    }
}
