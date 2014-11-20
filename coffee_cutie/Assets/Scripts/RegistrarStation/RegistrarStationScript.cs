using UnityEngine;
using System.Collections;

public class RegistrarStationScript : MonoBehaviour {

	private float timeForNextEvent;
	private enum States{
		customerComing, customerAsking,
		customerWaiting, customerResponding, 
		customerLeaving};
	States state;
	public Transform customer;
	Drink askedDrink;
	RecipeBook rBook = new RecipeBook();
	public DrinkStationScript drinkStation;
	bool wasAnswerGiven=false;
	bool correctDrinkAnswer;


	// Use this for initialization
	void Start () {
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
				say ("Im coming up to the counter");
				wasAnswerGiven=false;
				timeForNextEvent=3f;
				state=States.customerComing;
				break;
				
			case States.customerAsking:
				askedDrink=rBook.returnRandomDrink();
				say(constructAskingSentence(askedDrink));
				state=States.customerWaiting;
				break;

			case States.customerResponding:
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
				timeForNextEvent=2f;
				break;

			case States.customerLeaving:
				say ("I'm leaving");
				timeForNextEvent=2f;
				state=States.customerLeaving;
				break;

			}
	
		}

	void nextCustomer()
	{
		say ("NEXT");
		enterState (States.customerComing);
	}




	void say(string text)
	{
		BroadcastMessage ("updateText", text);
		BroadcastMessage ("showText", 5f);
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
