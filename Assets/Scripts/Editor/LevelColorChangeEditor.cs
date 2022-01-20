using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(LevelColorChange))]
    public class LevelColorChangeEditor : UnityEditor.Editor {
    
        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            LevelColorChange myScript = (LevelColorChange) target;
            if (GUILayout.Button("Change to Color")) {
                myScript.ChangeColor(0);
            }
            
            if (GUILayout.Button("Change to Monochromatic")) {
                myScript.ChangeColor(1);
            }
        }
    
    }
}