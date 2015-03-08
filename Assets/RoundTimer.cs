using UnityEngine;
using System.Collections;

public class RoundTimer : MonoBehaviour {
	private bool timerEnabled = false;
	private float totalTime  = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTimer(){
		timerEnabled = true;
	}
	
	public void DisableTimer(){
		timerEnabled = false;
	}

	public void ResetTimer(){
		totalTime = 0.0f;
	}

	void OnGUI() {
		if (timerEnabled) {
			totalTime += Time.smoothDeltaTime;
		}
		GUILayout.TextArea ("" + totalTime);
	}

}
