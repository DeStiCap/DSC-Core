using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DSC.Core
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class ReadOnlyFieldAttribute : MultiPropertyAttribute
    {
#if UNITY_EDITOR

        public override void OnPreGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }

        public override void OnPostGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = true;
        }
#endif
    }
}