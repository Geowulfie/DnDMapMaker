using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldChange : MonoBehaviour {
	public Dropdown Maindropdown;
	public SelectedUnit SelectedUnitScript;
	GameObject Panel;
	bool models = true;
	bool Override = false;
	//public Text text;

	void Start () {
		Panel = GameObject.Find("Panel").transform.GetChild(0).gameObject;
		SelectedUnitScript = this.GetComponent<SelectedUnit> ();
		Maindropdown.options.Clear();
		DirectoryInfo Assets = new DirectoryInfo (Application.dataPath+ "/Resources");
		FileInfo[] dir = Assets.GetFiles ("*.*", SearchOption.AllDirectories);
		Maindropdown.options.Add (new Dropdown.OptionData ("Select Models Here"));
		foreach (FileInfo file in dir) {
			if (file.Extension == ".prefab") {
				if (file.Name != "Unit.prefab" && file.Name != "Tile.prefab") {
					string result = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
					Maindropdown.options.Add (new Dropdown.OptionData (result));
				}
			}
		}
		Maindropdown.value = 1;
		Maindropdown.value = 0;
		Maindropdown.onValueChanged.AddListener (ChangeSelected);
	}


	public void ModelsDropdown () {
		Maindropdown.options.Clear();
		DirectoryInfo Assets = new DirectoryInfo (Application.dataPath+ "/Resources");
		FileInfo[] dir = Assets.GetFiles ("*.*", SearchOption.AllDirectories);
		Maindropdown.options.Add (new Dropdown.OptionData ("Select Models Here"));
		foreach (FileInfo file in dir) {
			if (file.Extension == ".prefab") {
				if (file.Name != "Unit.prefab" && file.Name != "Tile.prefab") {
					string result = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
					Maindropdown.options.Add (new Dropdown.OptionData (result));
				}
			}
		}
		Override = true;
		Maindropdown.value = 1;
		Maindropdown.value = 0;
		Override = false;
		models = true;
		Panel.GetComponent<Text> ().text = "Currently Selected: " + SelectedUnitScript.modelText;
	}

	public void TilesDropdown () {
		Maindropdown.options.Clear();
		Maindropdown.options.Add (new Dropdown.OptionData ("Select Tiles Here"));
		//Debug.Log ("uhh");
		//Debug.Log (this.transform.GetComponent<TileTexture> ().AllMaterials);
		DirectoryInfo Assets = new DirectoryInfo (Application.dataPath+ "/Resources/Tiles");
		FileInfo[] dir = Assets.GetFiles ("*.*", SearchOption.AllDirectories);
		//Maindropdown.options.Add (new Dropdown.OptionData ("Select Models Here"));
		foreach (FileInfo file in dir) {
			if (file.Extension == ".prefab") {
				string result = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
				Maindropdown.options.Add (new Dropdown.OptionData (result));
			}
		}
		Override = true;
		Maindropdown.value = 1;
		Maindropdown.value = 0;
		Override = false;
		models = false;
		Panel.GetComponent<Text> ().text = "Currently Selected: " + SelectedUnitScript.tileText;
	}

	void ChangeSelected(int value) {
		//Debug.Log (Maindropdown.options[Maindropdown.value].text);
		//Debug.Log("hmm");
		if (Maindropdown.value == 0 || Override == true) {
			return;
		}
		Debug.Log (Maindropdown.options [Maindropdown.value].text);
		if (models) {
			SelectedUnitScript.modelText = Maindropdown.options [Maindropdown.value].text;
			//Debug.Log ("Model");
			//Debug.Log (SelectedUnitScript.modelText);
			SelectedUnitScript.ChangeDropdown (Maindropdown.options [Maindropdown.value].text);
		} else {
			SelectedUnitScript.tileText = Maindropdown.options [Maindropdown.value].text;
			//Debug.Log ("Tile");
			//Debug.Log (SelectedUnitScript.tileText);
			SelectedUnitScript.ChangeToTile (Maindropdown.options [Maindropdown.value].text);
		}
		//Maindropdown.value = -1;
		//Maindropdown.Select ();
		//Maindropdown.RefreshShownValue ();
	}

	void modelCheck () {

	}
}
