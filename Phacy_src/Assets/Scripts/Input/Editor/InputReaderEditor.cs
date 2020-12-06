using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CustomEditor(typeof(InputReader))]
public class InputReaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var targetIr = target as InputReader;
        if(targetIr != null)
        {
            var typeIr = targetIr.GetType();
            var events = typeIr.GetEvents();

            foreach (var ev in events)
            {
                if(GUILayout.Button(ev.Name))
                {
                    //Delegates doesn't support direct access to RaiseMethod, need use backing field
                    //https://stackoverflow.com/questions/14885325/eventinfo-getraisemethod-always-null

                    var m = typeIr.GetMembers();
                    var method = ev.GetRaiseMethod();
                    method?.Invoke(targetIr, null);
                    var backField = typeIr.GetField(ev.Name);
                    var deleg = (backField?.GetValue(targetIr) as UnityAction);
                    deleg?.Invoke();
                }
            }
            
        }
    }
}
