using UnityEngine;
using System.Collections;
using System;

public class ModifiableDrink : Drink {

	ArrayList drinkIngredientsList = new ArrayList();


	public new Ingredients[] DrinkIngredients
	{
		get
		{
			//int[] newIntArr = (int[]) drinkIngredientsList.ToArray(typeof(int));

			Ingredients[] newArr = (Ingredients[]) drinkIngredientsList.ToArray(typeof(Ingredients));
			Array.Sort(newArr);
			return newArr;
		}
	}

	public void add(Ingredients newIng)
	{
		drinkIngredientsList.Add (newIng);
	}

	public void empty()
	{
		drinkIngredientsList.Clear();
		typeOfMilk = TypesOfMilk.none;
		typeOfContainer = TypesOfContainers.none;
	}


	public new void printAllIngredients()
	{
		Ingredients[] newArr = DrinkIngredients;
		for (int i=0; i<newArr.Length; i++) {
			Debug.Log ("Ingr # " + i + ": " + Enum.GetName(typeof(Ingredients), newArr[i]));
			
		}
	}

	
}
