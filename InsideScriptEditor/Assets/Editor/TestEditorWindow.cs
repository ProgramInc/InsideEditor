// Simple script that lets you visualize your scripts in an editor window
// This can be expanded to save your scripts also in the editor window.

using UnityEngine;
using UnityEditor;

public class TestEditorWindow : EditorWindow
{
    string text = "An Error Occured...";
    Vector2 scroll;
    string type = "";
    string label = "";
    string originalText = "";
    public void Init(string type, string label)
    {
        this.type = type;
        this.label = label;
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

        EditorGUI.BeginChangeCheck();
        scroll = EditorGUILayout.BeginScrollView(scroll);
        text = EditorGUILayout.TextArea(text, gUIStyle, layoutOptions);
        if (EditorGUI.EndChangeCheck())
        {
            if (text.Equals(originalText))
            {
                label = "";
            }
            else 
            {
                label = "Unsaved Changes**";
            }
        }
        /*GUILayoutOption[] buttonOptions = new GUILayoutOption[] {EditorGUILayout.};
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("Save", ))
        {
            Debug.Log("save");
            label = "";
        }*/
    }
}