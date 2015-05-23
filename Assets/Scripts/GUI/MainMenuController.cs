using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    public Canvas mainMenuCanvas;
    public Canvas createServerCanvas;
    public Canvas searchServersCanvas;
    public Canvas optionsCanvas;

    private Canvas enabledCanvas = null;

    public SearchServerMenu searchServerMenu;

#if UNITY_WEBPLAYER
     public static string webplayerQuitURL = "https://youtu.be/dQw4w9WgXcQ";
#endif

    // Use this for initialization
	void Start () {
        mainMenuCanvas.enabled = true;
        createServerCanvas.enabled = false;
        searchServersCanvas.enabled = false;
        optionsCanvas.enabled = false;

        enabledCanvas = mainMenuCanvas;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MainMenu()
    {
        mainMenuCanvas.enabled = true;
        enabledCanvas.enabled = false;
        enabledCanvas = mainMenuCanvas;
    }
    public void CreateServer()
    {
        createServerCanvas.enabled = true;
        enabledCanvas.enabled = false;
        enabledCanvas = createServerCanvas;
    }

    public void SearchServers()
    {
        searchServersCanvas.enabled = true;
        enabledCanvas.enabled = false;
        enabledCanvas = searchServersCanvas;

        searchServerMenu.Enable();
    }

    public void Options()
    {
        optionsCanvas.enabled = true;
        enabledCanvas.enabled = false;
        enabledCanvas = optionsCanvas;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
		Application.Quit ();
#endif
		Debug.Log( "quit");
    }

    public void DisableMenu()
    {
        enabledCanvas.enabled = false;
    }
}
