using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Builder))]
public class BuilderEditor : Editor {

	private const int arrowSize = 2;
	private const float CenterOffset = 3f;
	
	private static Mode mode = Mode.Floor;
	private static GameObject prefabFloor;
	private static GameObject prefabWall;
	private static bool enabled = true;
	private static int cachedId;
	
	public Mesh MeshFloor => prefabFloor.GetComponent<MeshFilter>().sharedMesh;
	public Mesh MeshWall => prefabWall.GetComponent<MeshFilter>().sharedMesh;

	private Builder builder;
	private Transform trans;

	private Direction selectedDirection = Direction.None;

	private int leftId, rightId, forwardId, backId;
	private bool cached;

	private enum Direction {
		West,
		East,
		North,
		South,
		None
	}

	public enum Mode {
		Floor,
		Wall,
		Ceiling
	}

	private void OnEnable() {
		builder = target as Builder;
		
		prefabFloor = Resources.Load<GameObject>("WoodFloor");
		prefabWall = Resources.Load<GameObject>("StoneWall");
	}

	private void OnSceneGUI() {
		if(!enabled) return;

		Color color = Handles.preselectionColor;

		if(!cached) {
			trans = ((Builder) target).transform;

			leftId = GUIUtility.GetControlID(FocusType.Passive);
			rightId = GUIUtility.GetControlID(FocusType.Passive);
			forwardId = GUIUtility.GetControlID(FocusType.Passive);
			backId = GUIUtility.GetControlID(FocusType.Passive);

			cached = true;
		}

		if(Event.current.type == EventType.Repaint) {
			
			//Floor
			if(mode == Mode.Floor) {
				//Left
				if(cachedId != rightId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshFloor, trans.position + Vector3.left * 3.0f, Quaternion.identity);
				}
				//Right
				if(cachedId != leftId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshFloor, trans.position + Vector3.right * 3.0f, Quaternion.identity);
				}
				//Forward
				if(cachedId != backId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshFloor, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
				}
				//Back
				if(cachedId != forwardId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshFloor, trans.position + Vector3.back * 3.0f, Quaternion.identity);
				}
			}
			//Wall
			else if(mode == Mode.Wall) {
				//Left
				if(cachedId != leftId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.left * 3.5f + Vector3.up * 0.5f, Quaternion.Euler(0, -90, 0));
				}
				//Right
				if(cachedId != rightId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.right * 0.5f + Vector3.up * 0.5f + Vector3.back * 3.0f, Quaternion.Euler(0, 90, 0));
				}
				//Forward
				if(cachedId != forwardId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.forward * 0.5f + Vector3.up * 0.5f, Quaternion.identity);
				}
				//Back
				if(cachedId != backId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.back * 3.5f + Vector3.left * 3.0f + Vector3.up * 0.5f, Quaternion.Euler(0, 180, 0));
				}
			}

		} else if(Event.current.type == EventType.Layout) {

			//Floor & Wall
			if(mode == Mode.Floor) {
				//Left
				if(cachedId != rightId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(builder.Mesh, trans.position + Vector3.left * 3.0f, Quaternion.identity);

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 4.5f) + (Vector3.back * 1.5f), 1.5f);
					HandleUtility.AddControl(leftId, distance);
				}
				//Right
				if(cachedId != leftId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(builder.Mesh, trans.position + Vector3.right * 3.0f, Quaternion.identity);

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.right * 1.5f) + (Vector3.back * 1.5f), 1.5f);
					HandleUtility.AddControl(rightId, distance);
				}
				//Forward
				if(cachedId != backId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(builder.Mesh, trans.position + Vector3.forward * 3.0f, Quaternion.identity);

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.forward) * 1.5f, 1.5f);
					HandleUtility.AddControl(forwardId, distance);
				}
				//Back
				if(cachedId != forwardId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(builder.Mesh, trans.position + Vector3.forward * 3.0f, Quaternion.identity);

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.back) * 4.5f, 1.5f);
					HandleUtility.AddControl(backId, distance);
				}
			}
			//Wall
			else if(mode == Mode.Wall) {
				//Left
				if(cachedId != leftId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.left * 3.5f + Vector3.up * 0.5f, Quaternion.Euler(0, -90, 0));

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 4.5f) + (Vector3.back * 1.5f), 1.5f);
					HandleUtility.AddControl(leftId, distance);
				}
				//Right
				if(cachedId != rightId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.right * 0.5f + Vector3.up * 0.5f + Vector3.back * 3.0f, Quaternion.Euler(0, 90, 0));

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.right * 1.5f) + (Vector3.back * 1.5f), 1.5f);
					HandleUtility.AddControl(rightId, distance);
				}
				//Forward
				if(cachedId != forwardId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.forward * 0.5f + Vector3.up * 0.5f, Quaternion.identity);

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.forward) * 1.5f, 1.5f);
					HandleUtility.AddControl(forwardId, distance);
				}
				//Back
				if(cachedId != backId) {
					HandlesMaterials.overlayColor.SetColor("_Color", color);
					HandlesMaterials.overlayColor.SetPass(0);
					Graphics.DrawMeshNow(MeshWall, trans.position + Vector3.back * 3.5f + Vector3.left * 3.0f + Vector3.up * 0.5f, Quaternion.Euler(0, 180, 0));

					float distance = HandleUtility.DistanceToCircle(trans.position + (Vector3.left * 1.5f) + (Vector3.back) * 4.5f, 1.5f);
					HandleUtility.AddControl(backId, distance);
				}
			}

		} else if(Event.current.type == EventType.MouseDown) {
			
			//Floor
			if(mode == Mode.Floor) {
				int id = HandleUtility.nearestControl;

				if(id == leftId) {
					cachedId = leftId;

					Builder newBuilder = Instantiate(builder, trans.position + Vector3.left * 3.0f, Quaternion.identity);
					Selection.activeGameObject = newBuilder.gameObject;
				} else if(id == rightId) {
					cachedId = rightId;

					Builder newBuilder = Instantiate(builder, trans.position + Vector3.right * 3.0f, Quaternion.identity);
					Selection.activeGameObject = newBuilder.gameObject;
				} else if(id == forwardId) {
					cachedId = forwardId;

					Builder newBuilder = Instantiate(builder, trans.position + Vector3.forward * 3.0f, Quaternion.identity);
					Selection.activeGameObject = newBuilder.gameObject;
				} else if(id == backId) {
					cachedId = backId;

					Builder newBuilder = Instantiate(builder, trans.position + Vector3.back * 3.0f, Quaternion.identity);
					Selection.activeGameObject = newBuilder.gameObject;
				}
			}
			//Wall
			else if(mode == Mode.Wall) {
				int id = HandleUtility.nearestControl;

				if(id == leftId) {
					cachedId = leftId;

					GameObject newBuilder = Instantiate(prefabWall, trans.position + Vector3.left * 3.5f + Vector3.up * 0.5f, Quaternion.Euler(0, -90, 0));
					//Selection.activeGameObject = newBuilder;
				} else if(id == rightId) {
					cachedId = rightId;

					GameObject newBuilder = Instantiate(prefabWall, trans.position + Vector3.right * 0.5f + Vector3.up * 0.5f + Vector3.back * 3.0f, Quaternion.Euler(0, 90, 0));
					//Selection.activeGameObject = newBuilder;
				} else if(id == forwardId) {
					cachedId = forwardId;

					GameObject newBuilder = Instantiate(prefabWall, trans.position + Vector3.forward * 0.5f + Vector3.up * 0.5f, Quaternion.identity);
					//Selection.activeGameObject = newBuilder;
				} else if(id == backId) {
					cachedId = backId;

					GameObject newBuilder = Instantiate(prefabWall, trans.position + Vector3.back * 3.5f + Vector3.left * 3.0f + Vector3.up * 0.5f, Quaternion.Euler(0, 180, 0));
					//Selection.activeGameObject = newBuilder;
				}
			}
			
		} else if(Event.current.type == EventType.KeyDown) {
			if(Event.current.keyCode == (KeyCode.Escape)) {
				enabled = false;
			}
		}
		
		
	}

	public override void OnInspectorGUI() {
		//References
		GUILayout.Label("References", EditorStyles.boldLabel);

		prefabFloor = (GameObject) EditorGUILayout.ObjectField("Prefab Floor", prefabFloor, typeof(GameObject), false);
		prefabWall = (GameObject) EditorGUILayout.ObjectField("Prefab Wall", prefabWall, typeof(GameObject), false);


		//Enabled
		EditorGUILayout.Space();

		enabled = EditorGUILayout.Toggle("Enable Building", enabled);

		if(!enabled) return;


		//Mode
		EditorGUILayout.Space();
		GUILayout.Label("Mode", EditorStyles.boldLabel);
		GUILayout.Label("Current Mode: " + mode);

		if(GUILayout.Button("Floor")) {
			mode = Mode.Floor;
			cachedId = -1;
		} else if(GUILayout.Button("Wall")) {
			mode = Mode.Wall;
			cachedId = -1;
		}/* else if(GUILayout.Button("Ceiling")) {
			mode = Mode.Ceiling;
			cachedId = -1;
		}*/

	}

}