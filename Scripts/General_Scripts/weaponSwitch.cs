using UnityEngine;
using System.Collections;

public class weaponSwitch : MonoBehaviour {

	/*
	This script allows the player to use the mouse wheel to scroll through a pre-defined set of weapons. Pressing the corresponding number
	key will also equip/dequip the weapon. Just drop the weapon objects into the appropriate fields in the editor.
	*/
	
	public GameObject Weapon01;
	public GameObject Weapon02;
	public GameObject Weapon03;
	
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			SwapWeaponUp();
		}
		
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			SwapWeaponDown();
		}
		
		if (Input.GetKeyUp(KeyCode.Alpha1)) {
			SlotOneToggle();
		}			
		
		if (Input.GetKeyUp(KeyCode.Alpha2)) {
			SlotTwoToggle();
		}
		
		if (Input.GetKeyUp(KeyCode.Alpha3)) {
			SlotThreeToggle();
		}
		
	}

	void SwapWeaponUp() {
		if (Weapon01.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (true);
			Weapon03.SetActive (false);
		} else if (Weapon02.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (false);
			Weapon03.SetActive (true);
		} else {
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);
			Weapon03.SetActive (false);
		}
	}

	void SwapWeaponDown() {
		if (Weapon01.activeSelf == true) {
			Weapon01.SetActive (false);
			Weapon02.SetActive (false);
			Weapon03.SetActive (true);
		} else if (Weapon02.activeSelf == true) {
			Weapon01.SetActive (true);
			Weapon02.SetActive (false);
			Weapon03.SetActive (false);
		} else {
			Weapon01.SetActive (false);
			Weapon02.SetActive (true);
			Weapon03.SetActive (false);
		}
	}
	
	void SlotOneToggle() {
		if (Weapon01.activeSelf == true) {
			Weapon01.SetActive(false);
			Weapon02.SetActive(false);
			Weapon03.SetActive(false);
		} else {
			Weapon01.SetActive(true);
			Weapon02.SetActive(false);
			Weapon03.SetActive(false);
		}
	}
	
	void SlotTwoToggle() {
		if (Weapon02.activeSelf == true) {
			Weapon02.SetActive(false);
			Weapon01.SetActive(false);
			Weapon03.SetActive(false);
		} else {
			Weapon02.SetActive(true);
			Weapon01.SetActive(false);
			Weapon03.SetActive(false);
		}
	}
	
	void SlotThreeToggle() {
		if (Weapon03.activeSelf == true) {
			Weapon03.SetActive(false);
			Weapon02.SetActive(false);
			Weapon01.SetActive(false);
		} else {
			Weapon03.SetActive(true);
			Weapon02.SetActive(false);
			Weapon01.SetActive(false);
		}
	}
}
