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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rText.text = "R: " + rSlider.value.ToString();
		gText.text = "G: " + gSlider.value.ToString();
		bText.text = "B: " + bSlider.value.ToString();

		panel.material.color = new Color (rSlider.value, gSlider.value, bSlider.value, 1f);
	}
}
