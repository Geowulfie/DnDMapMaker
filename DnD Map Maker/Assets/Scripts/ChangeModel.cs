using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangeModel : MonoBehaviour {

	GameObject Model;
	//string Test = "TowerSquareMidOpenHalf";
	//string Test = "TowerSquareRoof";
	GameObject selectText; //Text field indicating selected resource to load
	//string modelText;
	//string tileText = "Grass";
	GameObject temp;

	//private Object[] test;

	// Use this for initialization
	void Start () {
		selectText = GameObject.Find("Panel").transform.GetChild(0).gameObject;
		int l = GameObject.Find("InputManager").GetComponent<SelectedUnit>().level;
		string txt = selectText.GetComponent<Text> ().text;
		txt = txt.Replace ("Currently Selected: ", "");
		//Debug.Log (txt);
		Model = Resources.Load(txt) as GameObject;
		//Model = Resources.Load("Bridge") as GameObject;
		//Debug.Log (Model);
		//Instantiate
		temp = Instantiate(Model, new Vector3(0,l*10f,0), this.transform.rotation) as GameObject;
		GameObject temp2 = temp.transform.GetChild (0).gameObject;
		temp2.AddComponent<MeshCollider> ();
		temp.tag = "placable";
		temp.transform.parent = this.transform;
		Debug.Log (temp.name);
	}
		
	public void Change(string name) {
		selectText.GetComponent<Text> ().text = "Currently Selected: " + name;
		//Debug.Log (name);
		GameObject.Find ("InputManager").GetComponent<SelectedUnit> ().modelText = name;
		Model = Resources.Load(name) as GameObject;
		if (Model == null) {
			return;
		}
		//Instantiate
		float rotateAmount = temp.transform.rotation.eulerAngles.y;
		Destroy(temp);
		temp = Instantiate(Model, this.transform.position, this.transform.rotation) as GameObject;
		GameObject temp2 = temp.transform.GetChild (0).gameObject;
		temp2.AddComponent<MeshCollider> ();
		temp.tag = "placable";
		temp.transform.parent = this.transform;
		GameObject center = this.transform.GetChild (6).gameObject;
		temp.transform.RotateAround (center.transform.position, center.transform.up, rotateAmount);
	}
}
