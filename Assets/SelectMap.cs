using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectMap : MonoBehaviour {
    public GameManager gManager;
    public Text mapNameButton;

	// Use this for initialization
	void Start () {
        UpdateMapName();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateMapName(){
        mapNameButton.text = gManager.getLevel();
    }
}
