using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
		
		public GameObject InputManager;
		public bool active = true;
		bool Sel = false;

		void Start() {
			InputManager = GameObject.Find ("InputManager");
		}

        // Update is called once per frame
        void Update()
        {
			if (Input.GetMouseButtonDown(0)){ // if left button pressed...
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         		RaycastHit hit;

				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					// the object identified by hit.transform was clicked
					// do whatever you want
					GameObject hitObject = hit.transform.gameObject;
					if (hitObject == this.gameObject.transform.GetChild(7).GetChild(0).gameObject) {
						//GetComponent<Outline> ().enabled = true;
						//GameObject Parent = this.transform.parent.gameObject;
						if (InputManager.GetComponent<SelectedUnit> ().tiling == false) {
							this.GetComponent<MovePiece> ().dragOverride = false;
							active = true;
							Selected ();
							Sel = true;
						} else {
							this.GetComponent<MovePiece> ().dragOverride = true;
						}
					} 
					else {
						//GetComponent<Outline> ().enabled = false;
						//GameObject Parent = this.transform.parent.gameObject;
						InputManager.GetComponent<SelectedUnit> ().Selected = null;
						active = false;
						Selected ();
					}
				} else {
					//GetComponent<Outline> ().enabled = false;
					//GameObject Parent = this.transform.parent.gameObject;
					InputManager.GetComponent<SelectedUnit> ().Selected = null;
					active = false;
					Selected ();
				}
			}
        }

		void LateUpdate() {
			if (Sel) {
				InputManager.GetComponent<SelectedUnit> ().Selected = this.gameObject;
				InputManager.GetComponent<SelectedUnit> ().SelectOverride = this.gameObject;
				InputManager.GetComponent<SelectedUnit> ().level = Int32.Parse(this.tag);
				InputManager.GetComponent<SelectedUnit> ().Floor.transform.position = new Vector3 (5, this.gameObject.transform.position.y, 5);
				Sel = false;
				InputManager.GetComponent<InputFieldChange>().Maindropdown.value = 0;
			}
		}

		public void Selected() {
			this.transform.Find ("Left").gameObject.SetActive(active);
			this.transform.Find ("Right").gameObject.SetActive(active);
			this.transform.Find ("Up").gameObject.SetActive(active);
			this.transform.Find ("Down").gameObject.SetActive(active);
			this.transform.Find ("Rotate1").gameObject.SetActive(active);
			this.transform.Find ("Rotate4").gameObject.SetActive(active);
		}
    }
		
}