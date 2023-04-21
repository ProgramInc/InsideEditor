using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InlineCodeEditorWindow : EditorWindow
{
    string text = "";
    string label = "";

    public InlineCodeEditorWindow Init(string label, string type)
    {
        this.label = label;

        InlineCodeEditorWindow window = (InlineCodeEditorWindow)GetWindow(typeof(InlineCodeEditorWindow));
        window.text = AssemblyGrabber.assembly.CodeBase.ToString();
        Debug.Log(AssetDatabase.LoadAssetAtPath<MonoBehaviour>("/"+type));
        Debug.Log(AssemblyGrabber.assembly.GetFile(type+".cs"));
        /*Debug.Log();
        Debug.Log();
        Debug.Log();
        Debug.Log();
        Debug.Log();*/
        return window;
    }

    void OnGUI()
    {
        GUILayout.Label(label, EditorStyles.boldLabel);
        text = EditorGUILayout.TextArea(text, GUILayout.ExpandHeight(true));
        
        if (GUILayout.Button("Save"))
        {
            
        }
    }
}

