using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class InlineCodeEditorWindow : EditorWindow
{
    string text = "";
    string label = "";
    string type = "";
    TextMeshProUGUI textMeshPro;
    public InlineCodeEditorWindow Init(string label, string type)
    {
        this.label = label;
        this.type = type;

        InlineCodeEditorWindow window = (InlineCodeEditorWindow)GetWindow(typeof(InlineCodeEditorWindow));
        /*window.text = ReadScriptFile.ReadFile(type);*/
        text = ReadScriptFile.ReadFile(type);
        return window;
    }

    void OnGUI()
    {

        /*if (textMeshPro == null)
        {
            *//*textMeshPro = new RectTransform("TextMeshPro").AddComponent<TextMeshProUGUI>();*/
        /*textMeshPro.transform.SetParent(base.rootVisualElement.visualTree);*//*

        VisualElement textMeshProElement = new VisualElement();
        textMeshProElement.Add(new TextElement { text = textMeshPro.text });


        base.rootVisualElement.Add(textMeshProElement);

    }*/

        /*string formattedSyntax = ParseSyntax(syntax);*/
        GUIStyle gUIStyle = new GUIStyle() { richText = true, fontSize = 16};
        GUILayoutOption[] layoutOptions = new GUILayoutOption[] { GUILayout.ExpandHeight(true) };
        GUILayout.Label(label, EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();
        /*textMeshPro = EditorGUILayout.TextField("Text Field") as TextMeshProUGUI;*/

        /*textMeshPro = EditorGUILayout.ObjectField("Text Field", null, typeof(TextMeshProUGUI), true) as TextMeshProUGUI;*/
        /*textMeshPro.text = "123456";*/
        textMeshPro.text = EditorGUILayout.TextArea(text, gUIStyle, layoutOptions);
        InlineCodeEditorWindow window = (InlineCodeEditorWindow)GetWindow(typeof(InlineCodeEditorWindow));
        
        if (EditorGUI.EndChangeCheck())
        {
            window.label = "Unsaved Changes";
        }
        
        if (GUILayout.Button("Save"))
        {
            window.label = "";
            ReadScriptFile.WriteFile(type, text);
        }
    }
}

