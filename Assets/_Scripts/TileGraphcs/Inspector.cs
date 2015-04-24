using UnityEditor;
using UnityEngine;
using System.Collections;

/*
namespace TileGraphics
{
    [CustomEditor(typeof(MapGraphics))]
    public class TileMapEditor : Editor
    {
        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            if (GUILayout.Button("Regenerate"))
            {
                MapGraphics tileMap = (MapGraphics)target;
                tileMap.Initialize();
                tileMap.BuildTexture();
                tileMap.BuildMesh();
            }
        }
    }
}*/