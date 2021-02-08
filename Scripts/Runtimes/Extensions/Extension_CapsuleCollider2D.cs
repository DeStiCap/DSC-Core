using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public static class Extension_CapsuleCollider2D
    {
        public static Vector2 GetPositionTop(this CapsuleCollider2D hCol)
        {
            Vector2 vResult = (Vector2)hCol.transform.position + hCol.offset;

            vResult.y += hCol.size.y;

            return vResult;
        }

        public static Vector2 GetPositionBottom(this CapsuleCollider2D hCol)
        {
            Vector2 vResult = (Vector2)hCol.transform.position + hCol.offset;

            vResult.y -= hCol.size.y;

            return vResult;
        }

    }
}
