using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PropertyListSerialized))]
public class PropertyListSerializedEditor : Editor {
	
	//List of variables as SerializedProperties
	private SerializedProperty myInt, myString;

	private void OnEnable() {
		//Find and cache the variable
		myInt = serializedObject.FindProperty("myInt");
		myString = serializedObject.FindProperty("myString");
	}

	public override void OnInspectorGUI() {
		//Start
		serializedObject.Update();

		//Draw the fields
		EditorGUILayout.LabelField("Header", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(myInt);
		EditorGUILayout.PropertyField(myString);

		//End
		serializedObject.ApplyModifiedProperties();
	}

}