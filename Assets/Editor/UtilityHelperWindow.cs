using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class UtilityHelperWindow : EditorWindow {

	private PanelType panelType;

	private int xAmount = 2, zAmount = 2;
	private float xOffset = 1f, zOffset = 1f;

	private bool focus;

	private GameObject objectToDrop;

	private enum PanelType {
		Duplication,
		FocusMode,
		DropDown
	}

	[MenuItem("Window/Utility Helper")]
	public static void ShowWindow() {
		GetWindow<UtilityHelperWindow>("Utility Helper");
	}
	
	private void OnDisable() {
		focus = false;
	}

	private void Update() {
		if(focus) {
			SceneView.lastActiveSceneView.LookAt(Selection.activeGameObject.transform.position);
		}
	}

	private void OnGUI() {
		EditorGUILayout.BeginHorizontal();
		
		//Side panel
		EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true),
			GUILayout.MaxWidth(150));
		
		GUILayout.Label("Utilities");
		if(GUILayout.Button("Duplication")) {
			panelType = PanelType.Duplication;
			GUI.FocusControl(null);
		} else if(GUILayout.Button("Focus Mode")) {
			panelType = PanelType.FocusMode;
			GUI.FocusControl(null);
		} else if(GUILayout.Button("Drop Down")) {
			panelType = PanelType.DropDown;
			GUI.FocusControl(null);
		}
		
		EditorGUILayout.EndVertical();
		
		
		//Main panel
		EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
		
		if(panelType == PanelType.Duplication) {
			GUIDuplication();
		} else if(panelType == PanelType.FocusMode) {
			GUIFocus();
		} else if(panelType == PanelType.DropDown) {
			GUIDropDown();
		}
		
		EditorGUILayout.EndVertical();
		
		EditorGUILayout.EndHorizontal();
	}

	private void GUIDuplication() {
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
	
	private void GUIFocus() {
		GUILayout.Label("Focus", EditorStyles.boldLabel);

		focus = EditorGUILayout.Toggle("Focus Mode", focus);
		
		if(focus)
			EditorGUILayout.HelpBox("Dont forget to turn off focus mode", MessageType.Info);
	}

	private void GUIDropDown() {
		GUILayout.Label("Drop Down", EditorStyles.boldLabel);
		
		objectToDrop = EditorGUILayout.PropertyField(obje)

		if(GUILayout.Button("Drop")) {
			foreach(GameObject selectedObj in Selection.gameObjects) {
				Debug.Log(selectedObj.name);
			}
		}
	}
}