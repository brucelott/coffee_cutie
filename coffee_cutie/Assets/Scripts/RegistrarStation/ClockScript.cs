using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour {

	//const int spriteStages=20;
	public float roundFullTime=20f;
	public Sprite[] frames;
	SpriteRenderer renderer;
	int spriteStages;
	int currentFrame;
	float currentTime;
	float timeStep;

	// Use this for initialization
	void Start () {
		spriteStages=frames.Length;
		timeStep=roundFullTime/spriteStages;
		currentTime = timeStep;
		currentFrame = 0;
		renderer = GetComponent<SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		currentTime -= Time.deltaTime;
		if (currentTime <= 0) {
			currentTime=timeStep;
			nextFrame();
				}


	}

	void nextFrame()
	{
		currentFrame++;
		if (currentFrame >= spriteStages) {
						endOfClockReached ();		
				} else {
						renderer.sprite = frames [currentFrame];
				}

	}

	void endOfClockReached()
	{
		currentFrame = 0;
	}
}
