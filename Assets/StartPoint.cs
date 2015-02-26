using UnityEngine;
using System.Collections;

public class StartPoint : Checkpoint {
	private bool started = false;

	void OnTriggerEnter(Collider trigger){
		if (!started) {
			if (trigger.tag == "Player") {
				Debug.Log ("Player start");
				passed = true;
				started = true;
			}
		} else {
			if (trigger.tag == "Player") {
				if (previousCheckpoint.IsPassed ()) {
					passed = true;
					previousCheckpoint.ResetPassed ();
					Debug.Log ("Player passed the start" + trigger.GetInstanceID ());
				}
			}
		}
	}
}
