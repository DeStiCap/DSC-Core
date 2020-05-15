using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Core
{
    public abstract class DSC_Time : MonoBehaviour
    {
        public static float time
        {
            get
            {
                return m_hBaseInstance == null ? Time.time : m_hBaseInstance.customTime;
            }
        }

        public static float timeScale
        {
            get
            {
                return m_hBaseInstance == null ? Time.timeScale : m_hBaseInstance.customTimeScale;
            }
        }

        public static float deltaTime
        {
            get
            {
                return m_hBaseInstance == null ? Time.deltaTime : m_hBaseInstance.customDeltaTime;
            }
        }

        public static float fixedDeltaTime
        {
            get
            {
                return m_hBaseInstance == null ? Time.fixedDeltaTime : m_hBaseInstance.customFixedDeltaTime;
            }
        }

        public static event UnityAction<float> onTimeScaleChange
        {
            add
            {
                if (m_hBaseInstance != null)
                    m_hBaseInstance.onTimeScaleChangeAction += value;
            }

            remove
            {
                if (m_hBaseInstance != null)
                    m_hBaseInstance.onTimeScaleChangeAction -= value;
            }
        }

        public static event UnityAction<float> onUnityTimeScaleChange
        {
            add
            {
                if (m_hBaseInstance != null)
                    m_hBaseInstance.onUnityTimeScaleChangeAction += value;
            }

            remove
            {
                if (m_hBaseInstance != null)
                    m_hBaseInstance.onUnityTimeScaleChangeAction -= value;
            }
        }

        protected static DSC_Time m_hBaseInstance;
        protected abstract float customTime { get; }
        protected abstract float customTimeScale { get; }
        protected abstract float customDeltaTime { get; }
        protected abstract float customFixedDeltaTime { get; }
        protected abstract UnityAction<float> onTimeScaleChangeAction { get; set; }
        protected abstract UnityAction<float> onUnityTimeScaleChangeAction { get; set; }

        public static void ChangeTimeScale(float fTimeScale)
        {
            if (m_hBaseInstance != null)
                m_hBaseInstance.MainChangeTimeScale(fTimeScale);
            else
                Time.timeScale = fTimeScale;
        }

        public static void ChangeTimeScale(float fTimeScale, float fResetTime)
        {
            if (m_hBaseInstance != null)
                m_hBaseInstance.MainChangeTimeScale(fTimeScale, fResetTime);
            else
            {
                Time.timeScale = fTimeScale;
                ShowNoManagerWarning();
            }
        }

        protected abstract void MainChangeTimeScale(float fTimeScale, float fResetTime = 0);

        public static void ChangeUnityTimeScale(float fTimeScale)
        {
            if (m_hBaseInstance != null)
                m_hBaseInstance.MainChangeUnityTimeScale(fTimeScale);
            else
                Time.timeScale = fTimeScale;
        }

        public static void ChangeUnityTimeScale(float fTimeScale, float fResetTime)
        {
            if (m_hBaseInstance != null)
                m_hBaseInstance.MainChangeUnityTimeScale(fTimeScale, fResetTime);
            else
            {
                Time.timeScale = fTimeScale;
                ShowNoManagerWarning();
            }
        }

        protected abstract void MainChangeUnityTimeScale(float fTimeScale, float fResetTime = 0);

        #region Helper

        protected static void ShowNoManagerWarning()
        {
            Debug.LogWarning("Don't have Time Manager in scene.");
        }

        #endregion
    }
}