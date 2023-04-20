using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AssemblyGrabber : MonoBehaviour
{
    public static IEnumerable<System.Type> monoBehaviourTypes { get; private set; }
    public static Assembly assembly { get; private set; }
    static AssemblyGrabber()
    {
        assembly = Assembly.Load("Assembly-CSharp");
        monoBehaviourTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(MonoBehaviour)));
    }
}
