using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StalkerScript : MonoBehaviour {

	public bool on;
	private Text bubbleText;
	private Button button;
	private Image bImage;
	private RandomMovementScript buttonMovementScript;
	public StalkerStates state;
	public Sprite normalSprite;
	public Sprite angrySprite;
	public Transform stalkerVisualObj;
	private SpriteRenderer spRenderer;
	public int chanceInOfGettingAngry;
	public float angryTime;
	private float currentAngryTime;


	Vector3 originalPosition;
	public float positionDifferenceY;
	public float speed;
	public float leaveSpeedMultiplier;
	Vector3 waitingPosition;

	AudioSource soundPlayer;
	public AudioClip heySound;
	public AudioClip angrySound;

	public float maxBubbleSpeed;

	public RoundControllerScript roundController;


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
	public void init()
	{
		deactivateButton ();
		spRenderer.sprite = normalSprite;
		state = StalkerStates.waitingOut;
		stalkerVisualObj.position = waitingPosition;
		//state = StalkerStates.comingIn;

	}

	void Start () {
		bubbleText = GetComponentInChildren<Text> ();
		button = GetComponentInChildren<Button> ();
		bImage = GetComponentInChildren<Image> ();

		soundPlayer = GetComponent<AudioSource> ();

		spRenderer = stalkerVisualObj.GetComponent<SpriteRenderer> ();

		buttonMovementScript = GetComponentInChildren<RandomMovementScript> ();
		originalPosition = stalkerVisualObj.position;
		waitingPosition = stalkerVisualObj.position - new Vector3 (0, positionDifferenceY, 0);
		stalkerVisualObj.position = waitingPosition;
		init ();

	}
	
	// Update is called once per frame
	void Update () {
		if (state == StalkerStates.comingIn) {
			float step = speed * Time.deltaTime;
			stalkerVisualObj.position = Vector3.MoveTowards(stalkerVisualObj.position, originalPosition, step);
			if(stalkerVisualObj.position==originalPosition)
			{
				catCall();
				state=StalkerStates.waitingIn;
			}
		}
		if (state == StalkerStates.leaving) {
			float step = speed*leaveSpeedMultiplier * Time.deltaTime;
			stalkerVisualObj.position = Vector3.MoveTowards(stalkerVisualObj.position, waitingPosition, step);
			if(stalkerVisualObj.position==waitingPosition)
			{
				state=StalkerStates.waitingOut;
			}
		}
		if (state == StalkerStates.angry) {
			currentAngryTime=-Time.deltaTime;
				if(currentAngryTime<=0)
				{
					leave ();
				}

			}


	
	}

	public void startWorking()
	{
		init ();
		state = StalkerStates.comingIn;
	}

	private void leave()
	{
		state = StalkerStates.leaving;
	}

	private void randomizeText()
	{
		int randomIndex = Random.Range (0, catCalls.Length);
		bubbleText.text = catCalls [randomIndex];
	}

	public void buttonWasPressed()
	{
		deactivateButton ();

		if (Random.Range (0, chanceInOfGettingAngry) == 0) {
						getAngry ();
				} else {
						leave ();
				}

	}

	public void catCall()
	{
		soundPlayer.PlayOneShot (heySound, 0.8f);
		activateButton ();
		randomizeText ();
		buttonMovementScript.init(maxBubbleSpeed);
	}

	private void getAngry()
	{
		soundPlayer.PlayOneShot (angrySound, 0.6f);
		spRenderer.sprite = angrySprite; 
		currentAngryTime = angryTime;
		state = StalkerStates.angry;
		roundController.aStalkerGotAngry ();

	}


	private void activateButton()
	{
		bubbleText.enabled = true;
		button.enabled = true;
		bImage.enabled = true;
		buttonMovementScript.init ();
	}

	private void deactivateButton()
	{
		bubbleText.enabled = false;
		button.enabled = false;
		bImage.enabled = false;
	}
	public enum StalkerStates {waitingOut, comingIn, waitingIn, angry, leaving};

}
