using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

namespace DSC.Core
{
    public static class Extension_Camera
    {
        #region Raycast

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition, ref narHit);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, float fDistance)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition, ref narHit, -5, -1, fDistance);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, LayerMask eLayerMask)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition, ref narHit, (int)eLayerMask);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, int nMaxHit)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition, ref narHit, -5, nMaxHit);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, float fDistance, LayerMask eLayerMask)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition
                , ref narHit, (int)eLayerMask, -1, fDistance);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, float fDistance, int nMaxHit)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition
                , ref narHit, -5, nMaxHit, fDistance);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, LayerMask eLayerMask, int nMaxHit)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition, ref narHit, (int)eLayerMask, nMaxHit);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , out RaycastHit hHit, float fDistance, LayerMask eLayerMask, int nMaxHit)
        {
            var narHit = new NativeArray<RaycastHit>(1, Allocator.TempJob);

            camera.MainRaycastScreenToWorld(vPosition
                , ref narHit, (int)eLayerMask, nMaxHit, fDistance);
            hHit = narHit[0];

            narHit.Dispose();

            return hHit.collider != null;
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, float fDistanace)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit, -5, -1, fDistanace);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, LayerMask eLayerMask)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit, (int)eLayerMask);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, int nMaxHit)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit, -5, nMaxHit);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, float fDistanace, LayerMask eLayerMask)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit
                , (int)eLayerMask, -1, fDistanace);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, float fDistanace, int nMaxHit)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit
                , -5, nMaxHit, fDistanace);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, LayerMask eLayerMask, int nMaxHit)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit
                , (int)eLayerMask, nMaxHit);
        }

        public static bool RaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit, float fDistanace, LayerMask eLayerMask, int nMaxHit)
        {
            return camera.MainRaycastScreenToWorld(vPosition, ref narHit
                , (int)eLayerMask, nMaxHit, fDistanace);
        }

        static bool MainRaycastScreenToWorld(this Camera camera, Vector3 vPosition
            , ref NativeArray<RaycastHit> narHit
           , int nLayerMask = -5, int nMaxHit = -1, float fDistance = (float)(3.40282347E+38))
        {
            var hRay = camera.ScreenPointToRay(vPosition);

            var narCommand = new NativeArray<RaycastCommand>(1, Allocator.TempJob);
            narCommand[0] = new RaycastCommand(hRay.origin, hRay.direction, fDistance, nLayerMask, nMaxHit);

            RaycastCommand.ScheduleBatch(narCommand, narHit, 1).Complete();

            narCommand.Dispose();

            return narHit[0].collider != null;
        }

        #endregion
    }
}
