using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InlineCodeEditorWindow : EditorWindow
{

    string text = "";

    [MenuItem("Window/Text Editor")]
    static void Init()
    {
        InlineCodeEditorWindow window = (InlineCodeEditorWindow)GetWindow(typeof(InlineCodeEditorWindow));
        window.Show();
    }

    void OnGUI()
    {
        text = EditorGUILayout.TextArea(text, GUILayout.ExpandHeight(true));
    }
}

