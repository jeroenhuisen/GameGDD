using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inGameMenu : MonoBehaviour {
    public GameObject gameMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeInHierarchy)
            {
                gameMenu.SetActive(false);
            }
            else
            {
                gameMenu.SetActive(true);
            }
        }
	}
}
