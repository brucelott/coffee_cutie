using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

public class RecipeBookText : MonoBehaviour {

	public Text leftPageText;
	public Text rightPageText;
	RecipeBook recipeBook = new RecipeBook();
	private int recipeIndex = 0;

	void Start() 
	{
		leftPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);
		rightPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex+1]);
	}

	private string getRecipe(Drink drink) 
	{
		/* Name of recipe. */
		string output = drink.name.ToUpper() + "\n\n";

		/* List of Ingredients */ 
		// Make sure duplicates of ingredients aren't recounted.
		List<int> duplicateIngredientIndices = new List<int>(); 

		for(int i = 0; i < drink.DrinkIngredients.Length; i++)
		{
			if(duplicateIngredientIndices.Contains(i) == false) {
				// Check if there are multiples of ingredient i.
				int numberOfIngredient = 1;
				for(int j = 0; j < drink.DrinkIngredients.Length; j++) 
				{
					if(i != j && duplicateIngredientIndices.Contains(j) == false) 
					{
						if(drink.DrinkIngredients[i] == drink.DrinkIngredients[j]) 
						{
							numberOfIngredient++;
							duplicateIngredientIndices.Add(j);
						}
					}
				}
				output += "- " + recipeBook.translate(drink.DrinkIngredients[i]);
				if(numberOfIngredient > 1)
					output += " x " + numberOfIngredient;
				output += "\n";
			}
		}
		return output;
	}

	/* These are for UI buttons to interface with. */
	public void getNextRecipe() 
	{
		if(recipeIndex+2 < recipeBook.allDrinksArray.Length)
		{
			recipeIndex += 2;
			leftPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);

			if(recipeIndex + 1 < recipeBook.allDrinksArray.Length) 
				rightPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex+1]);
			else 
				rightPageText.text = "";
		}
	}

	public void getPreviousRecipe()
	{
		if(recipeIndex > 1)
		{
			recipeIndex -= 2;
			leftPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);
			if(recipeIndex + 1 < recipeBook.allDrinksArray.Length)  
				rightPageText.text = getRecipe(recipeBook.allDrinksArray[recipeIndex+1]);
			else
				rightPageText.text = "";
		}
	}

}
