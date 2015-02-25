using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "RC-CarsMultiplayer";
	private const string masterIP = "127.0.0.1";
	public const string gameName = "RoomName";
	public int maximumPlayers = 4;
	public int portNumber = 25000;

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
	//	MasterServer.ipAddress = masterIP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private HostData[] hostList;
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
	
	private void StartServer()
	{
		Network.InitializeServer(maximumPlayers, portNumber, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}

	void OnServerInitialized()
	{
		//Debug.Log("Server Initializied");
		SpawnPlayer ();
	}

	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer()
	{
		//Debug.Log("Server Joined");
		SpawnPlayer ();
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("Clean up after player " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	void OnDisconnectedFromServer()
	{
		Debug.Log ("disconnected from server");
		DestroyPlayer ();
	}

	private void SpawnPlayer ()
	{
		Network.Instantiate(playerPrefab, new Vector3(10f,5f,-10f), Quaternion.identity, 0);
	}
	private void DestroyPlayer()
	{
		//Network.Destroy (playerPrefab);
		Debug.Log( "DESTROYEDDDDD!!");
	}

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
}
