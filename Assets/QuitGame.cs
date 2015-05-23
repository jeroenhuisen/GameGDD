using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Quit(){
#if UNITY_EDITOR
		//set PlayMode to stop
#else
		Application.Quit ();
#endif
		Application.Quit ();
		Debug.Log( "quit");
	}
}
