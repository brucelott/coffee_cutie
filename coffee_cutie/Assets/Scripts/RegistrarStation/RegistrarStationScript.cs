using UnityEngine;
using System.Collections;

public class RegistrarStationScript : MonoBehaviour {

	private float timeForNextEvent=3f;
	private enum States{
		customerComing, customerAsking,
		customerWaiting, customerResponding, 
		customerLeaving};
	States state;
	public GameObject customer;
	CustomerSpriteManagerScript customerSprite;
	Drink askedDrink;
	RecipeBook rBook = new RecipeBook();
	public DrinkStationScript drinkStation;
	bool wasAnswerGiven=false;
	bool correctDrinkAnswer;


	// Use this for initialization
	void Start () {
		customerSprite = GetComponentInChildren<CustomerSpriteManagerScript>();
		nextCustomer ();
	}


	
	// Update is called once per frame
	void Update () {

		timeForNextEvent -= Time.deltaTime;

		switch (state){

		case States.customerComing:
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
				say ("Im coming up to the counter");
				wasAnswerGiven=false;
				state=States.customerComing;
				break;
				
			case States.customerAsking:
				askedDrink=rBook.returnRandomDrink();
				timeForNextEvent=30f;
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
				timeForNextEvent=2f;
				say ("I'm leaving");
				state=States.customerLeaving;
				break;

			}
	
		}

	void nextCustomer()
	{
		say ("NEXT");
		customerSprite.setRandomSprite ();
		enterState (States.customerComing);
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
		//This will be used to add points
	}

	void oneIncorrectDrink()
	{
		//This will be used to take hearts off
	}
}
