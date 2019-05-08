using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TheFittestMonkey
{
    [CustomEditor(typeof(Main))]
    public class MainEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Main main = (Main)target;

            if (GUILayout.Button("Run"))
            {
                main.Run();
            }
        }
    }
}