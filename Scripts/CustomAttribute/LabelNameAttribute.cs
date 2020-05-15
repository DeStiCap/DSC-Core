using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DSC.Core
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class LabelNameAttribute : MultiPropertyAttribute
    {
        public string name { get; private set; }

        public LabelNameAttribute(string sName)
        {
            name = sName;
        }

#if UNITY_EDITOR

        public override void OnPreGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label.text = name;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }

        bool IsArray(SerializedProperty property)
        {
            string path = property.propertyPath;
            int idot = path.IndexOf('.');
            if (idot == -1) return false;
            string propName = path.Substring(0, idot);
            SerializedProperty p = property.serializedObject.FindProperty(propName);
            return p.isArray;
        }
#endif
    }
}