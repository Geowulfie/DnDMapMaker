using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour {

	public Material[] AllMaterials;

	public void TextureChange(GameObject tile, string name) {
		foreach (Material m in AllMaterials) {
			if (m.name == name) {
				//Debug.Log (name);
				tile.AddComponent<MeshRenderer> ();
				tile.GetComponent<MeshRenderer> ().sharedMaterials [0] = m;
				return;
			}
		}
	}
}
