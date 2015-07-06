using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public Checkpoint previousCheckpoint;
    public Text checkpointCounter;
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
                int checkpointNumber = int.Parse(checkpointCounter.text);
                checkpointNumber += 1;
                checkpointCounter.text = checkpointNumber.ToString();
                Debug.Log("Player passed checkpoint: " + checkpointNumber);
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
