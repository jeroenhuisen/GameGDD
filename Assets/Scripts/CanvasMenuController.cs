using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMenuController : MonoBehaviour {
	public Image colorPanel;
	public Image carPanel;
	// Use this for initialization
	void Start () {
		carPanel.enabled = true;
		colorPanel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void EnableColorSelection(){
		colorPanel.enabled = true;
		carPanel.enabled = false;
	}

	public void EnableCarSelection(){
		carPanel.enabled = true;
		colorPanel.enabled = false;
	}
}
