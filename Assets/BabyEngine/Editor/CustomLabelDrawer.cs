using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BabyEngine {
 
    /// <summary>
    /// 使字段在Inspector中显示自定义的名称。
    /// </summary>
    public class CustomLabelAttribute : PropertyAttribute {
        public string name;

        /// <summary>
        /// 使字段在Inspector中显示自定义的名称。
        /// </summary>
        /// <param name="name">自定义名称</param>
        public CustomLabelAttribute(string name) {
            this.name = name;
        }
    }
    /// <summary>
    /// 定义对带有 `CustomLabelAttribute` 特性的字段的面板内容的绘制行为。
    /// </summary>
    [CustomPropertyDrawer(typeof(CustomLabelAttribute))]
    public class CustomLabelDrawer : PropertyDrawer {
        private GUIContent _label = null;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (_label == null) {
                string name = (attribute as CustomLabelAttribute).name;
                _label = new GUIContent(name);
            }

            EditorGUI.PropertyField(position, property, _label);
        }
    }
}