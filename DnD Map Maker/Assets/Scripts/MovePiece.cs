using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovePiece : MonoBehaviour {

	public GameObject Left;
	public GameObject Right;
	public GameObject Up;
	public GameObject Down;
	public GameObject selected;
	public GameObject rotateClockwise;
	public GameObject rotateCounterClockwise;
	public GameObject center;
	GameObject Floor;
	bool drag = false;
	public bool dragOverride = false;

	// Use this for initialization
	void Start () {
		Floor = GameObject.Find ("Floor");
	}
	
	// Update is called once per frame
	void Update () {
		if (drag && !dragOverride) {
			if (Input.GetAxis ("Mouse X") == 0 || Input.GetAxis ("Mouse Y") == 0) {
				return;
			}
			if (Input.GetMouseButton (0)) {
				Floor.GetComponent<MeshCollider> ().enabled = true;
				Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit2;
				//Debug.Log ("pls");
				if (Physics.Raycast (ray2, out hit2, Mathf.Infinity, ~8)) {
					//Debug.Log ("hmmmm");
					int x = (int)hit2.point.x/10;
					float y = this.transform.position.y;
					int z = (int)hit2.point.z/10;
					float nx = x;
					float nz = z;
					if (hit2.point.x < 0) {
						nx -= 1f;
					}
					if (hit2.point.z < 0) {
						nz -= 1f;
					}
					transform.position = new Vector3 ((nx * 10), y, (nz * 10));
				}
				return;
			}
			drag = false;
			Floor.GetComponent<MeshCollider> ().enabled = false;
		} 
		
			
		else if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				// the object identified by hit.transform was clicked
				// do whatever you want
				//Debug.Log(hit.point);
				GameObject hitObject = hit.transform.gameObject;
				selected = hitObject;
				if (hit.transform.root.gameObject == this.gameObject) {
					if (Input.GetMouseButton (0)) {
						drag = true;
					}
				}
			}
		}
	}
}
