﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private bool gameIsActive = false;
	private bool gameIsPaused = false;
	private string levelName = "Level1UI";
    private string playerName = "defaultPlayerName";
    private string carName = "car";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
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

	public bool IsPaused(){
		return gameIsPaused;
	}

	public void setLevel(string name){
		levelName = name;
	}

    public string getLevel()
    {
        return levelName;
    }

    public void setPlayerName(string name)
    {
        playerName = name;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public void setCarName(string name)
    {
        carName = name;
    }

    public string getCarName()
    {
        return carName;
    }

	public void LoadLevel(){
		if (!gameIsActive) {
			print (levelName);
			Application.LoadLevel (levelName);
			StartGame ();
		}
	}

	public void LoadLevel(string name){
		if (!gameIsActive) {
			Application.LoadLevel (name);
		}
	}
}
