using UnityEngine;
using System.Collections;

public class DrinkStationScript : MonoBehaviour {

	public DrinkVisualizerScript drinkVisualizer;
	RecipeBook rBook = new RecipeBook();
	//Drink referenceDrink= new Drink(new Ingredients[]{Ingredients.milk, Ingredients.hotCup});
	Drink referenceDrink;
	public CurrentDrinkManager drinkManager = new CurrentDrinkManager ();
	public RegistrarStationScript registrarStation;
	// Use this for initialization
	void Start () {
		drinkManager.setVisualizerReference(drinkVisualizer as DrinkVisualizerScript);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setReferenceDrink(Drink receivedDrink)
	{
		Debug.Log ("Drink received by drink station");
		drinkManager.initialize ();
		referenceDrink = receivedDrink;

	}

	public void sendComparisonResult()
	{
		bool result = drinkManager.compareToOtherDrink (referenceDrink);
		registrarStation.giveAnswer (result);
		//registrarStation.giveAnswer (true);
	}
}
