using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StalkerScript : MonoBehaviour {

	public bool on;
	private Text bubbleText; 
	// Use this for initialization
	public string[] catCalls =
	{
		"HEY, SUGAR TITS!",
		"YOU’D BE PRETTIER IF YOU’D SMILE!",
		"HOW MUCH FOR AN HOUR?",
		"I COULD TEACH YOU SOME THINGS!",
		"YOU GOT ANYTHING FOR ME BACK THERE?",
		"WHY DON’T YOU COME HOME WITH ME?",
		"YOU GOT A BOYFRIEND? WHAT’S YOUR NUMBER?",
		"DO YOU GET HOT BEHIND THAT COUNTER?",
		"I’D RIP THAT LITTLE APRON RIGHT OFF!"
	};


	void Start () {
		bubbleText = GetComponentInChildren<Text> ();
		randomizeText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startWorking()
	{

	}

	private void randomizeText()
	{
		int randomIndex = Random.Range (0, catCalls.Length);
		bubbleText.text = catCalls [randomIndex];
	}




}
