using UnityEngine;
using System.Collections;

public class StartPoint : Checkpoint {
	private bool started = false;
	private bool timerEnabled = false;
	public float totalTime = 0.0f;
	public RoundTimer roundTimer;

	void OnTriggerEnter(Collider trigger){
		if (!started) {
			if (trigger.tag == "Player") {
				Debug.Log ("Player start");
				passed = true;
				started = true;
				roundTimer.ResetTimer();
				roundTimer.StartTimer();
			}
		} else {
			if (trigger.tag == "Player") {
				if (previousCheckpoint.IsPassed ()) {
					passed = true;
					previousCheckpoint.ResetPassed ();
					roundTimer.ResetTimer();
					roundTimer.StartTimer();
					Debug.Log ("Player passed the start" + trigger.GetInstanceID ());
				}
			}
		}
	}
	


}
