using UnityEngine;
using System.Collections;

public class enableDisable : MonoBehaviour {

	public bool paused = false;
	public GameObject menu;
	
	void Start() {
		menu.SetActive(false);
	}

	void Update() {
		if (Input.GetButtonUp ("Cancel")) {
			paused = !paused;
		}
		
		if (paused) {
			Time.timeScale = 0;
			menu.SetActive(true);
		} else {
			Time.timeScale = 1;
			menu.SetActive(false);		
		}
	}
}
