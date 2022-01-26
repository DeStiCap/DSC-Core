using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DSC.Core
{
    public static class GizmosUtility
    {

        public static void DrawWireCapsule(Vector3 vPosition, Quaternion qRotation, float fRadius, float fHeight)
        {

#if UNITY_EDITOR

            var hOldColor = Handles.color;
            Handles.color = Gizmos.color;
            Matrix4x4 hAngleMatrix = Matrix4x4.TRS(vPosition, qRotation, Handles.matrix.lossyScale);
            using (new Handles.DrawingScope(hAngleMatrix))
            {
                var fPointOffset = (fHeight - (fRadius * 2)) / 2;

                //draw sideways
                Handles.DrawWireArc(Vector3.up * fPointOffset, Vector3.left, Vector3.back, -180, fRadius);
                Handles.DrawLine(new Vector3(0, fPointOffset, -fRadius), new Vector3(0, -fPointOffset, -fRadius));
                Handles.DrawLine(new Vector3(0, fPointOffset, fRadius), new Vector3(0, -fPointOffset, fRadius));
                Handles.DrawWireArc(Vector3.down * fPointOffset, Vector3.left, Vector3.back, 180, fRadius);
                //draw frontways
                Handles.DrawWireArc(Vector3.up * fPointOffset, Vector3.back, Vector3.left, 180, fRadius);
                Handles.DrawLine(new Vector3(-fRadius, fPointOffset, 0), new Vector3(-fRadius, -fPointOffset, 0));
                Handles.DrawLine(new Vector3(fRadius, fPointOffset, 0), new Vector3(fRadius, -fPointOffset, 0));
                Handles.DrawWireArc(Vector3.down * fPointOffset, Vector3.back, Vector3.left, -180, fRadius);
                //draw center
                Handles.DrawWireDisc(Vector3.up * fPointOffset, Vector3.up, fRadius);
                Handles.DrawWireDisc(Vector3.down * fPointOffset, Vector3.up, fRadius);

                Handles.color = hOldColor;
            }
#endif
        }

        public static void DrawWireCapsule(Vector3 vPoint1, Vector3 vPoint2, float fRadius)
        {
#if UNITY_EDITOR
            // Special case when both points are in the same position
            if (vPoint1 == vPoint2)
            {
                // DrawWireSphere works only in gizmo methods
                Gizmos.DrawWireSphere(vPoint1, fRadius);
                return;
            }
            using (new UnityEditor.Handles.DrawingScope(Gizmos.color, Gizmos.matrix))
            {
                Quaternion qP1Rotation = Quaternion.LookRotation(vPoint1 - vPoint2);
                Quaternion qP2Rotation = Quaternion.LookRotation(vPoint2 - vPoint1);
                // Check if capsule direction is collinear to Vector.up
                float fC = Vector3.Dot((vPoint1 - vPoint2).normalized, Vector3.up);
                if (fC == 1f || fC == -1f)
                {
                    // For fix rotation
                    qP2Rotation = Quaternion.Euler(qP2Rotation.eulerAngles.x, qP2Rotation.eulerAngles.y + 180f, qP2Rotation.eulerAngles.z);
                }
                // First side
                UnityEditor.Handles.DrawWireArc(vPoint1, qP1Rotation * Vector3.left, qP1Rotation * Vector3.down, 180f, fRadius);
                UnityEditor.Handles.DrawWireArc(vPoint1, qP1Rotation * Vector3.up, qP1Rotation * Vector3.left, 180f, fRadius);
                UnityEditor.Handles.DrawWireDisc(vPoint1, (vPoint2 - vPoint1).normalized, fRadius);
                // Second side
                UnityEditor.Handles.DrawWireArc(vPoint2, qP2Rotation * Vector3.left, qP2Rotation * Vector3.down, 180f, fRadius);
                UnityEditor.Handles.DrawWireArc(vPoint2, qP2Rotation * Vector3.up, qP2Rotation * Vector3.left, 180f, fRadius);
                UnityEditor.Handles.DrawWireDisc(vPoint2, (vPoint1 - vPoint2).normalized, fRadius);
                // Lines
                UnityEditor.Handles.DrawLine(vPoint1 + qP1Rotation * Vector3.down * fRadius, vPoint2 + qP2Rotation * Vector3.down * fRadius);
                UnityEditor.Handles.DrawLine(vPoint1 + qP1Rotation * Vector3.left * fRadius, vPoint2 + qP2Rotation * Vector3.right * fRadius);
                UnityEditor.Handles.DrawLine(vPoint1 + qP1Rotation * Vector3.up * fRadius, vPoint2 + qP2Rotation * Vector3.up * fRadius);
                UnityEditor.Handles.DrawLine(vPoint1 + qP1Rotation * Vector3.right * fRadius, vPoint2 + qP2Rotation * Vector3.left * fRadius);
            }
#endif
        }

    }
}
