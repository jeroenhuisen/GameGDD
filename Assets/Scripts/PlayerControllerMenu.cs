using UnityEngine;
using System.Collections;

public class PlayerControllerMenu : MonoBehaviour {
	private string car;
	private Color carColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	public void setColor(Color color){
		carColor = color;
	}

	public void setCar(string carName){
		car = carName;
	}
}
