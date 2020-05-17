using UnityEngine;

namespace DSC.Core
{
    public static class InputUtility
    {
        /// <summary>
        /// Calculate new input axis to same old axis behaviour as old input.
        /// </summary>
        /// <param name="fAxis">Current Axis</param>
        /// <param name="fRawAxis">Raw Axis that receive from new input.</param>
        /// <param name="fSensitivity">Value axis incease in 1 second when press input.</param>
        /// <param name="fGravity">Value axis decrease in 1 second to 0 when not press input.</param>
        /// <param name="fDeltaTime">Time deltatime</param>
        public static void CalculateAxis(ref float fAxis, float fRawAxis, float fSensitivity, float fGravity, float fDeltaTime)
        {
            if (fRawAxis != 0)
            {
                if ((fRawAxis > 0 && fAxis < 0) || (fRawAxis < 0 && fAxis > 0))
                    fAxis = 0;

                fAxis += fRawAxis * fSensitivity * fDeltaTime;
                fAxis = Mathf.Clamp(fAxis, -1, 1);
            }
            else if (fAxis != 0)
            {
                float fReduce = fGravity * fDeltaTime;
                if (fAxis < 0)
                    fReduce = -fReduce;

                float fNewAxis = fAxis - fReduce;
                if ((fNewAxis > 0 && fAxis < 0) || (fNewAxis < 0 && fAxis > 0))
                    fNewAxis = 0;

                fAxis = fNewAxis;
            }
        }

        /// <summary>
        /// Calculate new input axis to same old axis behaviour as old input.
        /// </summary>
        /// <param name="vAxis">Current Axis</param>
        /// <param name="vRawAxis">Raw Axis that receive from new input.</param>
        /// <param name="fSensitivity">Value axis incease in 1 second when press input.</param>
        /// <param name="fGravity">Value axis decrease in 1 second to 0 when not press input.</param>
        /// <param name="fDeltaTime">Time deltatime</param>
        public static void CalculateAxis(ref Vector2 vAxis, Vector2 vRawAxis, float fSensitivity, float fGravity, float fDeltaTime)
        {
            CalculateAxis(ref vAxis.x, vRawAxis.x, fSensitivity, fGravity, fDeltaTime);
            CalculateAxis(ref vAxis.y, vRawAxis.y, fSensitivity, fGravity, fDeltaTime);
        }

        /// <summary>
        /// Convert raw float value from new input to GetInputType.
        /// </summary>
        /// <param name="ePreviousGetType">Previous get type.</param>
        /// <param name="bRawValue">Raw value from new input.</param>
        /// <returns>Convert GetInputType</returns>
        public static GetInputType ConvertRawValueToGetType(GetInputType ePreviousGetType,bool bRawValue)
        {
            var eResult = GetInputType.None;

            switch (ePreviousGetType)
            {
                case GetInputType.None:
                    if (bRawValue)
                        eResult = GetInputType.Down;
                    else
                        eResult = GetInputType.Up;
                    break;

                case GetInputType.Down:
                    if (bRawValue)
                        eResult = GetInputType.Hold;
                    else
                        eResult = GetInputType.Up;
                    break;

                case GetInputType.Hold:
                    if (!bRawValue)
                        eResult = GetInputType.Up;
                    break;

                case GetInputType.Up:
                    if (bRawValue)
                        eResult = GetInputType.Down;
                    else
                        eResult = GetInputType.None;
                    break;
            }

            return eResult;
        }
    }
}