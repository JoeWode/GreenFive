using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Fungus;
using UnityEngine.UI;

public class menuItemControl : MonoBehaviour {

    /*
    This script controls all the menu functions in GreenFive's menu scene. Rather than write individual bits of code for each menu item,
    I placed everything inside this script, which can then be applied to all menu items, it will activate diffenet functions based on the name
    of the object to which it is attached, as well as some settings made in the editor. The main menu itself is not made using Unity's UI system (the options menu is though).
    Instead each menu item is a mesh with a collider, which allows OnMouseEnter, OnMouseExit, and OnMouseDown functions to be used to interact with them.
    This script allows for loading saved games, starting new games, adjusting graphical options, and exiting the program.
    */
    
    public Flowchart PlayerChart; //GreenFive uses Fungus, and I use a fungus Flowchart to store variables relating to the player. It's referenced here.
    public Material matStart; //Reference to the starting material of the menu item.
    public Material matHighlight; //Referenece to the highlighted material the menu item switches to during an OnMouseEnter event.
    public Renderer rend; // Reference to the menu items Mesh Renderer component.
    public string levelname; //A string value for the name the level to be loaded.
    public int health; //Container for holding data from the save file.
    public int level; //Container for holding data from the save file.
    public float playerX; //Container for holding data from the save file.
    public float playerY; //Container for holding data from the save file.
    public float playerZ; //Container for holding data from the save file.
    public Vector3 playerPos; //A Vector3 made from the previous three values.
    public GameObject player; //Reference to the FPSController.
    public GameObject optionsPanel; //Reference to the options menu's UI panel
    public Image panelImage; //Reference to the image component of the optionsPanel
    public Animator panelAnim; //Reference to the animator component of the optionsPanel
    public GameObject optionsButtons; //Reference to a null object holding the dropdown UI elements in the optionsPanel.
    public Dropdown antiAlias; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public Dropdown vSync; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public Dropdown tripleBuff; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public Dropdown aniso; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public Dropdown resolution; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public Dropdown refresh; //A reference to the dropdown UI element meant to control the mentioned graphical option.
    public int ResX; //A variable for storing resolution settings, used when setting the refresh rate.
    public int ResY; //A variable for storing resolution settings, used when setting the refresh rate.

    void Start () {
        rend = GetComponent<Renderer>(); //Assigns the mesh renderer
        rend.material = matStart; //Assigns the starting material to the mesh renderer.
        player = GameObject.FindGameObjectWithTag("Player"); //Assigns the FPSController by finding it's tag.
        panelAnim = optionsPanel.GetComponent<Animator>(); //Assigns the animator component of the UI panel
        panelImage = optionsPanel.GetComponent<Image>(); //Assigns the image component of the UI panel element.
        optionsButtons.SetActive(false); //Disables the dropdown UI elements in the options menu by shutting off the container.
    }
    
    void Update() { //The update function only watches to see if the fill amount in the image component of the UI panel element is less then 1. It then turns on the dropdown UI container based on this value.
    	if (panelImage.fillAmount < 1.0f) { 
    	    optionsButtons.SetActive(false);
    	} else {
    	    optionsButtons.SetActive(true);
    	}
    }

    void OnMouseEnter() {
        rend.material = matHighlight; //Switches to the "highlighted" material if you mouse over a menu item.
    }

    void OnMouseExit()
    {
        rend.material = matStart; //Switches materials back to the starting material if the mouse is no longer over the menu item.
    }

    void OnMouseDown() { //If the menu item is clicked it will then perform functions according to how it is named in the hierarchy.
        if (gameObject.name == "New_Game")
        {
            Application.LoadLevel(levelname); //Loads the level entered as a string value in the editor.
        }

        if (gameObject.name == "Exit")
        {
            Application.Quit(); //Closes the application.
        }

        if (gameObject.name == "Continue")
        {
	    Load(); //Initiates the load function.
        }

        if (gameObject.name == "Options")
        {
	    panelAnim.SetBool("isActive", true); //This controls an animation which adjusts the fill value in the UI panel's Image component. This in turn controls the container for the UI dropdown elements.
        }
    }
    
    void Load() { //Loads and assigns data from a serialzed save file.	
    	if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) { //If it exists.
			BinaryFormatter bf = new BinaryFormatter(); //Creates a new binary formatter for serializing and deserializing data.
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open); //Opens the save file.
			PlayerData data = (PlayerData)bf.Deserialize(file); //Creates a new PlayerData class and populates it with the deserialized data from the save file.
			file.Close(); //Closes the save file.
			
			level = data.level; //Holds the current level from the saved file.
			health = data.health; //Holds the player's health value from the save file.
			playerX = data.playerX; //Holds the player's X position from the save file.
			playerY = data.playerY; //Holds the player's Y position from the save file.
			playerZ = data.playerZ; //Holds the player's Z position from the save file.
			playerPos = new Vector3(playerX, playerY, playerZ); //Creates a new Vector3 based on the previous three values. Vector3's aren't serializable so this is how the player's positions is stored and recreated.
			Application.LoadLevel(level); //Loads the level assigned by the save file.			
			PlayerChart.SetIntegerVariable("Health", health); //Sets the player health variable in the player's Fungus Flowchart.						
			player.transform.position = new Vector3(playerX, playerY, playerZ); //Sets the player's position to the new Vector3 constructed from saved float values.	
    	}
    }
    
    /*
    The following functions are triggered using the dropdown UI elements in the options menu. This section is not complete, and will contain more options in the future.
    This data will also be saved to a serialized file so these options can be loaded and adjusted in game.
    */
    
    public void BackButton() {
    	panelAnim.SetBool("isActive", false);
    }
    
    public void AA() {
    	if (antiAlias.value == 0) {
    	    QualitySettings.antiAliasing = 0;
    	} else if (antiAlias.value == 1){
    	    QualitySettings.antiAliasing = 2;
    	} else if (antiAlias.value == 2){
    	    QualitySettings.antiAliasing = 4;
    	} else if (antiAlias.value == 3){
    	    QualitySettings.antiAliasing = 8;
    	}
    }
    
    public void TripleBuff() {
    	if (tripleBuff.value == 0){
    	    QualitySettings.maxQueuedFrames = 3;
    	} else if (tripleBuff.value == 1){
    	    QualitySettings.maxQueuedFrames = 0;
    	}
    }
    
    public void Aniso() {
    	if(aniso.value == 0){
    	    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
    	} else if (aniso.value == 1){
    	    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
    	}
    }
    
    public void Vsync() {
    	if(vSync.value == 0){
    	    QualitySettings.vSyncCount = 1;
    	} else if (vSync.value == 1){
    	    QualitySettings.vSyncCount = 0;
    	}
    }
    
    public void Resolution() {
    	if (resolution.value == 0){
    	    Screen.SetResolution(640, 480, true);
            ResX = 640;
            ResY = 480;	
    	} else if (resolution.value == 1){
    	    Screen.SetResolution(1080, 720, true);
	    ResX = 1080;
            ResY = 720;
    	} else if (resolution.value == 2){
    	    Screen.SetResolution(1920, 1080, true);
	    ResX = 1920;
            ResY = 1080;
    	}
    }
    
    public void Refresh(){
    	if(refresh.value == 0){
    	    Screen.SetResolution(ResX, ResY, true, 60);
    	} else if (refresh.value == 1){
    	    Screen.SetResolution(ResX, ResY, true, 120);
    	}
    }
}
