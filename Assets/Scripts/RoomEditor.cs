using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Room))]
public class RoomEditor : Editor {
	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update() { }

	protected virtual void OnSceneGUI() {
		/*Room room = (Room) target;

		EditorGUI.BeginChangeCheck();
		Vector3 newTargetPosition = Handles.PositionHandle(room.targetPosition, Quaternion.identity);
		if(EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(room, "Change Look At Target Position");
			room.targetPosition = newTargetPosition;
			room.Update();
		}*/
	}

}