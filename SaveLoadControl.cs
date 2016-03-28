using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityStandardAssets.Characters.FirstPerson;
using Fungus;

public class SaveLoadControl : MonoBehaviour {

	/*
	This script contains function calls for loading, saving, and returning to the main menu. These functions are meant to be called from UI elemts inside a pause menu.
	The script uses don't destroy on load to give the object it is attacthed to persistence from level to level. In this case it is attatched to the player flowchart
	which contains information related to the player.
	*/
	
	public Flowchart PlayerChart; //Reference to the player flowchart.
	public int health; //Holds the player's health variable as it is either loaded or saved
	public int level; //Holds information about the current level as it is either loaded or saved.
	public GameObject player; //Reference to the FPSController prefab.
	public static SaveLoadControl control; //Reference to this script.
	public float playerX; //Holds the Player's X value as it is either saved or loaded.
	public float playerY; //Holds the Player's Y value as it is either saved or loaded.
	public float playerZ; //Holds the Player's Z value as it is either saved or loaded.
	public Vector3 playerPos; //A Vector3 made of the previous values, reconstructed on load since Vector3's can't be serialized.
	
	void Awake () { //The awake function checks to see if control has been assigned. If it hasn't it sets the current instance of the script as control. If control already exists, it is destroyed. This makes sure that there is only one saveloadcontrol script active in any given scene.
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
		player = GameObject.FindGameObjectWithTag("Player"); //Assigns the FPSController prefab.
	}
	
	public void Save () {
		BinaryFormatter bf = new BinaryFormatter(); //creates a new binary formatter for serializing data.
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"); //Creates a file named playerInfo.dat at the projects persistent data path.
		health = PlayerChart.GetIntegerVariable("Health"); //Extracts the player health value from the player flowchart.
		level = Application.loadedLevel; //Stores the currently loaded level.
		
		playerX = player.transform.position.x; //Stores the player's X value as a float.
		playerY = player.transform.position.y; //Stores the player's Y value as a float.
		playerZ = player.transform.position.z; //Stores the player's Z value as a float.
				
		PlayerData data = new PlayerData(); //Creates a new PlayerData class to store the information to be saved.
		data.health = health; //Stores the health value inside the PlayerData's health value.
		data.level = level; //Stores the current level inside the PlayerData's level value.		
		data.playerX = playerX; //Stores the player's X position inside the PlayerData's X position value.
		data.playerY = playerY; //Stores the player's Y position inside the PlayerData's Y position value.
		data.playerZ = playerZ; //Stores the player's Z position inside the PlayerData's Z position value.
		
		bf.Serialize(file, data); //Serializes and saves the PlayerData class in the playerInfo.dat file.
		file.Close(); //Closes the playerInfo.dat file.
		
		PlayerChart.ExecuteBlock("Saved"); //Executes a fungus block which writes "saved" to a text object in the player HUD
	}
	
	public void Load() {
		
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) { //Checks to see if playerInfo.dat exists, if it does:
			BinaryFormatter bf = new BinaryFormatter(); //Creates a new binary formatter to deserialize data.
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open); //Opens the playerInfo.dat file
			PlayerData data = (PlayerData)bf.Deserialize(file); //Creates a new PlayerData class populated with data deserialized from playerInfo.dat.
			file.Close(); //Closes the file.
			
			level = data.level; //Assigns the level variable the value stored in the PlayerData class.
			health = data.health; //Assigns the health variable the value stored in the PlayerData class.
			playerX = data.playerX; //Assigns the X position the value stored in the PlayerData class.
			playerY = data.playerY; //Assigns the Y position the value stored in the PlayerData class.
			playerZ = data.playerZ; //Assigns the Z position the value stored in the PlayerData class.
			playerPos = new Vector3(playerX, playerY, playerZ); //Creates a new Vector3 from the previous three variables.
			Application.LoadLevel(level); //Loads the level stored in the level variable.			
			PlayerChart.SetIntegerVariable("Health", health); //Sets the health value in the player flowchart to the loaded health value.						
			player.transform.position = new Vector3(playerX, playerY, playerZ); //Sets the players position to the Vector3 created from saved values.
			PlayerChart.ExecuteBlock("LoadPauseOff"); //Executes a fungus block which resets booleans used to control the pause menu.
		}
	}
	
	public void Quit() {
		Application.LoadLevel("Menu"); //Returns the player to the main menu.
	}
}

//The serializable PlayerData class
[Serializable]
class PlayerData {

	public int health;
	public int level;
	public float playerX;
	public float playerY;
	public float playerZ;
}

/*
This script is a W.I.P. There is a lot more information that I will eventually need to store. Things like what weapons and equipment the player has active,
skill points and experience, energy levels for powering devices or augments, ammo counts and other items. This is also where I would store any booleans that
used to determine story branching.
*/