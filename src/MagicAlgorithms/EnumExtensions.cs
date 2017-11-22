using System;

namespace Vurdalakov
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Detects if only one bit is set in a [Flags] enumerable.
        /// </summary>
        /// <param name="enumValue">Enumerable value.</param>
        /// <returns><c>true</c> if only one bit is set; <c>false</c> otherwise.</returns>
        public static bool IsOnlyOneBitSet(this Enum enumValue)
        {
            var intValue = Convert.ToInt64(enumValue);
            return (intValue != 0) && (0 == (intValue & (intValue - 1)));
        }
    }
}
