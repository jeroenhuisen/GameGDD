using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RacePosition : MonoBehaviour {
    List<Player> playerList;
	// Use this for initialization
	void Start () {
        playerList = new List<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	    //checkPosition
        foreach (Player player in playerList)
        {
            // Wrong this should be fixed
            Player comparePlayer = new Player();
            // Check lap
            if (player.CurrentLap > comparePlayer.CurrentLap)
            {
                // player is faster than comparePlayer
            }
            else if (player.CurrentLap < comparePlayer.CurrentLap)
            {
                // player is slower than comparePlayer
            }
            else
            {
                // same lap check checkpoints
                if (player.CurrentCheckpoint > comparePlayer.CurrentCheckpoint)
                {
                    // player is atleast a checkpoint further player is faster than comparePlayer
                }
                else if (player.CurrentCheckpoint < comparePlayer.CurrentCheckpoint)
                {
                    // player is atleast a checkpoint behind comparePlayer
                }
                else
                {
                    // same checkpoint check distance to next checkpoint
                    if (player.DistanceToNextCheckpoint < comparePlayer.DistanceToNextCheckpoint)
                    {
                        // distance is smaller so player is faster.
                    }else{
                        // distance is bigger or equal, player is slower 
                    }
                }
          
        }
	}

    public void AddPlayer(Player player)
    {
        if (!playerList.Contains(player))
        {
            playerList.Add(player);
        }
    }

    public int GetAmountOfPlayers()
    {
        return playerList.Count;
    }
}
