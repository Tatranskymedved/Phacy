using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

[CustomEditor(typeof(InputReader))]
public class InputReaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(!Application.isPlaying) return;

        ScriptableObjectHelper.GenerateButtonsForEvents<InputReader>(target);
    }
}
