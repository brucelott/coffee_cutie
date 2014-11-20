using UnityEngine;
using System.Collections;

public class DrinkStationScript : MonoBehaviour {


	RecipeBook rBook = new RecipeBook();
	Drink referenceDrink;
	public CurrentDrinkManager drinkManager = new CurrentDrinkManager();
	public RegistrarStationScript registrarStation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setReferenceDrink(Drink receivedDrink)
	{
		drinkManager.initialize ();
		referenceDrink = receivedDrink;

	}

	public void sendComparisonResult()
	{
		//bool result = drinkManager.compareToOtherDrink (referenceDrink);
		//registrarStation.giveAnswer (result);
		registrarStation.giveAnswer (true);
	}
}
