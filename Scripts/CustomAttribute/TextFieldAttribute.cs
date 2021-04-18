using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DSC.Core
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class TextFieldAttribute : MultiPropertyAttribute
    {
        public string placeHolderText { get; private set; }
        public int? maxShowLine { get; private set; }

        public TextFieldAttribute(string sPlaceHolderText)
        {
            placeHolderText = sPlaceHolderText;
        }

        public TextFieldAttribute(string sPlaceHolderText,int fMaxShowLine)
        {
            placeHolderText = sPlaceHolderText;
            maxShowLine = fMaxShowLine;
        }

#if UNITY_EDITOR

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                string myText = property.stringValue;
                var placeholderTextStyle = new GUIStyle(EditorStyles.textArea);
                placeholderTextStyle.fontStyle = FontStyle.Italic;

                label = EditorGUI.BeginProperty(position, label, property);
                property.stringValue = EditorGUI.TextArea(position, property.stringValue);
                EditorGUI.EndProperty();

                if (string.IsNullOrEmpty(myText))
                {
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUI.TextArea(position, placeHolderText, placeholderTextStyle);
                    EditorGUI.EndDisabledGroup();
                }

            }
        }

        public override float? GetPropertyHeight(SerializedProperty property, GUIContent label, float baseHeight)
        {
            float fHeight = maxShowLine.HasValue ? maxShowLine.Value * 15f + 2f : baseHeight;
            return fHeight;
        }
#endif
    }
}
