using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	private bool standby = true;
	public SettingsGUI settings;
	public GameManager game;
	// Use this for initialization
	void Start () {
		standby = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (!standby) {
			int height = Screen.height;
			int width = Screen.width;

			if (GUI.Button (new Rect (width / 2 - 125 , height / 4, 250, 100), "Play")) {
				SelectMap ();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 150, 250, 100), "Search Servers")) {
				SearchHosts ();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 300, 250, 100), "Settings")) {
				Settings ();
			}
		}
	}

	public void Enable(){
		standby = false;
	}

	void SelectMap(){
		print("MainMenu -> SelectMap");
		game.StartGame ();
		standby = true;
	}

	void SearchHosts(){
		print ("MainMenu -> searchHosts");
		standby = true;
	}
	void Settings(){
		print ("settings");
		settings.Enable ();
		standby = true;
	}
}
