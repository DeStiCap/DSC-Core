using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public static class Extension_Dictionary
    {
        /// <summary>
        /// Try add data to dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="hKey"></param>
        /// <param name="hData"></param>
        /// <typeparam name="Key"></typeparam>
        /// <typeparam name="Data"></typeparam>
        /// <returns></returns>
        public static bool TryAdd<Key, Data>(this Dictionary<Key, Data> dictionary, Key hKey, Data hData)
        {
            bool bResult = false;

            if (!dictionary.ContainsKey(hKey))
            {
                bResult = true;
                dictionary.Add(hKey, hData);
            }

            return bResult;
        }
    }
}
