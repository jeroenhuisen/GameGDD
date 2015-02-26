using UnityEngine;
using System.Collections;

public class Finish : Checkpoint {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.tag == "Player"){
			if(previousCheckpoint.IsPassed()){
				passed = true;
				Debug.Log("Player finished!" + trigger.GetInstanceID());
			}
		}
	}
}
