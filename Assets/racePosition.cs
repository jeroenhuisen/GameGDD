using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class racePosition : MonoBehaviour {
    List<Player> playerList;
	// Use this for initialization
	void Start () {
        playerList = new List<player>();
	}
	
	// Update is called once per frame
	void Update () {
	    //checkPosition
        foreach (Player player in playerList)
        {

        }
	}

    public void addPlayer(Player player)
    {
        if (!playerList.Contains(player))
        {
            playerList.Add(player);
        }
    }
}
