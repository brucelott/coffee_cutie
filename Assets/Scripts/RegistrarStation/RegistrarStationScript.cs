using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegistrarStationScript : MonoBehaviour {


	public RoundControllerScript roundController;

	private float timeForNextEvent=3f;
	private enum States{
		customerComing, customerAsking,
		customerWaiting, customerResponding, 
		customerLeaving};
	States state;
	public GameObject customer;
	private Transform customerTransform;
	Vector3 finalPosition;
	public float hidingXdifference;
	Vector3 hidingPosition;
	public float movementSpeed;
	CustomerSpriteManagerScript customerSprite;
	Drink askedDrink;
	RecipeBook rBook = new RecipeBook();
	public DrinkStationScript drinkStation;
	bool wasAnswerGiven=false;
	bool correctDrinkAnswer;
	public bool done;

	AudioSource soundPlayer;
	public AudioClip correctSound;
	public AudioClip incorrectSound;




	// Use this for initialization
	void Start () {
		customerSprite = GetComponentInChildren<CustomerSpriteManagerScript>();
		soundPlayer = GetComponent<AudioSource> ();
		customerTransform = customer.GetComponent<Transform> ();
		finalPosition = customerTransform.position;
		hidingPosition = finalPosition - new Vector3 (hidingXdifference, 0, 0);
		init ();
	}


	public void init()
	{
		done = false;
		customerTransform.position = hidingPosition;
		nextCustomer ();

	}


	// Update is called once per frame
	void Update () {

		timeForNextEvent -= Time.deltaTime;
		float step =  movementSpeed * Time.deltaTime;
		switch (state){

		case States.customerComing:
			customerTransform.position = Vector3.MoveTowards(customerTransform.position, finalPosition, step);
			if(timeForNextEvent<=0)
				enterState(States.customerAsking);
			break;

		case States.customerWaiting:
			if(wasAnswerGiven)
				enterState(States.customerResponding);
			break;
		
		case States.customerResponding:
			if(timeForNextEvent<=0)
				enterState(States.customerLeaving);
			break;

		case States.customerLeaving:
			customerTransform.position = Vector3.MoveTowards(customerTransform.position, hidingPosition, step);
			if(timeForNextEvent<=0)
				nextCustomer();
			break;


		}


	}




	void enterState(States newState)
	{
		switch (newState) {

			case States.customerComing:
				timeForNextEvent=3f;
				//say ("Im coming up to the counter");
				wasAnswerGiven=false;
				state=States.customerComing;
				break;
				
			case States.customerAsking:
				askedDrink=rBook.returnRandomDrink();
				timeForNextEvent=120f;
				say(constructAskingSentence(askedDrink));
				sendAskedDrinkToDrinkStation();
				state=States.customerWaiting;
				break;

			case States.customerResponding:
				timeForNextEvent=2f;
				if(correctDrinkAnswer)
				{
					say ("Thanks");
					oneCorrectDrink();

				}
				else
				{
					say ("This is not what I ordered");
					oneIncorrectDrink();
				}
				state=States.customerResponding;
				break;

			case States.customerLeaving:
				timeForNextEvent=1f;
				say ("I'm leaving");
				state=States.customerLeaving;
				break;

			}
	
		}

	void nextCustomer()
	{
		if (!done) {
						//say ("NEXT");
						customerSprite.setRandomSprite ();
						enterState (States.customerComing);
				} else {
			//last customer is gone
				}
	}




	void say(string text)
	{
		BroadcastMessage ("updateText", text);
		BroadcastMessage ("showText", timeForNextEvent-0.5);
	}


	string constructAskingSentence(Drink referenceDrink)
	{
		string result;

		result = "Can I have a " + referenceDrink.name + " with " + rBook.translate (referenceDrink.typeOfMilk)
						+ ", " + rBook.translate (referenceDrink.typeOfContainer) + " please?";

		return result;
	}


	void sendAskedDrinkToDrinkStation()
	{
		drinkStation.setReferenceDrink (askedDrink);
	}
	///////
	/// 
	public void giveAnswer(bool answer) //this should be used by the DrinkStationScript
	{
		correctDrinkAnswer = answer;
		wasAnswerGiven = true;


	}

	//
	void oneCorrectDrink()
	{
		soundPlayer.PlayOneShot (correctSound, 0.9f);
		roundController.correctResult ();
	}

	void oneIncorrectDrink()
	{
		soundPlayer.PlayOneShot (incorrectSound, 0.5f);
		roundController.incorrectResult ();
		//This will be used to take hearts off
	}
}
