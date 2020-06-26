using System;
using UnityEditor;
using UnityEngine;

public class Floor : MonoBehaviour {

	public Mesh Mesh => GetComponent<MeshFilter>().sharedMesh;

	public Material Material => GetComponent<MeshRenderer>().sharedMaterial;

}