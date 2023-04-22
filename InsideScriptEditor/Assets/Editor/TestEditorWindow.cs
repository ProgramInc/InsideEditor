// Simple script that lets you visualize your scripts in an editor window
// This can be expanded to save your scripts also in the editor window.

using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using UnityEditor.SceneManagement;

public class TestEditorWindow : EditorWindow
{
    string text = "An Error Occured...";
    Vector2 scroll;
    string type = "";
    string label = "";
    string originalText = "";
    bool showSaveButton = false;
    string pathToFile;
    public void Init(string type, string label, string pathToFile)
    {
        this.type = type;
        this.label = label;
        this.pathToFile = pathToFile;

        TestEditorWindow window = (TestEditorWindow)GetWindow(typeof(TestEditorWindow), true, "EditorGUILayout.TextArea");
        window.Show();
    }

    void OnGUI()
    {

        GUILayout.Label(label, EditorStyles.boldLabel);


        if (text == null || text == "An Error Occured...")
        {
            originalText = ReadScriptFile.ReadFile(type);
            text = originalText;
        }

        GUIStyle gUIStyle = new GUIStyle() { richText = true, fontSize = 16 };
        GUILayoutOption[] layoutOptions = new GUILayoutOption[] { GUILayout.ExpandHeight(true), GUILayout.Height(position.height - 30) };

        scroll = EditorGUILayout.BeginScrollView(scroll);
        EditorGUI.BeginChangeCheck();
        text = EditorGUILayout.TextArea(text, gUIStyle, layoutOptions);
        text = ReadScriptFile.ConlorizeRichText(text);
        if (EditorGUI.EndChangeCheck())
        {
            if (text.Equals(originalText))
            {
                label = "";
                showSaveButton = false;
            }
            else
            {
                label = "Unsaved Changes**";
                showSaveButton = true;
            }
        }
        GUILayoutOption[] buttonOptions = new GUILayoutOption[] { /*EditorGUILayout.*/};
        EditorGUILayout.EndScrollView();

        GUI.enabled = showSaveButton;

        if (GUILayout.Button("Save"))
        {
            label = "";
            string normalized = Regex.Replace(text, @"\r\n|\n\r|\n|\r", "\r\n");
            ReadScriptFile.WriteFile(type, text);
            text = ReadScriptFile.ReadFile(type);
            text = ReadScriptFile.ConlorizeRichText(text);
            originalText = text;
            showSaveButton = false;
            AssetDatabase.Refresh();
            
        }

        GUI.enabled = true;
    }
}