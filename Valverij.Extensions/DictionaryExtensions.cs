using System.Collections.Generic;

namespace Valverij.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Updates an item in the given dictionary if the key exists, or adds a new one if it does not.
        /// </summary>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}
