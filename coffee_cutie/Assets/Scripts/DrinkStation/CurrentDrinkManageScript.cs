using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class CurrentDrinkManager {

	const bool debugging=true;
	ModifiableDrink currentDrink = new ModifiableDrink();
	enum States{making, ruined}; //when the order is incorrect, the drink is ruined							
	States state;				 //check for the state of the manager to deactivate the gui when the drink is ruined
	Ingredients previousIngredientForOrder;
	DrinkVisualizerScript visualizer;

	
	public void setVisualizerReference(DrinkVisualizerScript visualizer_local)
	{
		visualizer = visualizer_local;
	}

	///Use these public methods
	/// vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
	public void addIngredient(Ingredients newIng)  //for adding almost all ingredients you use "addIngredient" 
													//	and pass the right enum for ingredients												
	{
		if (state != States.ruined) {

			currentDrink.add(newIng);
			//if(debugging) 
				//Debug.Log ("Added: " + Enum.GetName(typeof(Ingredients), newIng));
			updateVisualsIngredient(newIng);
			if (!checkOrder (newIng))
				getsRuined ();
		} else {
			visualizerCantAddSound();	
			//Debug.LogWarning ("Ingredients shouldn't be added after the drink is ruined");
		}



		   
	}
	
	public void addMilk(TypesOfMilk newIng)  //except for milk, where you use "addMilk" and pass the right enum from types of milk
	{
		addIngredient(Ingredients.milk);
		currentDrink.typeOfMilk = newIng;
	}
	
	public void addContainer(TypesOfContainers newCont, Ingredients newIng ) //and containers. You use addContainer and pass 2 enums (from typesOfContainers and Ingredients)
	{
		if (newIng != Ingredients.coldCup && newIng != Ingredients.hotCup) {
			Debug.LogError ("Ingredient in addcontainers has to be hotCup or coldCup. " +
				"It is: " + Enum.GetName(typeof(Ingredients), newIng));

				}
		if (currentDrink.typeOfContainer == TypesOfContainers.none) {
						currentDrink.typeOfContainer = newCont;
						addIngredient (newIng);
				} else {
			if(state!=States.ruined)
				{
				getsRuined();
				}
			else
				{
				visualizerCantAddSound();
				}
			}


	}

	public void initialize()
	{
		currentDrink.empty ();
		state = States.making;
		previousIngredientForOrder = 0;
		initializeVisualizer ();


	}

	public bool compareToOtherDrink(Drink otherDrink) //here you pass drinks from recipeBook to see if their ingredients match the ingredients of currentDrink
	{

		int limit; //this is to limit the amount of ingredients if the drink is not to go
		if (otherDrink.typeOfContainer != TypesOfContainers.toGo) {
						if (otherDrink.DrinkIngredients [0] == Ingredients.coldCup) {
								limit = otherDrink.DrinkIngredients.Length - 1;
						} else if (otherDrink.DrinkIngredients [0] == Ingredients.hotCup) {
								limit = otherDrink.DrinkIngredients.Length - 2;
						} else {
								Debug.LogError ("the first ingredient of reference drink (from recipe book) is not a cup!!");
								limit=0;
						}
				} else {
			limit=otherDrink.DrinkIngredients.Length;
				}


		Ingredients[] firstArray = currentDrink.DrinkIngredients;
		Ingredients[] secondArray = otherDrink.DrinkIngredients;

		Array.Sort (firstArray);
		Array.Sort (secondArray);

		if (debugging) {
						//for (int i=0; i<firstArray.Length; i++) { //just prints all the ingredients to compare
						//		Debug.Log ("Arr 1 Ingr # " + i + ": " + Enum.GetName (typeof(Ingredients), firstArray [i])); 
						//		Debug.Log ("Arr 2 Ingr # " + i + ": " + Enum.GetName (typeof(Ingredients), secondArray [i]));
						//}
				}

		if (firstArray.Length != limit) 
			{
						if (debugging)
						Debug.Log ("Arrays of ingredients not the same size");
						return false;
			}	
		else
			{
				for (int i=0; i<limit; i++) 
				{
					if(firstArray[i]!=secondArray[i])
					{
						return false; //if any element of the array is different it returns false
					}
				}
				if((currentDrink.typeOfContainer==otherDrink.typeOfContainer)&&(currentDrink.typeOfMilk==otherDrink.typeOfMilk))
					{	
					return true; // 
					}
				else
					{
					if (debugging)
						{
							Debug.Log ("Variant Ingredients (container and milk) are not the same in both drinks");
							Debug.Log ("currentDrink" + Enum.GetName (typeof(TypesOfContainers), currentDrink.typeOfContainer));
							Debug.Log ("otherDrink(recipe)" + Enum.GetName (typeof(TypesOfContainers), otherDrink.typeOfContainer));
							Debug.Log ("currentDrink" + Enum.GetName (typeof(TypesOfMilk), currentDrink.typeOfMilk));
							Debug.Log ("otherDrink(recipe)" + Enum.GetName (typeof(TypesOfMilk), otherDrink.typeOfMilk));
						}
					return false;
					}
			}

	}



	/// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
	/// End of public methods


	
	private bool checkOrder(Ingredients currentIngredient) //I need to implement a significant order. Right now it just compares to the order of the definitions in the enum
	{
		if (currentIngredient < previousIngredientForOrder) {
						return false;
				} else {
			previousIngredientForOrder=currentIngredient;
			return true;
				}
	}

	private void updateVisualsIngredient(Ingredients newIng)
	{
		visualizer.addIngredient (newIng, currentDrink.typeOfContainer);
		//we have to send currentDrink.typeOfContainer besides newIng
	}

	private void visualizerCantAddSound()
	{
		visualizer.cantAddSoundPlay ();
	}

	private void getsRuined()
	{
		state=States.ruined;
		visualizer.getsRuined ();
	}

	private void initializeVisualizer()
	{
		visualizer.initialize ();
	}
}
