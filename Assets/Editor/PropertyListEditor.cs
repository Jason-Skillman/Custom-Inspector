using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PropertyList))]
public class PropertyListEditor : Editor {
	
	//List of variables as original type
	private int myInt;
	private string myString;

	private void OnEnable() {
		//myInt = serializedObject.FindProperty("myInt");
		//myString = serializedObject.FindProperty("myString");
	}

	public override void OnInspectorGUI() {
		PropertyList myTarget = target as PropertyList;
		
		
		EditorGUI.LabelField(new Rect(150, 10, 
			EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight),"Header", EditorStyles.boldLabel);

		EditorGUI.LabelField(new Rect(30, 10 + EditorGUIUtility.singleLineHeight, 
			100, EditorGUIUtility.singleLineHeight),"My First Int");
		
		myTarget.myInt = EditorGUI.IntField(new Rect(60, 10 + EditorGUIUtility.singleLineHeight * 2, 
			150, EditorGUIUtility.singleLineHeight), myTarget.myInt);
		
		
		GUILayout.Space(60f);
	}

}
