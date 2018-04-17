using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeViewMode : MonoBehaviour {

	int minlevel = -4;
	int maxlevel = 4;
	int savedLevel;
	string view = "Default";
	public GameObject ViewText;

	//Default: levels above current 
	public void ChangeToDefault (int nlevel) {
		int i = minlevel;
		while (i != maxlevel) {
			if (i <= nlevel) {
				GameObject[] appear = GameObject.FindGameObjectsWithTag (i.ToString ());
				foreach (GameObject obj in appear) {
					if (obj.name == "Unit(Clone)") {
						appearUnit(obj.transform.GetChild (7).GetChild (0));
					} else {
						appearUnit (obj.transform);
					}
				}
			} else if (i > nlevel) {
				GameObject[] disappear = GameObject.FindGameObjectsWithTag (i.ToString ());
				foreach (GameObject obj in disappear) {
					if (obj.name == "Unit(Clone)") {
						disappearUnit(obj.transform.GetChild (7).GetChild (0));
					} else {
						disappearUnit(obj.transform);
					}
				}
			}
			i++;
		}
		view = "Default";
		ViewText.GetComponent<Text> ().text = "View Mode: " + view;
	}

	public void ChangeToIsolate (int nlevel) {
		int i = minlevel;
		while (i != maxlevel) {
			if (i == nlevel) {
				GameObject[] appear = GameObject.FindGameObjectsWithTag (i.ToString ());
				foreach (GameObject obj in appear) {
					if (obj.name == "Unit(Clone)") {
						appearUnit(obj.transform.GetChild (7).GetChild (0));
					} else {
						appearUnit (obj.transform);
					}
				}
			} else if (i != nlevel) {
				GameObject[] disappear = GameObject.FindGameObjectsWithTag (i.ToString ());
				foreach (GameObject obj in disappear) {
					if (obj.name == "Unit(Clone)") {
						disappearUnit(obj.transform.GetChild (7).GetChild (0));
					} else {
						disappearUnit (obj.transform);
					}
				}
			}
			i++;
		}
		view = "Isolate";
		ViewText.GetComponent<Text> ().text = "View Mode: " + view;
	}

	public void ChangeToShowAll (int nlevel) {
		int i = minlevel;
		while (i != maxlevel) {
			GameObject[] appear = GameObject.FindGameObjectsWithTag (i.ToString ());
			foreach (GameObject obj in appear) {
				if (obj.name == "Unit(Clone)") {
					appearUnit(obj.transform.GetChild (7).GetChild (0));
				} else {
					appearUnit (obj.transform);
				}
			}
			i++;
		}
		view = "Show All";
		ViewText.GetComponent<Text> ().text = "View Mode: " + view;
	}

	//For Menu
	public void DisappearAll(int nlevel) {
		int i = minlevel;
		while (i != maxlevel) {
			GameObject[] disappear = GameObject.FindGameObjectsWithTag (i.ToString ());
			foreach (GameObject obj in disappear) {
				if (obj.name == "Unit(Clone)") {
					disappearUnit(obj.transform.GetChild (7).GetChild (0));
				} else {
					disappearUnit (obj.transform);
				}
			}
			i++;
		}
		savedLevel = nlevel;
		//view = "Show All";
		//ViewText.GetComponent<Text> ().text = "View Mode: " + view;
	}


	//For Menu
	public void ReturnMode() {
		if (view == "Default") {
			ChangeToDefault (savedLevel);
			return;
		} else if (view == "Isolate") {
			ChangeToIsolate (savedLevel);
			return;
		} else if (view == "Show All") {
			ChangeToShowAll (savedLevel);
		}
		return;
	}

	//For User inputing, change level
	public void ChangeLevel (int nlevel, int olevel) {
		int level = nlevel;
		int oldLevel = olevel;
		if (view == "Default") {
			if (oldLevel > level) {
				while (oldLevel != level) {
					GameObject[] disappear = GameObject.FindGameObjectsWithTag (oldLevel.ToString ());
					foreach (GameObject obj in disappear) {
						if (obj.name == "Unit(Clone)") {
							disappearUnit (obj.transform.GetChild (7).GetChild (0));
						} else {
							disappearUnit (obj.transform);
						}
					}
					oldLevel--;
				}
			} else {
				while (oldLevel != level) {
					GameObject[] appear = GameObject.FindGameObjectsWithTag (level.ToString ());
					foreach (GameObject obj in appear) {
						if (obj.name == "Unit(Clone)") {
							appearUnit (obj.transform.GetChild (7).GetChild (0));
						} else {
							appearUnit (obj.transform);
						}
					}
					oldLevel++;
				}
			}
		} else if (view == "Isolate") {
			Debug.Log("rats");
			GameObject[] disappear = GameObject.FindGameObjectsWithTag (oldLevel.ToString ());
			foreach (GameObject obj in disappear) {
				if (obj.name == "Unit(Clone)") {
					disappearUnit (obj.transform.GetChild (7).GetChild (0));
				} else {
					disappearUnit (obj.transform);
				}
			}
			GameObject[] appear = GameObject.FindGameObjectsWithTag (level.ToString ());
			foreach (GameObject obj in appear) {
				if (obj.name == "Unit(Clone)") {
					appearUnit (obj.transform.GetChild (7).GetChild (0));
				} else {
					appearUnit (obj.transform);
				}
			}
		}
	}

	void disappearUnit (Transform obj) {
		if (obj.gameObject.GetComponent<BoxCollider> () != null) {
			obj.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (obj.gameObject.GetComponent<MeshCollider> () != null) {
			obj.gameObject.GetComponent<MeshCollider> ().enabled = false;
		}
		if (obj.gameObject.GetComponent<MeshRenderer> () != null) {
			obj.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		}
		if (obj.childCount > 0) {
			foreach (Transform child in obj.transform) {
				child.gameObject.GetComponent<MeshRenderer> ().enabled = false;
				//child.gameObject.GetComponent<MeshCollider> ().enabled = true;
			}
		}
	}

	void appearUnit (Transform obj) {
		if (obj.gameObject.GetComponent<BoxCollider> () != null && this.transform.GetComponent<SelectedUnit>().tiling != true) {
			obj.gameObject.GetComponent<BoxCollider> ().enabled = true;
		}
		if (obj.gameObject.GetComponent<MeshCollider> () != null && this.transform.GetComponent<SelectedUnit>().tiling != true) {
			obj.gameObject.GetComponent<MeshCollider> ().enabled = true;
		}
		if (obj.gameObject.GetComponent<MeshRenderer> () != null) {
			obj.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		}
		if (obj.childCount > 0) {
			foreach (Transform child in obj.transform) {
				child.gameObject.GetComponent<MeshRenderer> ().enabled = true;
				//child.gameObject.GetComponent<MeshCollider> ().enabled = true;
			}
		}
	}
}
