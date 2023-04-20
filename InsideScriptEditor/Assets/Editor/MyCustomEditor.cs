using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyCustomEditor<>))]
public class MyCustomEditor<T> : Editor where T : MonoBehaviour
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Custom Button"))
        {
            Debug.Log("Custom button clicked on " + typeof(T).Name);
        }
    }
}
