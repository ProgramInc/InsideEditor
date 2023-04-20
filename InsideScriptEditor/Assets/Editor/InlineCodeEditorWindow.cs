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

