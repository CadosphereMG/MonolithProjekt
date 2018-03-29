using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (OceanGenerator))]
public class OceanGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        OceanGenerator oceanGen = (OceanGenerator)target;

        if (DrawDefaultInspector())
        {
            if (oceanGen.autoUpdate)
            {
                oceanGen.GenerateOcean();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            oceanGen.GenerateOcean();
        }
    }
}