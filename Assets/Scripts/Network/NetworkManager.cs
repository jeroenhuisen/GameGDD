using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "RC-CarsMultiplayer";
	private const string masterIP = "127.0.0.1";
	public string gameName = "Default Room Name";
	public int maximumPlayers = 4;
	public int portNumber = 25000;

	private string prefabName = "CarModel";
	private Color color;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		MasterServer.ipAddress = masterIP;
		//color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	} 

	private HostData[] hostList;
	
	public void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
            Debug.Log(hostList);
	}

    public HostData[] GetHostList()
    {
        hostList = MasterServer.PollHostList();
        return hostList;
    }
	
	public void StartServer()
	{
		if (!Network.isClient && !Network.isServer) {
			print ("StartServer");
			Network.InitializeServer (maximumPlayers, portNumber, !Network.HavePublicAddress ());
			MasterServer.RegisterHost (typeName, gameName);
		}
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
		gameManager.LoadLevel();
	}

	void OnLevelWasLoaded(int level) {
		SpawnPlayer ();
	}

	public void JoinServer(HostData hostData)
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
		print ("NetworkManager");

		GameObject car = (GameObject) Network.Instantiate(Resources.Load (prefabName), new Vector3(10f,5f,-10f), Quaternion.identity, 0);
		print (color.r);
		print (color.g);
		print (color.b);
		car.GetComponent<CarControllerUnity5>().setColor(color);
		print ("done");
	}
	private void DestroyPlayer()
	{
		//Network.Destroy (playerPrefab);
		Debug.Log( "DESTROYEDDDDD!!");
	}

	public void setPlayerModel (string name){
		prefabName = name;
	}
	public void setColor(Color colorCar){
		print ("setColor");
		this.color = new Color (colorCar.r, colorCar.g, colorCar.b);
		print (colorCar.b);
		print (color);
		print ("setColor");
		/*color.r = colorCar.r;
		color.g = colorCar.g;
		color.b = colorCar.b;*/
	}
	public void setColor(Vector3 colorCar){
		print ("setColor1");	
		this.color = new Color (colorCar.x, colorCar.y, colorCar.z, 1.0f);
		/*color.r = colorCar.x;
		color.g = colorCar.y;
		color.b = colorCar.z;*/
	}

	public void changeRoomName(string newName){
		if (!Network.isClient && !Network.isServer) {
			gameName = newName;
		}
	}

	public void setMaxPlayers(int players){
		maximumPlayers = players;
	} 
}
