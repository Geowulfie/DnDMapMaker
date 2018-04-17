using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	public float sens = .0001f;

	private float zoomSpeed = 6.0f;

	private Vector3 lastPosition;
	int currCam=1;
	float nx = -35f;
	float ny = 30f;
	float nz = -35f;

	float tx = 0;
	float ty = 0;
	float tz = 0;
	bool scrollLock = false;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (nx, ny, nz);
		this.transform.eulerAngles = new Vector3 (30, 45, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Camera Movement and positions
		if (!scrollLock) {
			float scroll = Input.GetAxis("Mouse ScrollWheel");
			this.gameObject.GetComponent<Camera>().orthographicSize -= scroll * zoomSpeed;
		}

		if (Input.GetMouseButtonDown(1)) {
			lastPosition = Input.mousePosition;
		}
		if (Input.GetMouseButton(1)) {
			Vector3 delta = Input.mousePosition - lastPosition;
			this.transform.Translate (delta.x * sens, delta.y * sens, 0);
			lastPosition = Input.mousePosition;
		}

		if (Input.GetKeyDown ("1")) {
			SelectedCamRotation (1);
		} else if (Input.GetKeyDown ("2")) {
			SelectedCamRotation (2);
		} else if (Input.GetKeyDown ("3")) {
			SelectedCamRotation (3);
		}
	}

	void SelectedCamRotation(int cam) {
		if (currCam == cam) {
			return;
		}
		//Vector3 euler = this.transform.rotation.eulerAngles;
		//Vector3 check = new Vector3(30, y, 0);
		if (currCam == 1) {
			nx = this.transform.position.x;
			ny = this.transform.position.y;
			nz = this.transform.position.z;
		} else if (currCam == 2) {
			nx = -(this.transform.position.z);
			ny = this.transform.position.y;
			nz = this.transform.position.x;
		} else if (currCam == 3) {
			tx = this.transform.position.x;
			ty = this.transform.position.y;
			tz = this.transform.position.z;
		}

		if (cam == 1) {
			this.transform.position = new Vector3 (nx, ny, nz);
			this.transform.eulerAngles = new Vector3 (30, 45, 0);
			currCam = cam;
		}
		if (cam == 2) {
			this.transform.position = new Vector3 (nz, ny, -nx);
			this.transform.eulerAngles = new Vector3 (30, 135, 0);
			currCam = cam;
		} if (cam == 3) {
			this.transform.position = new Vector3 (tx, ty, tz);
			this.transform.eulerAngles = new Vector3 (90, 45, 45);
			currCam = cam;
		}
		//int i = 0;
		//while (euler != check) {
		//	if (Mathf.Abs (euler.y - check.y) <= .01) {
		//		break;
		//	}
		//	else if (euler.y - check.y > 0) {
		//		euler.y = euler.y - 90;
		//		this.transform.RotateAround (Vector3.zero, Vector3.up, -90);
	}
		
	public void Enter() {
		scrollLock = true;
	}

	public void Exit() {
		scrollLock = false;
	}
}
