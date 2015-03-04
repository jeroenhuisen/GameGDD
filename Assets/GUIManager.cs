using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	private int height;
	private int width;
	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{

		/*
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
		}*/
	}

	public void AddButton(int positionX, int positionY, int height, int width){
		positionX = Screen.width / positionX;
		positionY = Screen.height / positionY;
	}
}
