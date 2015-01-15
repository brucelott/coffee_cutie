using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerTextScript : MonoBehaviour {


	float showTime=0f;
	
	// Use this for initialization
	public Text text;
	public Image image;
	
	void Start () {
		//text=GetComponent<Text>();
		text = GetComponentInChildren<Text> ();
		image = GetComponent<Image> ();
		text.text = "text set up";
	}
	
	// Update is called once per frame
	void Update () {
		if (showTime > 0) {
						showTime -= Time.deltaTime;
				} else {
						text.enabled=false;
						image.enabled=false;
				}
	}
	
	public void updateText(string newText)
	{
		text.text = newText;
		showText (10f);
	}
	
	public void showText(float time)
	{
		showTime = time;
		text.enabled=true;
		image.enabled=true;
	}

}