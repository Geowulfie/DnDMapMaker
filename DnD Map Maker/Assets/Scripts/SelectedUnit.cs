using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnit : MonoBehaviour {

	public GameObject Selected=null;
	public GameObject SelectOverride=null;
	public GameObject Floor;
	//public InputField iField;
	//public Button submit;
	public Button add;
	public Button delete;
	public Button addTiles;
	public string item;
	public bool tiling = false;
	//int layerMask = 9;
	public int level = 0;
	int oldLevel = 0;
	bool ShowAll = false;
	int View = 0;
	GameObject selectText;
	public string modelText = "Bridge"; //DO NOT SET THIS
	public string tileText = "Grass"; //DO NOT SET THIS

	int minlevel = -4;
	int maxlevel = 4;


	// Use this for initialization
	void Start () {
		selectText = GameObject.Find("Panel").transform.GetChild(0).gameObject;
		item = "TowerSquareRoof";
		//submit.onClick.AddListener (Submitted);
		add.onClick.AddListener (Add);
		delete.onClick.AddListener (Delete);
		addTiles.onClick.AddListener (TileSwitch);
	}

	void Update () {

		//Check if level is same
		if (level != oldLevel && !ShowAll) {
			
			this.GetComponent<ChangeViewMode> ().ChangeLevel (level, oldLevel);
			oldLevel = level;
		}

		//Change View Method
		if (Input.GetKeyDown ("0")) {
			View = (View + 1) % 3;
			//Debug.Log (View);
			if (View == 0) {
				this.GetComponent<ChangeViewMode> ().ChangeToDefault (level);
				ShowAll = false;
			} else if (View == 1) {
				this.GetComponent<ChangeViewMode> ().ChangeToIsolate (level);
			} else if (View == 2) {
				this.GetComponent<ChangeViewMode> ().ChangeToShowAll (level);
				ShowAll = true;
			}
		}

		//Extra keyboard controls
		if (Input.GetKeyDown (KeyCode.Insert)) {
			Add ();
		} else if (Input.GetKeyDown (KeyCode.Delete) || Input.GetKeyDown (KeyCode.Backspace)) {
			Delete ();
		}
			
		//Draw Grid or Not
		if (Selected == null && tiling == false) {
			Floor.GetComponent<MeshRenderer> ().enabled = false;
			//return;
		} else {
			Floor.GetComponent<MeshRenderer> ().enabled = true;
		}

		//Place Tiles
		if (tiling) {
			if (Input.GetMouseButton (0) && !Input.GetKey("z")) {
				//Floor.GetComponent<MeshCollider> ().enabled = true;
				Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit2;
				//Debug.Log ("pls");
				//if (Physics.Raycast (ray2, out hit2, Mathf.Infinity, ~8)) {
				if (Physics.Raycast (ray2, out hit2, Mathf.Infinity, ~8)) {
					if (hit2.transform.gameObject.layer == 9) {
						if (hit2.transform.gameObject.layer == 9){
							if (hit2.transform.gameObject.GetComponent<MeshRenderer> ().material.name != tileText) {
								Destroy (hit2.transform.gameObject);
							} else {
								return;
							}
						}
					}
					int x = (int)hit2.point.x / 10;
					int y = (int)hit2.point.y / 10;
					int z = (int)hit2.point.z / 10;
					GameObject temp = Resources.Load ("Tiles/"+tileText) as GameObject;
					temp.tag = level.ToString ();
					float c1, c2;
					if (hit2.point.x >= 0)
						c1 = 5;
					else
						c1 = -5;
					if (hit2.point.z > 0)
						c2 = 5;
					else
						c2 = -5;
					Instantiate (temp, new Vector3 ((x * 10) + c1, (y * 10) + .01f, (z * 10) + c2), Quaternion.identity);
				}
				return;
			} else if (Input.GetMouseButton (0) && Input.GetKey("z")) {
				//Floor.GetComponent<MeshCollider> ().enabled = true;
				Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit2;
				//Debug.Log ("pls");
				//if (Physics.Raycast (ray2, out hit2, Mathf.Infinity, ~8)) {
				if (Physics.Raycast (ray2, out hit2, Mathf.Infinity, ~8)) {
					if (hit2.transform.gameObject.layer == 9) {
						Destroy (hit2.transform.gameObject);
					}
				}
			}
		}
		//Move up and down regardless if selected
		if (Input.GetKeyDown ("g")) {
			if (!(level + 1 > maxlevel)) {
				Floor.transform.position += Vector3.up * 10;
				level++;
				if (Selected != null) {
					Selected.transform.position += Vector3.up * 10;
					Selected.tag = level.ToString ();
				}
			}
		} else if (Input.GetKeyDown ("h")) {
			if (!(level - 1 < minlevel)) {
				Floor.transform.position += Vector3.down * 10;
				level--;
				if (Selected != null) {
					Selected.transform.position += Vector3.down * 10;
					Selected.tag = level.ToString ();
				}
			}
		}

		//Selected Object Move
		if (Selected == null) {
			return;
		}
		if (Input.GetKeyDown ("w")) {
			Selected.transform.position += Vector3.forward * 10;
		} else if (Input.GetKeyDown ("a")) {
			Selected.transform.position += Vector3.left * 10;
		} else if (Input.GetKeyDown ("s")) {
			Selected.transform.position += Vector3.back * 10;
		} else if (Input.GetKeyDown ("d")) {
			Selected.transform.position += Vector3.right * 10;
		} /*else if (Input.GetKeyDown ("g")) {
			if (!(level + 1 > maxlevel)) {
				Selected.transform.position += Vector3.up * 10;
				Floor.transform.position += Vector3.up * 10;
				level++;
				Selected.tag = level.ToString ();
			}
		} else if (Input.GetKeyDown ("h")) {
			if (!(level - 1 < minlevel)) {
				Selected.transform.position += Vector3.down * 10;
				Floor.transform.position += Vector3.down * 10;
				level--;
				Selected.tag = level.ToString ();
			}
		} */else if (Input.GetKeyDown ("q")) {
			foreach (Transform child in Selected.transform)
			{
				if(child.gameObject.tag == "placable")
				{
					GameObject center = Selected.transform.GetChild (6).gameObject;
					child.RotateAround (center.transform.position, center.transform.up, -90);
				}
			}
		} else if (Input.GetKeyDown ("e")) {
			foreach (Transform child in Selected.transform)
			{
				if(child.gameObject.tag == "placable")
				{
					GameObject center = Selected.transform.GetChild (6).gameObject;
					child.RotateAround (center.transform.position, center.transform.up, 90);
				}
			}
		}


		//Place Tiles
	}
	/*	
	void Submitted() {
		if (Selected == null) {
			return;
		}
		item = iField.text;
		Selected.GetComponent<ChangeModel> ().Change (item);
	}*/

	void Add() {
		if (tiling == true) {
			tiling = false;
			ChangeToModel ("");
			transform.GetComponent<TileMode> ().ModeOff();
		}
		GameObject temp = Resources.Load ("Unit") as GameObject;
		temp.tag = level.ToString();
		if (Selected) {
			//Selected.GetComponents<Toggle> ().active;
			Selected.GetComponent<cakeslice.Toggle> ().active = false;
			Selected.GetComponent<cakeslice.Toggle> ().Selected();
		}
		Selected = Instantiate(temp, new Vector3(0,level*10f,0), Quaternion.identity) as GameObject;
		//Floor.transform.position = new Vector3 (5, 0, 5);
		//if (Floor.GetComponent<MeshCollider> ().enabled == false) {
		//	(Floor.GetComponent<MeshCollider> ().enabled = true);
		//}
		SelectOverride = Selected;
		this.gameObject.GetComponent<InputFieldChange> ().Maindropdown.value = 0;
	}

	void Delete() {
		Debug.Log (SelectOverride);
		if (SelectOverride) {
			Destroy (SelectOverride);
			Floor.transform.position = new Vector3 (5, level*10f, 5);
		}
	}

	//Dropdown changes for models (Look at ChangeModel Script and InputFieldChange Script)
	public void ChangeDropdown (string name) {
		if (SelectOverride == null) {
			return;
		}
		modelText = name;
		SelectOverride.GetComponent<ChangeModel> ().Change (name);
		Selected = SelectOverride;
		Selected.GetComponent<cakeslice.Toggle> ().active = true;
		Selected.GetComponent<cakeslice.Toggle> ().Selected();
	}

	//Dropdown changes for tiles (Look at ChangeModel Script and InputFieldChange Script)
	//public void ChangeTile (string name) {
	//	tileText = name;
	//}

	public void TileSwitch () {
		tiling = !tiling;
		Debug.Log (tiling);
		if (tiling) {
			transform.GetComponent<TileMode> ().ModeOn();
			Floor.GetComponent<MeshCollider> ().enabled = true;
			ChangeToTile ("");
		} else {
			transform.GetComponent<TileMode> ().ModeOff();
			Floor.GetComponent<MeshCollider> ().enabled = false;
			ChangeToModel ("");
		}
		Selected = null;
		SelectOverride = null;
	}

	public void ChangeToTile(string name) {
		//Debug.Log ("k");
		if (name == "") {
			//Debug.Log (name);
			selectText.GetComponent<Text> ().text = "Currently Selected: " + tileText;
			//this.transform.GetComponent<InputFieldChange> ().TilesDropdown ();
			return;
		}
		//tileText = name;
		selectText.GetComponent<Text> ().text = "Currently Selected: " + name;
	}

	public void ChangeToModel(string name) {
		if (name == "") {
			//Debug.Log ("foo");
			selectText.GetComponent<Text> ().text = "Currently Selected: " + modelText;
			//Debug.Log (selectText.GetComponent<Text> ().text);
			//this.transform.GetComponent<InputFieldChange> ().ModelsDropdown ();
			return;
		}
		//modelText = name;
		selectText.GetComponent<Text> ().text = "Currently Selected: " + name;

	}
}
