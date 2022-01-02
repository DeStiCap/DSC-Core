using UnityEngine;

namespace DSC.Core
{
    public static class Extension_Component
    {
        /// <summary>
        /// Compare GameObject tag in array tag data.
        /// </summary>
        /// <param name="hComponent">Check GameObject</param>
        /// <param name="arrCheckTag">Check Array Tag.</param>
        /// <returns>Return true if has GameObject tag in array data.</returns>
        public static bool CompareTag(this Component hComponent,string[] arrCheckTag)
        {
            if (hComponent == null || arrCheckTag == null || arrCheckTag.Length <= 0)
                return false;

            for(int i = 0; i < arrCheckTag.Length; i++)
            {
                var sTag = arrCheckTag[i];
                if (sTag != null && sTag != "" && hComponent.CompareTag(sTag))
                    return true;
            }

            return false;
        }
    }
}
