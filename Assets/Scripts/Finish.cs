using UnityEngine;
using System.Collections;

public class Finish : Checkpoint {
	public int maxRounds = 1;
	private int rounds = 1;
	void OnTriggerEnter(Collider trigger){
		if(trigger.tag == "Player"){
			if(previousCheckpoint.IsPassed()){
				passed = true;
				previousCheckpoint.ResetPassed();
				if(rounds < maxRounds){
					Debug.Log ( "Player passed finishline");
					rounds++;
				}else{
					Debug.Log ("Player finished!");
				}
			}
		}
	}
}
