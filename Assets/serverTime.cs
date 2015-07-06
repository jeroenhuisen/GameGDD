using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerTime : MonoBehaviour
{
    public DatabaseHelper dbHelper;
    public Text timeText;
    public GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        // This should be done on the server side  not within the client start up.
        // use RPC, this will be changed.

        string time = dbHelper.getBest(gameManager.getLevel());
        timeText.text = time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateServerTime()
    {
        // This should be done on the server side  not within the client start up.
        // use RPC, this will be changed.

        string time = dbHelper.getBest(gameManager.getLevel());
        timeText.text = time;
    }

}
