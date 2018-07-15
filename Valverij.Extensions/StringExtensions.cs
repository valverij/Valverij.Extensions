using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Valverij.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks to see if a given string exists in a given set of strings. Case sensitive.
        /// </summary>
        public static bool In(this string value, params string[] args) => In(value, args?.AsEnumerable());

        /// <summary>
        /// Checks to see if a given string exists in a given set of strings.
        /// </summary>
        /// <param name="comparisonType">Use OrdinalIgnoreCase for case-insensitive comparison</param>
        public static bool In(this string value, StringComparison comparisonType, params string[] args) => In(value, comparisonType, args?.AsEnumerable());

        /// <summary>
        /// Checks to see if a given string exists in a given set of strings. Case sensitive.
        /// </summary>
        public static bool In(this string value, IEnumerable<string> args) => In(value, StringComparison.Ordinal, args);

        /// <summary>
        /// Checks to see if a given string exists in a given set of strings.
        /// </summary>
        /// <param name="comparisonType">Use OrdinalIgnoreCase for case-insensitive comparison</param>
        public static bool In(this string value, StringComparison comparisonType, IEnumerable<string> args) => args != null ? args.Any(x => x.Equals(value, comparisonType)) : false;

        /// <summary>
        /// If a string is null or empty, returns a specified default value. Otherwise, returns the original string.
        /// Shorthand for string.IsNullOrEmpty(value)) ? value : "default value"
        /// </summary>
        /// <param name="defaultValue">Default value to use if the string is null or empty</param>
        /// <returns>If a string is null or empty, then the specified default value. Otherwise, returns the original string</returns>
        /// <exception cref="ArgumentNullException">defaultValue</exception>
        public static string DefaultIfEmpty(this string value, string defaultValue) => string.IsNullOrEmpty(value)
            ? defaultValue ?? throw new ArgumentNullException(nameof(defaultValue))
            : value;

        /// <summary>
        /// Replace matching string in given string based on a regular expression. Requires a pattern and replacement.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RegexReplace(this string input, string pattern, string replacement, RegexOptions options = RegexOptions.None)
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            if (replacement == null)
                throw new ArgumentNullException(nameof(replacement));

            if (input == null) return null;

            return Regex.Replace(input, pattern, replacement, options);
        }

        /// <summary>
        /// Converts a given string to its bytes
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] ToBytes(this string input) => Encoding.UTF8.GetBytes(input ?? throw new ArgumentNullException(nameof(input)));

        /// <summary>
        /// Converts a given string to its base 64 equivalent
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToBase64(this string input) => Convert.ToBase64String(input.ToBytes());

        /// <summary>
        /// Converts a given byte array to its string equivalent
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string FromBytes(this byte[] input) => Encoding.UTF8.GetString(input ?? throw new ArgumentNullException(nameof(input)));

        /// <summary>
        /// Converts a given base 64 string to decoded equivalent
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string FromBase64(this string input) => Convert.FromBase64String(input ?? throw new ArgumentNullException(nameof(input))).FromBytes();
    }
}
