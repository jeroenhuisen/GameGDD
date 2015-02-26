using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.tag == "Player"){
			Debug.Log("Player passed the finishline" + trigger.GetInstanceID());
		}
	}
}
