using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMenuController : MonoBehaviour {
	public Canvas colorCanvas;
	public Canvas carCanvas;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		carCanvas.enabled = true;
		colorCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void EnableColorSelection(){
		colorCanvas.enabled = true;
		carCanvas.enabled = false;
	}

	public void EnableCarSelection(){
		carCanvas.enabled = true;
		colorCanvas.enabled = false;
	}

	public void EnableGame(){
		//add choose level
		gameManager.LoadLevel ("Level"); 
		gameManager.StartGame ();
	}
}
