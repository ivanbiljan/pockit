using System;
using System.Collections.Generic;
using System.Text;

namespace Gitmax.Lib.Extensions
{
    public static class IDictionary
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, out TKey key, out TValue value) {
            key = keyValuePair.Key;
            value = keyValuePair.Value;
        }
    }
}
