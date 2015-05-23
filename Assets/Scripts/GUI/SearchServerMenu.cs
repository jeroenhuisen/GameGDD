using UnityEngine;
using System.Collections;

public class SearchServerMenu : MonoBehaviour {
    public NetworkManager networkManager;
    public Transform serverPanel;
    public GameObject sampleServerButton;
    private HostData[] hostList = null;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Enable()
    {
        hostList = networkManager.GetHostList();
        if (hostList == null)
        {
            // No servers online
        }
        else
        {
            for (int i = 0; i < hostList.Length; i++)
            {
                GameObject newServerButton = Instantiate(sampleServerButton) as GameObject;

                SampleServerButton newSampleServerButton = newServerButton.GetComponent<SampleServerButton>();
                newSampleServerButton.serverName.text = hostList[i].gameName;
                newSampleServerButton.mapName.text = hostList[i].gameType;
                newSampleServerButton.amountOfPlayers.text = "Players: " + hostList[i].connectedPlayers + "/" + hostList[i].playerLimit;
                newSampleServerButton.ping.text = "999";
                newServerButton.transform.SetParent(serverPanel);
            }
        }
        print(hostList);
    }
}
