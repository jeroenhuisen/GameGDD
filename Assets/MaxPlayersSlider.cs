using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MaxPlayersSlider : MonoBehaviour {
	public Slider Slider;
	public NetworkManager networkM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnhSliderChanged() {
		networkM.setMaxPlayers((int)Slider.value);
	}
}
