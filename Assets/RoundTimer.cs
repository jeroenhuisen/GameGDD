using UnityEngine;
using System.Collections;

public class RoundTimer : MonoBehaviour {
	private bool timerEnabled = false;
	private bool timerRunning = false;
	private float totalTime  = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTimer(){
		timerRunning = true;
	}
	public void StopTimer(){
		timerRunning = false;
	}

	public void EnableTimer(){
		timerEnabled = true;
	}

	public void DisableTimer(){
		timerEnabled = false;
	}

	public void ResetTimer(){
		totalTime = 0.0f;
	}

	public float GetTime(){
		return totalTime;
	}

	void OnGUI() {
		if (timerEnabled) {
			if (timerRunning) {
				totalTime += Time.smoothDeltaTime;
			}
			GUILayout.TextArea ("" + totalTime);
		}
	}

}
