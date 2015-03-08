using UnityEngine;
using System.Collections;

public class Finish : Checkpoint {
	public int maxRounds = 1;
	private int rounds = 1;
	private bool finished = false;
	public RoundTimer roundTimer;

	void OnTriggerEnter(Collider trigger){
		if(trigger.tag == "Player"){
			if(previousCheckpoint.IsPassed()){
				passed = true;
				previousCheckpoint.ResetPassed();
				if(rounds < maxRounds){
					Debug.Log ( "Player passed finishline");
					rounds++;
				}else{
					roundTimer.DisableTimer();
					Debug.Log ("Player finished!");
					finished = true;
				}
			}
		}
	}

	void OnGUI(){
		if (finished) {
			GUI.Label(new Rect(400, 400, 400,400), "Player finished!");
			GUI.skin.label.fontSize = 100;
		}
	}
}
