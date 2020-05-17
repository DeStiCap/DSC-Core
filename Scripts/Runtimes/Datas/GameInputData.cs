using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public struct GameInputData
    {
        #region Data

        struct AxisData
        {
            public Vector2 vRawAxis;
            public Vector2 vAxis;

            public DirectionType2D eHorizontalPress;
            public DirectionType2D eHorizontalDoublePress;
            public DirectionType2D eHorizontalTap;
            public DirectionType2D eHorizontalDoubleTap;

            public DirectionType2D eLastHorizontalTap;
            public float fHorizontalPressTime;
            public float fHorizontalReleaseTime;

            public DirectionType2D eVerticalPress;
            public DirectionType2D eVerticalDoublePress;
            public DirectionType2D eVerticalTap;
            public DirectionType2D eVerticalDoubleTap;

            public DirectionType2D eLastVerticalTap;
            public float fVerticalPressTime;
            public float fVerticalReleaseTime;
        }

        struct InputData
        {
            public AxisData[] arrAxis;
            public Dictionary<int, ButtonData> dicButton;

        }

        class ButtonData
        {
            public GetInputType eGetType;
        }

        #endregion

        #region Variable

        readonly List<InputData> m_lstPlayerInput;
        readonly float m_fSensitivity;
        readonly float m_fGravity;

        #endregion

        public GameInputData(int nPlayerNumber)
        {
            m_lstPlayerInput = new List<InputData>();
            m_fSensitivity = 3f;
            m_fGravity = 3f;

            InitData(nPlayerNumber);
        }

        public GameInputData(int nPlayerNumber, int nAxisNumber)
        {
            m_lstPlayerInput = new List<InputData>();
            m_fSensitivity = 3f;
            m_fGravity = 3f;

            InitData(nPlayerNumber, nAxisNumber);
        }

        public GameInputData(int nPlayerNumber, float fSensitivity, float fGravity)
        {
            m_lstPlayerInput = new List<InputData>();
            m_fSensitivity = fSensitivity;
            m_fGravity = fGravity;

            InitData(nPlayerNumber);
        }

        public GameInputData(int nPlayerNumber, int nAxisNumber, float fSensitivity, float fGravity)
        {
            m_lstPlayerInput = new List<InputData>();
            m_fSensitivity = fSensitivity;
            m_fGravity = fGravity;

            InitData(nPlayerNumber, nAxisNumber);
        }

        #region Main

        #region Main - Update

        public void OnUpdate()
        {
            float fTime = Time.unscaledTime;
            float fDeltaTime = Time.unscaledDeltaTime;
            float fDelayClear = 0.2f;
            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                var hInput = m_lstPlayerInput[i];
                for (int j = 0; j < hInput.arrAxis.Length; j++)
                {
                    var hAxis = hInput.arrAxis[j];
                    if (hAxis.eLastHorizontalTap != 0)
                    {
                        if (fTime >= hAxis.fHorizontalReleaseTime + fDelayClear)
                        {
                            hAxis.eLastHorizontalTap = 0;
                        }
                    }

                    if (hAxis.eLastVerticalTap != 0)
                    {
                        if (fTime >= hAxis.fVerticalReleaseTime + fDelayClear)
                        {
                            hAxis.eLastVerticalTap = 0;
                        }
                    }

                    if (hAxis.vAxis != hAxis.vRawAxis)
                    {
                        InputUtility.CalculateAxis(ref hAxis.vAxis.x, hAxis.vRawAxis.x, m_fSensitivity, m_fGravity, fDeltaTime);
                        InputUtility.CalculateAxis(ref hAxis.vAxis.y, hAxis.vRawAxis.y, m_fSensitivity, m_fGravity, fDeltaTime);
                    }

                    hInput.arrAxis[j] = hAxis;
                }

                m_lstPlayerInput[i] = hInput;
            }
        }

        public void OnLateUpdate()
        {
            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                var hInput = m_lstPlayerInput[i];

                for (int j = 0; j < hInput.arrAxis.Length; j++)
                {
                    var hAxis = hInput.arrAxis[j];
                    hAxis.eHorizontalPress = 0;
                    hAxis.eHorizontalDoublePress = 0;
                    hAxis.eHorizontalTap = 0;
                    hAxis.eHorizontalDoubleTap = 0;
                    hAxis.eVerticalPress = 0;
                    hAxis.eVerticalDoublePress = 0;
                    hAxis.eVerticalTap = 0;
                    hAxis.eVerticalDoubleTap = 0;
                    hInput.arrAxis[j] = hAxis;
                }

                foreach (var hButton in hInput.dicButton)
                {
                    var hValue = hButton.Value;
                    switch (hValue.eGetType)
                    {
                        case GetInputType.Down:
                            hValue.eGetType = GetInputType.Hold;
                            break;

                        case GetInputType.Up:
                            hValue.eGetType = GetInputType.None;
                            break;
                    }
                }

                m_lstPlayerInput[i] = hInput;
            }
        }

        #endregion

        public Vector2 GetAnyRawAxis()
        {
            Vector2 vResult = Vector2.zero;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                vResult = MainGetRawAxis(i);
                if (vResult != Vector2.zero)
                    break;
            }

            return vResult;
        }

        public Vector2 GetAnyRawAxis(int nAxisID)
        {
            Vector2 vResult = Vector2.zero;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                vResult = MainGetRawAxis(i,nAxisID);
                if (vResult != Vector2.zero)
                    break;
            }

            return vResult;
        }

        public Vector2 GetRawAxis(int nPlayerID)
        {
            return MainGetRawAxis(nPlayerID);
        }

        public Vector2 GetRawAxis(int nPlayerID, int nAxisID)
        {
            return MainGetRawAxis(nPlayerID, nAxisID);
        }

        Vector2 MainGetRawAxis(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return default;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].vRawAxis;
        }

        public void SetRawAxis(int nPlayerID, Vector2 vAxis)
        {
            MainSetRawAxis(nPlayerID, vAxis);
        }

        public void SetRawAxis(int nPlayerID, int nAxisID, Vector2 vAxis)
        {
            MainSetRawAxis(nPlayerID, vAxis, nAxisID);
        }

        void MainSetRawAxis(int nPlayerID, Vector2 vAxis, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return;

            float fTime = Time.unscaledTime;
            var hAxis = m_lstPlayerInput[nPlayerID].arrAxis[nAxisID];
            Vector2 vPreviousAxis = hAxis.vRawAxis;
            UpdateHorizontal();
            UpdateVertical();
            hAxis.vRawAxis = vAxis;
            m_lstPlayerInput[nPlayerID].arrAxis[nAxisID] = hAxis;


            #region Method

            void UpdateHorizontal()
            {
                var ePrevious = vPreviousAxis.x > 0 ? DirectionType2D.Right : DirectionType2D.Left;
                var eNext = vAxis.x > 0 ? DirectionType2D.Right : DirectionType2D.Left;

                if (vAxis.x != 0 && vPreviousAxis.x == 0)
                {
                    hAxis.eHorizontalPress = eNext;
                    hAxis.fHorizontalPressTime = fTime;

                    if (hAxis.eLastHorizontalTap != 0 && hAxis.eLastHorizontalTap == eNext)
                    {
                        hAxis.eHorizontalDoublePress = eNext;
                    }
                }
                else if (vAxis.x == 0 && vPreviousAxis.x != 0)
                {
                    hAxis.fHorizontalReleaseTime = fTime;

                    if (fTime < hAxis.fHorizontalPressTime + 0.2f)
                    {
                        if (hAxis.eLastHorizontalTap != 0 && hAxis.eLastHorizontalTap == ePrevious)
                        {
                            hAxis.eHorizontalDoubleTap = ePrevious;
                        }

                        hAxis.eHorizontalTap = ePrevious;
                        hAxis.eLastHorizontalTap = ePrevious;
                    }
                    else
                    {
                        hAxis.eLastHorizontalTap = 0;
                    }
                }
            }

            void UpdateVertical()
            {
                var ePrevious = vPreviousAxis.y > 0 ? DirectionType2D.Up : DirectionType2D.Down;
                var eNext = vAxis.y > 0 ? DirectionType2D.Up : DirectionType2D.Down;

                if (vAxis.y != 0 && vPreviousAxis.y == 0)
                {
                    hAxis.eVerticalPress = eNext;
                    hAxis.fVerticalPressTime = fTime;

                    if (hAxis.eLastVerticalTap != 0 && hAxis.eLastVerticalTap == eNext)
                    {
                        hAxis.eVerticalDoublePress = eNext;
                    }
                }
                else if (vAxis.y == 0 && vPreviousAxis.y != 0)
                {
                    hAxis.fVerticalReleaseTime = fTime;

                    if (fTime < hAxis.fVerticalPressTime + 0.2f)
                    {
                        if (hAxis.eLastVerticalTap != 0 && hAxis.eLastVerticalTap == ePrevious)
                        {
                            hAxis.eVerticalDoubleTap = ePrevious;
                        }

                        hAxis.eVerticalTap = ePrevious;
                        hAxis.eLastVerticalTap = ePrevious;
                    }
                    else
                    {
                        hAxis.eLastVerticalTap = 0;
                    }
                }
            }

            #endregion
        }

        public Vector2 GetAnyAxis()
        {
            Vector2 vResult = Vector2.zero;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                vResult = MainGetAxis(i);
                if (vResult != Vector2.zero)
                    break;
            }

            return vResult;
        }

        public Vector2 GetAnyAxis(int nAxisID)
        {
            Vector2 vResult = Vector2.zero;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                vResult = MainGetAxis(i,nAxisID);
                if (vResult != Vector2.zero)
                    break;
            }

            return vResult;
        }

        public Vector2 GetAxis(int nPlayerID)
        {
            return MainGetAxis(nPlayerID);
        }

        public Vector2 GetAxis(int nPlayerID, int nAxisID)
        {
            return MainGetAxis(nPlayerID, nAxisID);
        }

        Vector2 MainGetAxis(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return Vector2.zero;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].vAxis;
        }

        public DirectionType2D GetAnyHorizontalPress()
        {
            DirectionType2D eResult = 0;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                for(int j = 0; j < m_lstPlayerInput[i].arrAxis.Length; j++)
                {
                    eResult = m_lstPlayerInput[i].arrAxis[j].eHorizontalPress;
                    if (eResult != 0)
                        goto Finish;
                }                
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetAnyHorizontalPress(int nAxisID)
        {
            DirectionType2D eResult = 0;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                if (!HasAxisID(i, nAxisID))
                    continue;

                eResult = m_lstPlayerInput[i].arrAxis[nAxisID].eHorizontalPress;
                if (eResult != 0)
                    goto Finish;
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetHorizontalPress(int nPlayerID)
        {
            return MainGetHorizontalPress(nPlayerID);
        }

        public DirectionType2D GetHorizontalPress(int nPlayerID, int nAxisID)
        {
            return MainGetHorizontalPress(nPlayerID, nAxisID);
        }

        DirectionType2D MainGetHorizontalPress(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return 0;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].eHorizontalPress;
        }

        public DirectionType2D GetAnyVerticalPress()
        {
            DirectionType2D eResult = 0;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                for(int j = 0; j < m_lstPlayerInput[i].arrAxis.Length; j++)
                {
                    eResult = m_lstPlayerInput[i].arrAxis[j].eVerticalPress;
                    if (eResult != 0)
                        goto Finish;
                }
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetAnyVerticalPress(int nAxisID)
        {
            DirectionType2D eResult = 0;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                if (!HasAxisID(i, nAxisID))
                    continue;

                eResult = m_lstPlayerInput[i].arrAxis[nAxisID].eVerticalPress;
                if (eResult != 0)
                    goto Finish;
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetVerticalPress(int nPlayerID)
        {
            return MainGetVerticalPress(nPlayerID);
        }

        public DirectionType2D GetVerticalPress(int nPlayerID, int nAxisID)
        {
            return MainGetVerticalPress(nPlayerID, nAxisID);
        }

        DirectionType2D MainGetVerticalPress(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return 0;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].eVerticalPress;
        }

        public DirectionType2D GetAnyHorizontalDoublePress()
        {
            DirectionType2D eResult = 0;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                for(int j = 0; j < m_lstPlayerInput[i].arrAxis.Length; j++)
                {
                    eResult = m_lstPlayerInput[i].arrAxis[j].eHorizontalDoublePress;
                    if (eResult != 0)
                        goto Finish;                    
                }
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetAnyHorizontalDoublePress(int nAxisID)
        {
            DirectionType2D eResult = 0;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                if (!HasAxisID(i, nAxisID))
                    continue;

                eResult = m_lstPlayerInput[i].arrAxis[nAxisID].eHorizontalDoublePress;
                if (eResult != 0)
                    goto Finish;
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetHorizontalDoublePress(int nPlayerID)
        {
            return MainGetHorizontalDoublePress(nPlayerID);
        }

        public DirectionType2D GetHorizontalDoublePress(int nPlayerID, int nAxisID)
        {
            return MainGetHorizontalDoublePress(nPlayerID, nAxisID);
        }

        DirectionType2D MainGetHorizontalDoublePress(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return 0;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].eHorizontalDoublePress;
        }

        public DirectionType2D GetAnyVerticalDoublePress()
        {
            DirectionType2D eResult = 0;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                for(int j = 0; j < m_lstPlayerInput[i].arrAxis.Length; j++)
                {
                    eResult = m_lstPlayerInput[i].arrAxis[j].eVerticalDoublePress;
                    if (eResult != 0)
                        goto Finish;
                }
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetAnyVerticalDoublePress(int nAxisID)
        {
            DirectionType2D eResult = 0;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                if (!HasAxisID(i, nAxisID))
                    continue;

                eResult = m_lstPlayerInput[i].arrAxis[nAxisID].eVerticalDoublePress;
                if (eResult != 0)
                    goto Finish;
            }

        Finish:
            ;

            return eResult;
        }

        public DirectionType2D GetVerticalDoublePress(int nPlayerID)
        {
            return MainGetVerticalDoublePress(nPlayerID);
        }

        public DirectionType2D GetVerticalDoublePress(int nPlayerID, int nAxisID)
        {
            return MainGetVerticalDoublePress(nPlayerID, nAxisID);
        }

        DirectionType2D MainGetVerticalDoublePress(int nPlayerID, int nAxisID = 0)
        {
            if (!HasPlayerID(nPlayerID) || !HasAxisID(nPlayerID, nAxisID))
                return 0;

            return m_lstPlayerInput[nPlayerID].arrAxis[nAxisID].eVerticalDoublePress;
        }

        public GetInputType GetButtonInput(int nButtonID)
        {
            var eResult = GetInputType.None;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                eResult = MainGetButtonInput(i, nButtonID);
                if (eResult != GetInputType.None)
                    break;
            }

            return eResult;
        }

        public GetInputType GetButtonInput(int nPlayerID, int nButtonID)
        {
            return MainGetButtonInput(nPlayerID, nButtonID);
        }

        GetInputType MainGetButtonInput(int nPlayerID, int nButtonID)
        {
            if (!HasPlayerID(nPlayerID))
                return default;

            var hInputData = m_lstPlayerInput[nPlayerID];
            if (hInputData.dicButton.TryGetValue(nButtonID, out var hButtonData))
                return hButtonData.eGetType;

            return default;
        }

        public void SetButtonInput(int nPlayerID, int nButtonID, GetInputType eInput)
        {
            MainSetButtonInput(nPlayerID, nButtonID, eInput);
        }

        public void SetButtonInput(int nPlayerID, int nButtonID, bool bPress)
        {
            var eInput = ParseButtonPress(bPress);
            MainSetButtonInput(nPlayerID, nButtonID, eInput);
        }

        void MainSetButtonInput(int nPlayerID, int nButtonID, GetInputType eInput)
        {
            if (!HasPlayerID(nPlayerID))
                return;

            if (m_lstPlayerInput[nPlayerID].dicButton.TryGetValue(nButtonID, out var hButtonData))
                hButtonData.eGetType = eInput;
            else
            {
                m_lstPlayerInput[nPlayerID].dicButton.Add(nButtonID, new ButtonData
                {
                    eGetType = eInput
                });
            }
        }

        public bool GetAnyButtonDown()
        {
            bool bResult = false;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                foreach (var hButton in m_lstPlayerInput[i].dicButton)
                {
                    if (hButton.Value == null)
                        continue;

                    bResult = IsButtonDown(hButton.Value.eGetType);
                    if (bResult)
                        goto Finish;
                }
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetAnyButtonDown(int nPlayerID)
        {
            bool bResult = false;
            if (!HasPlayerID(nPlayerID))
                goto Finish;

            foreach (var hButton in m_lstPlayerInput[nPlayerID].dicButton)
            {
                if (hButton.Value == null)
                    continue;

                bResult = IsButtonDown(hButton.Value.eGetType);
                if (bResult)
                    goto Finish;
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetButtonDown(int nButtonID)
        {
            bool bResult = false;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                bResult = MainGetButtonDown(i, nButtonID);
                if (bResult)
                    break;
            }

            return bResult;
        }

        public bool GetButtonDown(int nPlayerID,int nButtonID)
        {
            return MainGetButtonDown(nPlayerID, nButtonID);
        }


        bool MainGetButtonDown(int nPlayerID, int nButtonID)
        {
            var eInput = MainGetButtonInput(nPlayerID, nButtonID);
            return IsButtonDown(eInput);
        }

        public bool GetAnyButtonHold()
        {
            bool bResult = false;

            for (int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                foreach(var hButton in m_lstPlayerInput[i].dicButton)
                {
                    if (hButton.Value == null)
                        continue;

                    bResult = IsButtonHold(hButton.Value.eGetType);
                    if (bResult)
                        goto Finish;
                }
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetAnyButtonHold(int nPlayerID)
        {
            bool bResult = false;
            if (!HasPlayerID(nPlayerID))
                goto Finish;

            foreach (var hButton in m_lstPlayerInput[nPlayerID].dicButton)
            {
                if (hButton.Value == null)
                    continue;

                bResult = IsButtonHold(hButton.Value.eGetType);
                if (bResult)
                    goto Finish;
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetButtonHold(int nButtonID)
        {
            bool bResult = false;

            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                bResult = MainGetButtonHold(i, nButtonID);
                if (bResult)
                    break;
            }

            return bResult;
        }

        public bool GetButtonHold(int nPlayerID,int nButtonID)
        {
            return MainGetButtonHold(nPlayerID, nButtonID);
        }

        bool MainGetButtonHold(int nPlayerID, int nButtonID)
        {
            var eInput = MainGetButtonInput(nPlayerID, nButtonID);
            return IsButtonHold(eInput);
        }

        public bool GetAnyButtonUp()
        {
            bool bResult = false;
            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                foreach(var hButton in m_lstPlayerInput[i].dicButton)
                {
                    if (hButton.Value == null)
                        continue;

                    bResult = IsButtonUp(hButton.Value.eGetType);
                    if (bResult)
                        goto Finish;
                }
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetAnyButtonUp(int nPlayerID)
        {
            bool bResult = false;
            if(!HasPlayerID(nPlayerID))
                goto Finish;

            foreach (var hButton in m_lstPlayerInput[nPlayerID].dicButton)
            {
                if (hButton.Value == null)
                    continue;

                bResult = IsButtonUp(hButton.Value.eGetType);
                if (bResult)
                    goto Finish;
            }

        Finish:
            ;

            return bResult;
        }

        public bool GetButtonUp(int nButtonID)
        {
            bool bResult = false;
            for(int i = 0; i < m_lstPlayerInput.Count; i++)
            {
                bResult = MainGetButtonUp(i, nButtonID);
                if (bResult)
                    break;
            }

            return bResult;
        }

        public bool GetButtonUp(int nPlayerID,int nButtonID)
        {
            return MainGetButtonUp(nPlayerID, nButtonID);
        }

        bool MainGetButtonUp(int nPlayerID, int nButtonID)
        {
            var eInput = MainGetButtonInput(nPlayerID, nButtonID);
            return IsButtonUp(eInput);
        }

        #endregion

        #region Helper

        void InitData(int nPlayerNumber, int nAxisNumber = 1)
        {
            if (nPlayerNumber < 1)
            {
                Debug.LogError("Can't init GameInputData with " + nPlayerNumber + " Player number.");
                return;
            }

            for (int i = 0; i < nPlayerNumber; i++)
            {
                m_lstPlayerInput.Add(GetNewInputData(nAxisNumber));
            }
        }

        InputData GetNewInputData(int nAxisNumber)
        {
            return new InputData
            {
                arrAxis = new AxisData[nAxisNumber],
                dicButton = new Dictionary<int, ButtonData>()
            };
        }

        bool HasPlayerID(int nPlayerID)
        {
            if (nPlayerID < 0 && nPlayerID >= m_lstPlayerInput.Count)
            {
                Debug.LogError("Can't get button input by " + nPlayerID + " player ID");
                return false;
            }

            return true;
        }

        bool HasAxisID(int nPlayerID, int nAxisID)
        {
            if (nAxisID < 0 || nAxisID >= m_lstPlayerInput[nPlayerID].arrAxis.Length)
            {
                Debug.LogError("Don't have this Axis ID");
                return false;
            }

            return true;
        }

        GetInputType ParseButtonPress(bool bPress)
        {
            return bPress ? GetInputType.Down : GetInputType.Up;
        }

        bool IsButtonDown(GetInputType eInput)
        {
            return eInput == GetInputType.Down;
        }

        bool IsButtonHold(GetInputType eInput)
        {
            return eInput == GetInputType.Hold;
        }

        bool IsButtonUp(GetInputType eInput)
        {
            return eInput == GetInputType.Up;
        }

        #endregion
    }
}