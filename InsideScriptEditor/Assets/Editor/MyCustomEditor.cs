using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true), CanEditMultipleObjects]
public class MyCustomEditor : Editor
{
    Texture2D sprite;
    private void OnEnable()
    {
        sprite = Resources.Load<Texture2D>("Sprites/1");
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayoutOption[] layoutOptions = new GUILayoutOption[] { GUILayout.Height(40), GUILayout.Width(40), };
        GUIStyle style = new GUIStyle(GUI.skin.label) { fontSize = 20 };
        GUIContent gUIContent = new() { image = sprite, text = "", tooltip = "Click To Open Inline Editor" };
        if (GUILayout.Button(gUIContent, style, layoutOptions))
        {
            TestEditorWindow window = CreateInstance<TestEditorWindow>();
            GUIContent content = new GUIContent();
            content.text = target.GetType().ToString();
            window.titleContent = content;
            string searchPattern = content.text + ".cs";
            string[] filePaths = Directory.GetFiles(Application.dataPath, searchPattern, SearchOption.AllDirectories);
            window.Init(content.text, "", filePaths.First());
        }
    }
}
