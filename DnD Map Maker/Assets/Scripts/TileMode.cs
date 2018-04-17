using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMode : MonoBehaviour {

	int minlevel = -4;
	int maxlevel = 4;

	public void ModeOn() {
		int i = minlevel;
		while (i != maxlevel) {
			GameObject[] appear = GameObject.FindGameObjectsWithTag (i.ToString ());
			foreach (GameObject obj in appear) {
				if (obj.name == "Unit(Clone)") {
					CollideOnUnit(obj.transform.GetChild (7).GetChild (0));
				}
			}
			i++;
		}
		this.transform.GetComponent<InputFieldChange> ().TilesDropdown ();
	}

	public void ModeOff() {
		int i = minlevel;
		while (i != maxlevel) {
			GameObject[] appear = GameObject.FindGameObjectsWithTag (i.ToString ());
			foreach (GameObject obj in appear) {
				if (obj.name == "Unit(Clone)") {
					CollideOffUnit(obj.transform.GetChild (7).GetChild (0));
				}
			}
			i++;
		}
		this.transform.GetComponent<InputFieldChange> ().ModelsDropdown ();
	}
		
	void CollideOnUnit (Transform obj) {
		if (obj.gameObject.GetComponent<BoxCollider> () != null) {
			obj.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (obj.gameObject.GetComponent<MeshCollider> () != null) {
			obj.gameObject.GetComponent<MeshCollider> ().enabled = false;
		}
	}

	void CollideOffUnit (Transform obj) {
		if (obj.gameObject.GetComponent<BoxCollider> () != null) {
			obj.gameObject.GetComponent<BoxCollider> ().enabled = true;
		}
		if (obj.gameObject.GetComponent<MeshCollider> () != null) {
			obj.gameObject.GetComponent<MeshCollider> ().enabled = true;
		}
	}
}
