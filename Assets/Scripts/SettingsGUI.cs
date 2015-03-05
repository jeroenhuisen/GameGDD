using UnityEngine;
using System.Collections;

public class SettingsGUI : MonoBehaviour {
	private bool standby = true;
	public MainMenuGUI mainMenu;
	// Use this for initialization
	void Start () {
		standby = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (!standby) {
			int height = Screen.height;
			int width = Screen.width;
			
			if (GUI.Button (new Rect (width / 2 - 125, height / 4, 250, 100), "Player name")) {
				//SelectMap ();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 150, 250, 100), "Something")) {
				//SearchHosts ();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 300, 250, 100), "Return")) {
				ReturnMainMenu ();
			}
		}
	}

	public void Enable(){
		standby = false;
	}

	void ReturnMainMenu(){
		mainMenu.Enable ();
		standby = true;
	}
}
