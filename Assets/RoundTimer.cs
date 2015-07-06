using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {
    public Text roundTime;
    public Text bestRoundTime;
    public Text recordTime;
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

    public string convertTimeToString(float time)
    {
        return string.Format("{0:0}:{1:00}.{2:00}",
                     Mathf.Floor(totalTime / 60),//minutes
                     Mathf.Floor(totalTime) % 60,//seconds
                     Mathf.Floor((totalTime * 100) % 100));//miliseconds
    }

	void OnGUI() {
		if (timerEnabled) {
			if (timerRunning) {
				totalTime += Time.smoothDeltaTime;
			}
           
            roundTime.text = convertTimeToString(totalTime);
			//GUILayout.TextArea ("" + totalTime);
		}
	}

}
