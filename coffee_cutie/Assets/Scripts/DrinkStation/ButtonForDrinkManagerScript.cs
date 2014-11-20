using UnityEngine;
using System.Collections;

public class ButtonForDrinkManagerScript : MonoBehaviour {

	private CurrentDrinkManager currentDrinkManager;
	private DrinkStationScript drinkStation;
	//private DrinkStationScript drinkStation;
	// Use this for initialization
	public enum TypesOfMessage {ingredient, milk, container, reset, finish, none};
	public TypesOfMessage typeOfMessage;
	public Ingredients ingredient=Ingredients.none;
	public TypesOfMilk milk=TypesOfMilk.none;
	public TypesOfContainers container=TypesOfContainers.none;

	void Start () {
		//drinkStation = GetComponentInParent<DrinkStationScript> ();
		currentDrinkManager = GetComponentInParent<DrinkStationScript> ().drinkManager;
		drinkStation = GetComponentInParent<DrinkStationScript> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUpAsButton()
	{
		//Debug.Log ("Object clicked");
		//currentDrinkManager.
		switch (typeOfMessage) {
		case TypesOfMessage.ingredient:
			currentDrinkManager.addIngredient(ingredient); break;
		case TypesOfMessage.milk:
			currentDrinkManager.addMilk(milk); break;
		case TypesOfMessage.container:
			currentDrinkManager.addContainer(container, ingredient); break;
		case TypesOfMessage.reset:
			currentDrinkManager.initialize(); break;
		case TypesOfMessage.finish:
			drinkStation.sendComparisonResult(); break;
		default:
			Debug.Log ("Problem with button. Type of message not defined?"); break;
				}



		
	}
}
