using UnityEngine;
using System.Collections;

public class CarSelector : MonoBehaviour {
	private string selectedCar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectCar(string carName){
		selectedCar = carName;
	}
}
