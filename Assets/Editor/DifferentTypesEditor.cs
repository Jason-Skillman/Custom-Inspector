using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DifferentTypes))]
public class DifferentTypesEditor : Editor {
		
	private SerializedProperty myInt, myString, myIntSlider, object1, object2, object3;

	private bool foldoutObjects;
	private float knobValue;

	public enum EditorMode {
		Playing,
		Paused,
		MainMenu,
		CutScene
	}

	private void OnEnable() {
		myInt = serializedObject.FindProperty("myInt");
		myString = serializedObject.FindProperty("myString");
		myIntSlider = serializedObject.FindProperty("myIntSlider");
		object1 = serializedObject.FindProperty("object1");
		object2 = serializedObject.FindProperty("object2");
		object3 = serializedObject.FindProperty("object3");
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();

		//Simple properties
		EditorGUILayout.LabelField("Variables", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(myInt);
		EditorGUILayout.PropertyField(myString);
		
		//Slider
		EditorGUILayout.Slider(myIntSlider, 0, 100);
		
		
		//Foldout
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Foldout", EditorStyles.boldLabel);

		foldoutObjects = EditorGUILayout.Foldout(foldoutObjects, "Objects Foldout");
		if(foldoutObjects) {
			EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField(object1);
			EditorGUILayout.PropertyField(object2);
			EditorGUILayout.PropertyField(object3);
			EditorGUI.indentLevel--;
		}
		
		
		//Knob
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Knob", EditorStyles.boldLabel);
		knobValue = EditorGUILayout.Knob(new Vector2(60, 60), knobValue, 0, 360, "degrees", Color.white, Color.blue, true);
		knobValue = EditorGUILayout.Slider(knobValue, 0, 360);
		
		
		//Enum popup
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Enum Popup", EditorStyles.boldLabel);
		EditorGUILayout.EnumPopup("Mode", EditorMode.Playing);
		
		
		//Info box
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Info Box", EditorStyles.boldLabel);
		EditorGUILayout.HelpBox("This is a info help box", MessageType.Info);
		EditorGUILayout.HelpBox("This is a warning help box", MessageType.Warning);
		EditorGUILayout.HelpBox("This is an error help box", MessageType.Error);

		serializedObject.ApplyModifiedProperties();
	}
	
}