using System;
using UnityEditor;
using UnityEngine;

public class Builder : MonoBehaviour {

	public Mesh Mesh => GetComponent<MeshFilter>().sharedMesh;

	public Material Material => GetComponent<MeshRenderer>().sharedMaterial;

}