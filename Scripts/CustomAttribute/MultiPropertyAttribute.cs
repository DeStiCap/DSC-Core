using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace DSC.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class MultiPropertyAttribute : PropertyAttribute
    {
        public IOrderedEnumerable<object> stored = null;

#if UNITY_EDITOR

        public virtual void OnGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label)
        {
            UnityEditor.EditorGUI.PropertyField(position, property, label);
        }

        public virtual void OnPreGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label) { }
        public virtual void OnPostGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label) { }

        public virtual bool IsVisible(UnityEditor.SerializedProperty property) { return true; }
        public virtual float? GetPropertyHeight(UnityEditor.SerializedProperty property, GUIContent label, float baseHeight) { return null; }
#endif
    }
}