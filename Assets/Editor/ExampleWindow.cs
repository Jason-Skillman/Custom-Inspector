using System;
using UnityEditor;
using UnityEngine;

public class ExampleWindow : EditorWindow {

	private string myString;

	private int xAmount = 2, zAmount = 2;
	private float xOffset = 1f, zOffset = 1f;

	[MenuItem("Window/Example")]
	public static void ShowWindow() {
		GetWindow<ExampleWindow>("Example");
	}

	private void OnGUI() {
		GUILayout.Label("General Title", EditorStyles.boldLabel);

		myString = EditorGUILayout.TextField("Name", myString);

		if(GUILayout.Button("Submit")) {
			Debug.Log("Button was pressed");
		}
		
		
		
		EditorGUILayout.Space();
		GUILayout.Label("Duplication", EditorStyles.boldLabel);
		
		xAmount = EditorGUILayout.IntField("X Amount", xAmount);
		zAmount = EditorGUILayout.IntField("Z Amount", zAmount);
		xOffset = EditorGUILayout.FloatField("X Offset", xOffset);
		zOffset = EditorGUILayout.FloatField("Z Offset", zOffset);
		
		if(GUILayout.Button("Duplicate")) {

			//Loop through all of the selected game objects
			foreach(GameObject obj in Selection.gameObjects) {

				for(int z = 0; z < zAmount; z++) {
					for(int x = 0; x < xAmount; x++) {
						
						//Skip the very first instantiate
						if(x == 0 && z == 0) continue;
					
						Vector3 pos = new Vector3(obj.transform.position.x + (x * xOffset),
							obj.transform.position.y,
							obj.transform.position.z + (z * zOffset));
				
						GameObject newObj = Instantiate(obj, pos, Quaternion.identity);
						
					}
				}
				
				
			}

		}
	}

}