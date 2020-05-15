using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DSC.Core
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class EnumMaskAttribute : MultiPropertyAttribute
    {
#if UNITY_EDITOR

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            uint a = (uint)(EditorGUI.MaskField(position, label, property.intValue, property.enumNames));
            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = (int)a;
            }
        }

#endif
    }
}