using UnityEngine;
using System.Collections;
using System.IO;

public class Finish : Checkpoint {
	public int maxRounds = 1;
	private int rounds = 1;
	private bool finished = false;
	public RoundTimer roundTimer;
	private float bestTime = 0.0f;



	void OnTriggerEnter(Collider trigger){
		if(trigger.tag == "Player"){
			if(previousCheckpoint.IsPassed()){
				passed = true;
				previousCheckpoint.ResetPassed();
				if(rounds < maxRounds){
					roundTimer.StopTimer();
					if (bestTime > roundTimer.GetTime() || bestTime <= 0.0f){
						bestTime = roundTimer.GetTime ();
						StreamWriter sw = new StreamWriter("records.txt", false);
						sw.WriteLine ("Test: ");
						sw.WriteLine (bestTime.ToString());
						sw.Close();
					}
					Debug.Log ( "Player passed finishline");
					rounds++;
				}else{
					roundTimer.StopTimer();
					if (bestTime > roundTimer.GetTime() || bestTime <= 0.0f){
						bestTime = roundTimer.GetTime ();
						StreamWriter sw = new StreamWriter("records.txt", false);
						sw.WriteLine ("Test: ");
						sw.WriteLine (bestTime.ToString());
						sw.Close();
					}
					Debug.Log ("Player finished!");
					Debug.Log ("Best time is: " + bestTime );
					finished = true;
				}
			}
		}
	}

	void OnGUI(){
		if (finished) {
			GUI.Label(new Rect(400, 400, 400,400), "Player finished!");
			GUI.skin.label.fontSize = 100;
			GUI.contentColor = Color.black;
		}
		GUI.TextArea (new Rect (10, 10, 200, 100), "" + bestTime, 200);
	}
}
