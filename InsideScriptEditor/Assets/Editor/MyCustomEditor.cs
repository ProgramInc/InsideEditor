using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true), CanEditMultipleObjects]
public class MyCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Edit In Unity"))
        {
            TestEditorWindow window = CreateInstance<TestEditorWindow>();
            GUIContent content = new GUIContent();
            content.text = target.GetType().ToString();
            window.titleContent = content;
            window.Init(content.text, "");
        }
    }
}
