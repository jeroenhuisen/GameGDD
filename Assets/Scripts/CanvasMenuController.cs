using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMenuController : MonoBehaviour {
	public Canvas colorCanvas;
	public Canvas carCanvas;
	public Canvas networkCanvas;
	public Canvas mapCanvas;
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		EnableMapSelection ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void EnableColorSelection(){
		colorCanvas.enabled = true;
		carCanvas.enabled = false;
		networkCanvas.enabled = false;
		mapCanvas.enabled = false;
	}

	public void EnableCarSelection(){
		carCanvas.enabled = true;
		colorCanvas.enabled = false;
		networkCanvas.enabled = false;
		mapCanvas.enabled = false;
	}

	public void EnableNetworkSettings(){
		carCanvas.enabled = false;
		colorCanvas.enabled = false;
		networkCanvas.enabled = true;
		mapCanvas.enabled = false;
	}

	public void EnableMapSelection(){
		carCanvas.enabled = false;
		colorCanvas.enabled = false;
		networkCanvas.enabled = false;
		mapCanvas.enabled = true;
	}

	public void EnableGame(){
		//add choose level
		gameManager.LoadLevel ("Level"); 
		//gameManager.StartGame ();
	}
	

	public void DisableSelection(){
		colorCanvas.enabled = false;
		carCanvas.enabled = false;
		networkCanvas.enabled = false;
		mapCanvas.enabled = false;
	}
}
