using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Serializable]
public class ScriptMethodSelector
{
    public GameObject targetObject;
    public MonoBehaviour selectedScript;
    public string selectedMethod;

    public void InvokeMethod()
    {
        if (selectedScript != null && !string.IsNullOrEmpty(selectedMethod))
        {
            MethodInfo method = selectedScript.GetType().GetMethod(selectedMethod, BindingFlags.Public | BindingFlags.Instance);
            if (method != null)
            {
                method.Invoke(selectedScript, null);
            }
            else
            {
                Debug.LogWarning($"Method {selectedMethod} not found on {selectedScript.GetType().Name}");
            }
        }
    }
}
