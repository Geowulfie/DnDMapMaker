using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTile : MonoBehaviour {

	GameObject Tile;
	//string Test = "TowerSquareMidOpenHalf";
	//string Test = "TowerSquareRoof";
	GameObject selectText; //Text field indicating selected resource to load
	//string modelText;
	//string tileText = "Grass";
	GameObject temp;

	//private Object[] test;

	// Use this for initialization
	void Start () {
		/*
		selectText = GameObject.Find("Panel").transform.GetChild(0).gameObject;
		int l = GameObject.Find("InputManager").GetComponent<SelectedUnit>().level;
		string txt = selectText.GetComponent<Text> ().text;
		txt = txt.Replace ("Currently Selected: ", "");
		Tile = Resources.Load("Tiles/"+txt) as GameObject;
		//Instantiate
		temp = Instantiate(Tile, new Vector3(0,l*10f,0), Quaternion.identity) as GameObject;*/
	}

	public void Change(string name) {
		selectText.GetComponent<Text> ().text = "Currently Selected: " + name;
		GameObject.Find ("InputManager").GetComponent<SelectedUnit> ().tileText = name;
		Tile = Resources.Load("Tiles/"+name) as GameObject;
		if (Tile == null) {
			return;
		}
		//Instantiate
		Destroy(temp);
		temp = Instantiate(Tile, this.transform.position, Quaternion.identity) as GameObject;
	}
}
