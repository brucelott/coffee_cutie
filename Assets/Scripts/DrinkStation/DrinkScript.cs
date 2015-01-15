using UnityEngine;
using System.Collections;
using System;


public class Drink{


	private Ingredients[] drinkIngredients; 
	public TypesOfContainers typeOfContainer;
	public TypesOfMilk typeOfMilk=TypesOfMilk.none;
	public string name;


	public Drink(Ingredients[] newIngs)
	{

		drinkIngredients = newIngs;
	}
	public Drink(Ingredients[] newIngs, string newName)
	{
		drinkIngredients = newIngs;
		name = newName;
	}
	public Drink()
	{
	}

	public Ingredients[] DrinkIngredients
	{
		get
		{
			//int[] newIntArr = (int[]) drinkIngredientsList.ToArray(typeof(int));

			return drinkIngredients;
		}
	}

	public void setVariants(TypesOfContainers newContainer, TypesOfMilk newMilk)
	{
		typeOfContainer = newContainer;
		typeOfMilk = newMilk;
	}

	public void setAllIngredients(Ingredients[] newIngs)
	{
		drinkIngredients = newIngs;

	}
		
	public void printAllIngredients()
	{
		for (int i=0; i<drinkIngredients.Length; i++) {
			Debug.Log ("Ingr # " + i + ": " + Enum.GetName(typeof(Ingredients), drinkIngredients[i]));

				}
	}

	/*
	void emptyDrink() //initializes the drink
	{
		currentIngredientInArray = 0;
	}


	void addIngredient(Ingredients newIng)  //for adding a
	{

	}

	void addIngredient(TypesOfMilk newIng) 
	{
		addIngredient(Ingredients.milk);
		typeOfMilk = newIng;
	}

	void addContainer(TypesOfContainers)
	{

	}

	void checkOrder()
	{

	}
	*/



}
