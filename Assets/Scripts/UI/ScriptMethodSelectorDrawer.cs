using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ScriptMethodSelector))]
public class ScriptMethodSelectorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty targetObjectProp = property.FindPropertyRelative("targetObject");
        SerializedProperty selectedScriptProp = property.FindPropertyRelative("selectedScript");
        SerializedProperty selectedMethodProp = property.FindPropertyRelative("selectedMethod");

        float lineHeight = EditorGUIUtility.singleLineHeight;
        float spacing = 2f;

        Rect objectRect = new Rect(position.x, position.y, position.width, lineHeight);
        EditorGUI.PropertyField(objectRect, targetObjectProp, new GUIContent("Target Object"));

        GameObject targetObject = (GameObject)targetObjectProp.objectReferenceValue;

        if (targetObject != null)
        {
            MonoBehaviour[] scripts = targetObject.GetComponents<MonoBehaviour>();
            List<string> scriptNames = scripts.Select(s => s.GetType().Name).ToList();
            scriptNames.Insert(0, "None");

            int selectedIndex = Mathf.Max(0, scripts.ToList().IndexOf((MonoBehaviour)selectedScriptProp.objectReferenceValue) + 1);
            Rect scriptRect = new Rect(position.x, position.y + lineHeight + spacing, position.width, lineHeight);
            selectedIndex = EditorGUI.Popup(scriptRect, "Script", selectedIndex, scriptNames.ToArray());

            if (selectedIndex > 0)
            {
                selectedScriptProp.objectReferenceValue = scripts[selectedIndex - 1];
            }
            else
            {
                selectedScriptProp.objectReferenceValue = null;
            }

            if (selectedScriptProp.objectReferenceValue != null)
            {
                MonoBehaviour selectedScript = (MonoBehaviour)selectedScriptProp.objectReferenceValue;
                List<string> methodNames = selectedScript.GetType()
                    .GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .Where(m => m.GetParameters().Length == 0) // Csak olyan metódusokat engedünk, amelyeknek nincs paramétere
                    .Select(m => m.Name)
                    .ToList();
                methodNames.Insert(0, "None");

                int methodIndex = Mathf.Max(0, methodNames.IndexOf(selectedMethodProp.stringValue));
                Rect methodRect = new Rect(position.x, position.y + 2 * (lineHeight + spacing), position.width, lineHeight);
                methodIndex = EditorGUI.Popup(methodRect, "Method", methodIndex, methodNames.ToArray());

                selectedMethodProp.stringValue = methodIndex > 0 ? methodNames[methodIndex] : "";
            }
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 3 + 4f;
    }
}
