using System;
using UnityEditor;
using UnityEngine;

public class TreasureWindow : ExtendedEditorWindow {

	public static void Open(Treasure data) {
		TreasureWindow window = GetWindow<TreasureWindow>("Treasure Editor");
		window.serializedObject = new SerializedObject(data);
	}

	private void OnGUI() {
		currentProperty = serializedObject.FindProperty("listData");	
		DrawProperties(currentProperty, true);
	}

}