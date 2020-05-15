using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public static class Extension_GameObject
    {
        /// <summary>
        /// Compare GameObject tag in array tag data.
        /// </summary>
        /// <param name="hGameObject">Check GameObject</param>
        /// <param name="arrCheckTag">Check Array Tag.</param>
        /// <returns>Return true if has GameObject tag in array data.</returns>
        public static bool CompareTag(this GameObject hGameObject,string[] arrCheckTag)
        {
            if (hGameObject == null || arrCheckTag == null || arrCheckTag.Length <= 0)
                return false;

            for(int i = 0; i < arrCheckTag.Length; i++)
            {
                var sTag = arrCheckTag[i];
                if (sTag != null && sTag != "" && hGameObject.CompareTag(sTag))
                    return true;
            }

            return false;
        }
    }
}