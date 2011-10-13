using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.CodeContracts;

namespace Infrastructure.Core.Helpers {
    /// <summary>
    /// Extensions for string.
    /// </summary>
    public static class StringHelper {
        /// <summary>
        /// Trim the string to a max length.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string source, int maxLength) {
            ParameterCheck.StringRequiredAndNotWhitespace(source, "source");
            ParameterCheck.IntParameterGreaterThanZero(maxLength, "maxLength");

            return (source != null && source.Length > maxLength) ? source.Substring(0, maxLength) : source;
        }
    }
}
