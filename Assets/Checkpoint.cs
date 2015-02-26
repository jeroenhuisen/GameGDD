using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public Checkpoint previousCheckpoint;
	protected bool passed = false;
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
				previousCheckpoint.ResetPassed();
				Debug.Log("Player passed the checkpoint" + trigger.GetInstanceID());
			}
		}
	}

	public bool IsPassed(){
		return passed;
	}

	public void ResetPassed(){
		passed = false;
	}
}
