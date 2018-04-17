using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapSave {

	//Each index corresponds to a Unit
	public string[] UnitNames;
	public int[] UnitLevels;
	//public TransformSurrogate[] UnitTransform;
	//public float[] UnitX;
	//public float[] UnitY;
	//public float[] UnitZ;
	//public TransformSurrogate[] ChildTransform;
	//public float[] ChildX;
	//public float[] ChildY;
	//public float[] ChildZ;
	//public float[] QuatX;
	//public float[] QuatY;
	//public float[] QuatZ;

	//Each here represents a tile
	public string[] TileNames;
	public int[] TileLevels;
	//public Vector3Surrogate[] TileTranslate;
	//public float[] TileX;
	//public float[] TileY;
	//public float[] TileZ;
}
