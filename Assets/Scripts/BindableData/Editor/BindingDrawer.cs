using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BindingField))]
public class BindingDrawer : PropertyDrawer
{
    private string _typeId;
    string[] _targetNames;

    void Initialize(SerializedProperty bindingType)
    {
        string typeId = bindingType.FindPropertyRelative("assemblyQualifiedName").stringValue;
        
        if (_targetNames != null && _typeId == typeId) return;
        _typeId = typeId;

        if (!string.IsNullOrEmpty(typeId))
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .First(t => t.AssemblyQualifiedName == typeId);
            
            _targetNames = type.GetFields().Where(t => typeof(AbstractBindableVariable).IsAssignableFrom(t.FieldType)).Select(t => t.Name).ToArray();
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
    {
        var typeProperty = property.FindPropertyRelative("bindingType");
        
        Initialize(typeProperty);
        
        var targetProperty = property.FindPropertyRelative("property");
        
        EditorGUI.PropertyField(position, typeProperty, new GUIContent("Bindable Type"));

        if (!string.IsNullOrEmpty(typeProperty.FindPropertyRelative("assemblyQualifiedName").stringValue)) 
        {
            position = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.objectField);
            
            var currentIndex = string.IsNullOrEmpty(targetProperty.stringValue) ? 0 : Array.IndexOf(_targetNames, targetProperty.stringValue);
            var selectedIndex = EditorGUI.Popup(position, "Field", currentIndex, _targetNames);
            
            if (selectedIndex >= 0 && selectedIndex != currentIndex) 
            {
                targetProperty.stringValue = _targetNames[selectedIndex];
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}