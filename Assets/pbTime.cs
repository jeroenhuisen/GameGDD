using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pbTime : MonoBehaviour {
    public DatabaseHelper dbHelper;
    public Text timeText;
    public GameManager gameManager;
	// Use this for initialization
	void Start () {
        string time = dbHelper.getPersonalBest(gameManager.getLevel(), gameManager.getPlayerName());
        timeText.text = time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updatePersonalBest()
    {
        // Use the database to be sure the personal best record is received.
        string time = dbHelper.getPersonalBest(gameManager.getLevel(), gameManager.getPlayerName());
        timeText.text = time;
    }
}
