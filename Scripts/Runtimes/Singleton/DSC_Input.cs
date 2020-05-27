using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public abstract class DSC_Input : MonoBehaviour
    {
        #region Variable

        #region Variable - Property

        protected abstract GameInputData gameInputData { get; set; }

        #endregion

        protected static DSC_Input m_hBaseInstance;

        #endregion

        #region Base - Main

        public static void InitInput(int nPlayerNumber)
        {
            if (!HasBaseInstance())
                return;

            if (!m_hBaseInstance.gameInputData.isCreate)
                m_hBaseInstance.gameInputData = new GameInputData(nPlayerNumber);
            else
                m_hBaseInstance.gameInputData.ChangePlayerNumber(nPlayerNumber);
        }

        public static Vector2 GetAnyRawAxis()
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAnyRawAxis();
        }

        public static Vector2 GetAnyRawAxis(int nAxisID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAnyRawAxis(nAxisID);
        }

        public static Vector2 GetRawAxis(int nPlayerID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetRawAxis(nPlayerID);
        }

        public static Vector2 GetRawAxis(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetRawAxis(nPlayerID, nAxisID);
        }

        public static void SetRawAxis(int nPlayerID, Vector2 vAxis)
        {
            if (!HasBaseInstance())
                return;

            m_hBaseInstance.gameInputData.SetRawAxis(nPlayerID, vAxis);
        }

        public static void SetRawAxis(int nPlayerID, int nAxisID, Vector2 vAxis)
        {
            if (!HasBaseInstance())
                return;

            m_hBaseInstance.gameInputData.SetRawAxis(nPlayerID, nAxisID, vAxis);
        }

        public static Vector2 GetAnyAxis()
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAnyAxis();
        }

        public static Vector2 GetAnyAxis(int nAxisID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAnyAxis(nAxisID);
        }

        public static Vector2 GetAxis(int nPlayerID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAxis(nPlayerID);
        }

        public static Vector2 GetAxis(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return Vector2.zero;

            return m_hBaseInstance.gameInputData.GetAxis(nPlayerID, nAxisID);
        }

        public static DirectionType2D GetAnyHorizontalPress()
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyHorizontalPress();
        }

        public static DirectionType2D GetAnyHorizontalPress(int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyHorizontalPress(nAxisID);
        }

        public static DirectionType2D GetHorizontalPress(int nPlayerID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetHorizontalPress(nPlayerID);
        }

        public static DirectionType2D GetHorizontalPress(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetHorizontalPress(nPlayerID, nAxisID);
        }

        public static DirectionType2D GetAnyVerticalPress()
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyVerticalPress();
        }

        public static DirectionType2D GetAnyVerticalPress(int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyVerticalPress(nAxisID);
        }

        public static DirectionType2D GetVerticalPress(int nPlayerID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetVerticalPress(nPlayerID);
        }

        public static DirectionType2D GetVerticalPress(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetVerticalPress(nPlayerID, nAxisID);
        }

        public static DirectionType2D GetAnyHorizontalDoublePress()
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyHorizontalDoublePress();
        }

        public static DirectionType2D GetAnyHorizontalDoublePress(int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyHorizontalDoublePress(nAxisID);
        }

        public static DirectionType2D GetHorizontalDoublePress(int nPlayerID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetHorizontalDoublePress(nPlayerID);
        }

        public static DirectionType2D GetHorizontalDoublePress(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetHorizontalDoublePress(nPlayerID, nAxisID);
        }

        public static DirectionType2D GetAnyVerticalDoublePress()
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyVerticalDoublePress();
        }

        public static DirectionType2D GetAnyVerticalDoublePress(int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetAnyVerticalDoublePress(nAxisID);
        }

        public static DirectionType2D GetVerticalDoublePress(int nPlayerID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetVerticalDoublePress(nPlayerID);
        }

        public static DirectionType2D GetVerticalDoublePress(int nPlayerID, int nAxisID)
        {
            if (!HasBaseInstance())
                return 0;

            return m_hBaseInstance.gameInputData.GetVerticalDoublePress(nPlayerID, nAxisID);
        }

        public static GetInputType GetButtonInput(int nButtonID)
        {
            if (!HasBaseInstance())
                return GetInputType.None;

            return m_hBaseInstance.gameInputData.GetButtonInput(nButtonID);
        }

        public static GetInputType GetButtonInput(int nPlayerID, int nButtonID)
        {
            if (!HasBaseInstance())
                return GetInputType.None;

            return m_hBaseInstance.gameInputData.GetButtonInput(nPlayerID, nButtonID);
        }

        public static void SetButtonInput(int nPlayerID, int nButtonID, GetInputType eInput)
        {
            if (!HasBaseInstance())
                return;

            m_hBaseInstance.gameInputData.SetButtonInput(nPlayerID, nButtonID, eInput);
        }

        public static void SetButtonInput(int nPlayerID, int nButtonID, bool bPress)
        {
            if (!HasBaseInstance())
                return;

            m_hBaseInstance.gameInputData.SetButtonInput(nPlayerID, nButtonID, bPress);
        }

        public static bool GetAnyButtonDown()
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonDown();
        }

        public static bool GetAnyButtonDown(int nPlayerID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonDown(nPlayerID);
        }

        public static bool GetButtonDown(int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonDown(nButtonID);
        }

        public static bool GetButtonDown(int nPlayerID, int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonDown(nPlayerID, nButtonID);
        }

        public static bool GetAnyButtonHold()
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonHold();
        }

        public static bool GetAnyButtonHold(int nPlayerID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonHold(nPlayerID);
        }

        public static bool GetButtonHold(int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonHold(nButtonID);
        }

        public static bool GetButtonHold(int nPlayerID, int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonHold(nPlayerID, nButtonID);
        }

        public static bool GetAnyButtonUp()
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonUp();
        }

        public static bool GetAnyButtonUp(int nPlayerID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetAnyButtonUp(nPlayerID);
        }

        public static bool GetButtonUp(int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonUp(nButtonID);
        }

        public static bool GetButtonUp(int nPlayerID, int nButtonID)
        {
            if (!HasBaseInstance())
                return false;

            return m_hBaseInstance.gameInputData.GetButtonUp(nPlayerID, nButtonID);
        }

        #endregion

        #region Helper

        static bool HasBaseInstance()
        {
            bool bResult = m_hBaseInstance != null;

            if (!bResult)
            {
                Debug.LogWarning("Don't have DSC_Input derived class in scene.");
            }

            return bResult;
        }

        #endregion
    }
}