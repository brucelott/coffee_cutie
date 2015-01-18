using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RecipeBookText : MonoBehaviour {

	public Text text;
	RecipeBook recipeBook = new RecipeBook();
	private int recipeIndex = 0;

	void Start () 
	{
		text = gameObject.GetComponent<Text>();
		text.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);
	}

	public void getNextRecipe() 
	{
		if(recipeIndex < recipeBook.allDrinksArray.Length-1)
		{
			recipeIndex++;
			text.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);
		}
	}

	public void getPreviousRecipe()
	{
		if(recipeIndex > 0)
		{
			recipeIndex--;
			text.text = getRecipe(recipeBook.allDrinksArray[recipeIndex]);
		}
	}

	private string getRecipe(Drink drink) 
	{
		string output = "";
		output += drink.name.ToUpper();
		output += "\n";
		for(int i = 0; i < drink.DrinkIngredients.Length; i++)
		{
			output += "- ";
			output += recipeBook.translate(drink.DrinkIngredients[i]);
			output += "\n";
		}

		return output;
	}

}
