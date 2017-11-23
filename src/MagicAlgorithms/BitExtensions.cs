using System;
using System.Reflection;

namespace Vurdalakov
{
    public static class BitExtensions
    {
        // IsOnlyOneBitSet ------------------------------------------------------------------------

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
    }
}
