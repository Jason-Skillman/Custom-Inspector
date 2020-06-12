using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Treasure", menuName = "Scriptable Objects/Treasure")]
public class Treasure : ScriptableObject {

	[SerializeField]
	public List<TreasureGroup> listData;

}

[Serializable]
public class TreasureGroup {
	public Sprite sprite;
	public string name;
	public string description;
	public int goldAmount;
}