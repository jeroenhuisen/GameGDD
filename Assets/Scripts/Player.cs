using UnityEngine;
using System.Collections;
class Player{
    private string playerName;
    private string carName;
    private int currentCheckpoint;
    private int currentLap;
    private float distanceToNextCheckpoint;

    public Player()
    {
        playerName = "";
        carName = "";
        currentCheckpoint = 0;
        currentLap = 0;
        distanceToNextCheckpoint = 0.0f;
    }
    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public string CarName
    {
        get
        {
            return carName;
        }
        set
        {
            carName = value;
        }
    }
    public float DistanceToNextCheckpoint
    {
        get
        {
            return distanceToNextCheckpoint;
        }
        set
        {
            distanceToNextCheckpoint = value;
        }
    } 
    public int CurrentCheckpoint
    {
        get
        {
            return currentCheckpoint;
        }
    }

    public void ResetCheckpoint()
    {
        currentCheckpoint = 0;
    }
    public void NextCheckpoint()
    {
        currentCheckpoint++;
    }

    public int CurrentLap
    {
        get
        {
            return currentLap;
        }
    }

    public void NextLap()
    {
        ResetCheckpoint();
        currentLap++;
    }
}
