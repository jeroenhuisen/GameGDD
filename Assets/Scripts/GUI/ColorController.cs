using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorController : MonoBehaviour {
	public Text rText;
	public Text gText;
	public Text bText;

	public Slider rSlider;
	public Slider gSlider;
	public Slider bSlider;

	public Image panel;

	private Color color;
	public PlayerControllerMenu playerController;

	// Use this for initialization
	void Start () {
		color = new Color(1f, 1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		rText.text = "R: " + rSlider.value.ToString();
		gText.text = "G: " + gSlider.value.ToString();
		bText.text = "B: " + bSlider.value.ToString();
		color.r = rSlider.value;
		color.g = gSlider.value;
		color.b = bSlider.value;

		panel.material.color = color;
	}

	public void Confirm(){
		playerController.setColor (color);
	}
}
