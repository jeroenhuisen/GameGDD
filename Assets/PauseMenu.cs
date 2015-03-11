using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool standby = true;
	public MainMenuGUI mainMenu;
	public GameManager game;
	// Use this for initialization
	void Start () {
		standby = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.IsActive()) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				game.PauseGame();
				Enable ();
			} 
		}
	}
	
	void OnGUI(){
		if (!standby) {
			int height = Screen.height;
			int width = Screen.width;
			
			if (GUI.Button (new Rect (width / 2 - 125, height / 4, 250, 100), "Return")) {
				standby = true;
				game.ReturnGame();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 150, 250, 100), "Something")) {
				//SearchHosts ();
			}
			if (GUI.Button (new Rect (width / 2 - 125, height / 4 + 300, 250, 100), "Quit go to Main Menu")) {
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
