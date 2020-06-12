using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Treasure))]
public class TreasureEditor : Editor {

	public override void OnInspectorGUI() {
		if(GUILayout.Button("Open Editor")) {
			TreasureWindow.Open((Treasure)target);
		}
	}

}