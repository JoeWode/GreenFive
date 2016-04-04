using UnityEngine;
using System.Collections;

public class controllerSwitch : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public GameObject HUD1;
	public GameObject HUD2;
	
	void Start () {
		Player1.SetActive(true);
		Player2.SetActive(false);
		HUD1.SetActive(true);
		HUD2.SetActive(false);
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.X)){
			if(Player1.activeSelf == true){
				Player1.SetActive(false);
				Player2.SetActive(true);
				HUD1.SetActive(false);
				HUD2.SetActive(true);
			} else {
				Player1.SetActive(true);
				Player2.SetActive(false);
				HUD1.SetActive(true);
				HUD2.SetActive(false);
			}
		}
	}
}
