using UnityEngine;
using System.Collections;

public class StartPoint : Checkpoint {
	void Start(){
		previousCheckpoint = this;
	}

	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "Player") {
			Debug.Log ( "Player start");
			passed = true;
		}
	}
}
