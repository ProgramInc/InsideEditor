using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
[InitializeOnLoad]
public class AddCustomButtonToInspectors : Editor
{
    static AddCustomButtonToInspectors()
    {
        var assembly = Assembly.Load("Assembly-CSharp");
        var monoBehaviourTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(MonoBehaviour)));
        var target = EditorWindow.focusedWindow;
        foreach (var type in monoBehaviourTypes)
        {
            // Get the Type object for the current MonoBehaviour
            Type currentType = type;

            // Create a new instance of MyCustomEditor<T> with the current MonoBehaviour as the type parameter
            Type customEditorType = typeof(MyCustomEditor<>).MakeGenericType(currentType);
            var editor = Editor.CreateInstance(customEditorType);
            Debug.Log(editor);
            /* Editor editor = Editor.CreateInstance(customEditorType);
             var default = DrawFoldoutInspector(EditorWindow.focusedWindow, ref editor);
             // Use the custom editor to draw the inspector UI for the current MonoBehaviour
             editor.OnInspectorGUI();*/
            /*editor.OnInspectorGUI();*/
        }
    }
}
