using UnityEngine;
using System.Collections;

public class ClockScript : MonoBehaviour 
{

	public float roundFullTime=20f;
	public Sprite[] frames;
	SpriteRenderer renderer;
	int spriteStages;
	int currentFrame;
	float currentTime;
	float timeStep;
	private AudioSource soundPlayer;
	public AudioClip bellSound;
	public bool stopped;

	public RoundControllerScript roundController;

	void Start () 
	{
		renderer = GetComponent<SpriteRenderer> ();
		soundPlayer = GetComponent<AudioSource> ();
		spriteStages=frames.Length;
	}

	void Update () 
	{
		if (!stopped) 
		{
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) 
			{
				currentTime = timeStep;
				nextFrame ();	
			}
		}
	}

	void nextFrame()
	{
		currentFrame++;
		if (currentFrame >= spriteStages) 
		{
			endOfClockReached ();		
		}
		else 
		{
			renderer.sprite = frames [currentFrame];
		}
	}

	void endOfClockReached()
	{
		soundPlayer.PlayOneShot (bellSound, 0.7f);
		currentFrame = 0;
		stopped = true;
		roundController.outOfTime ();
	}

	public void init()
	{
		stopped = false;
		timeStep=roundFullTime/spriteStages;
		currentTime = timeStep;
		currentFrame = 0;
		renderer.sprite = frames [currentFrame];
	}
	
	public void init(float newRoundTime)
	{
		roundFullTime=newRoundTime;
		init ();

	}
}
