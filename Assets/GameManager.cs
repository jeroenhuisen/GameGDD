using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private bool gameIsActive = false;
	private bool gameIsPaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PauseGame(){
		gameIsPaused = true;
	}

	public void ReturnGame(){
		gameIsPaused = false;
	}

	public void StartGame(){
		gameIsActive = true;
	}

	public void StopGame(){
		gameIsActive = false;
	}

	public bool IsActive(){
		return gameIsActive;
	}
}
