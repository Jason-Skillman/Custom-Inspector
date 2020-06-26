using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Floor))]
public class FloorEditor : Editor {
	
	private Floor floor;
	private Transform trans;
	
	private const int arrowSize = 2;
	private const float CenterOffset = 3f;
	
	private int leftId, rightId, forwardId, backId;
	
	private bool cached = false;

	/*private enum Direction {
		Forward = 0,
		Back,
		Right,
		Left,
		None
	}*/
	
	private enum Direction {
		West,
		East,
		North,
		South,
		None
	}
	
	private Direction selectedDirection = Direction.None;

	private void OnEnable() {
		floor = target as Floor;
	}

	private void OnSceneGUI() {
		Color color = Handles.preselectionColor;

		if(!cached) {
			trans = ((Floor)target).transform;
			
			leftId = GUIUtility.GetControlID(FocusType.Passive);
            rightId = GUIUtility.GetControlID(FocusType.Passive);
            forwardId = GUIUtility.GetControlID(FocusType.Passive);
            backId = GUIUtility.GetControlID(FocusType.Passive);
            
            cached = true;
		}
		
		if(Event.current.type == EventType.Repaint) {
			
			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.left * 3.0f, Quaternion.identity);
			}

			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.right * 3.0f, Quaternion.identity);
			}

			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
			}

			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.back * 3.0f, Quaternion.identity);
			}
			
		} else if(Event.current.type == EventType.Layout) {
			
			//Left
			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.left * 3.0f, Quaternion.identity);
				
				float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 4.5f) + (Vector3.back * 1.5f), 1.5f);
				HandleUtility.AddControl(leftId, distance);
			}

			//Right
			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.right * 3.0f, Quaternion.identity);
				
				float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.right * 1.5f) + (Vector3.back * 1.5f), 1.5f);
				HandleUtility.AddControl(rightId, distance);
			}

			//Forward
			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
				
				float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.forward) * 1.5f, 1.5f);
				HandleUtility.AddControl(forwardId, distance);
			}
			
			//Back
			{
				HandlesMaterials.overlayColor.SetColor("_Color", color);
				HandlesMaterials.overlayColor.SetPass(0);
			
				Graphics.DrawMeshNow(floor.Mesh, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
				
				float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.back) * 4.5f, 1.5f);
				HandleUtility.AddControl(backId, distance);
			}
			
		} else if(Event.current.type == EventType.MouseDown) {
			int id = HandleUtility.nearestControl;
			
			if (id == leftId) {
				//Debug.Log("0");

				Floor newFloor = Instantiate(floor, trans.position + Vector3.left * 3.0f, Quaternion.identity);
				Selection.activeGameObject = newFloor.gameObject;
				//PrefabUtility.InstantiatePrefab()
			}
			else if (id == rightId) {
				//Debug.Log("1");
				
				Floor newFloor = Instantiate(floor, trans.position + Vector3.right * 3.0f, Quaternion.identity);
				Selection.activeGameObject = newFloor.gameObject;
			}
			else if (id == forwardId) {
				//Debug.Log("2");
				
				Floor newFloor = Instantiate(floor, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
				Selection.activeGameObject = newFloor.gameObject;
			}
			else if (id == backId) {
				//Debug.Log("3");
				
				Floor newFloor = Instantiate(floor, trans.position + Vector3.back * 3.0f, Quaternion.identity);
				Selection.activeGameObject = newFloor.gameObject;
			}
		}
	}

}