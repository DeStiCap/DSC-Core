using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public static class MathUtility
    {
        public static Vector2 Abs(Vector2 vValue)
        {
            vValue.x = Mathf.Abs(vValue.x);
            vValue.y = Mathf.Abs(vValue.y);
            return vValue;
        }

        public static Vector3 Abs(Vector3 vValue)
        {
            vValue.x = Mathf.Abs(vValue.x);
            vValue.y = Mathf.Abs(vValue.y);
            vValue.z = Mathf.Abs(vValue.z);
            return vValue;
        }

        public static Vector2 ToOne(Vector2 vValue)
        {
            if (vValue.x != 0)
                vValue.x = vValue.x > 0 ? 1 : -1;

            if (vValue.y != 0)
                vValue.y = vValue.y > 0 ? 1 : -1;
                
            return vValue;
        }

        public static Vector3 ToOne(Vector3 vValue)
        {
            if (vValue.x != 0)
                vValue.x = vValue.x > 0 ? 1 : -1;

            if (vValue.y != 0)
                vValue.y = vValue.y > 0 ? 1 : -1;

            if (vValue.z != 0)
                vValue.z = vValue.z > 0 ? 1 : -1;

            return vValue;
        }
    }
}
