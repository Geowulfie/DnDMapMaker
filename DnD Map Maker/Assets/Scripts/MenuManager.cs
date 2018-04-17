using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject UICanvas;
	public GameObject MenuCanvas;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			TogglePauseMenu ();
		}
	}

	public void TogglePauseMenu()
	{
		// Menu Off
		if (MenuCanvas.GetComponent<Canvas>().enabled)
		{
			MenuCanvas.GetComponent<Canvas>().enabled = false;
			this.GetComponent<ChangeViewMode> ().ReturnMode ();


			UICanvas.GetComponent<Canvas>().enabled = true;
			this.GetComponent<SelectedUnit> ().enabled = true;
			Time.timeScale = 1.0f;
		}
		//Menu On
		else
		{
			MenuCanvas.GetComponent<Canvas>().enabled = true;
			this.GetComponent<ChangeViewMode> ().DisappearAll (this.GetComponent < SelectedUnit>().level);


			UICanvas.GetComponent<Canvas>().enabled = false;
			this.GetComponent<SelectedUnit> ().enabled = false;
			Time.timeScale = 0f;
		}

		Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
	}
}
