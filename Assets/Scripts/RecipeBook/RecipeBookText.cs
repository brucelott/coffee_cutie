using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RecipeBookText : MonoBehaviour {

	public Text text;
	RecipeBook recipeBook = new RecipeBook();

	void Start () 
	{
		text = gameObject.GetComponent<Text>();
		/* text.text = "Hot Vanilla Latte:\n\n- Ingredient 1\n- Ingredient 2\n- Ingredient 3"; */
		/* text.text = recipeBook.translate(recipeBook.allDrinksArray[0].DrinkIngredients[0]); */
		text.text = getRecipe(recipeBook.allDrinksArray[0]);
	}

	private string getRecipe(Drink drink) 
	{
		string output = "";
		output += drink.name.ToUpper();
		output += "\n";
		for(int i = 0; i < drink.DrinkIngredients.Length; i++)
		{
			output += recipeBook.translate(drink.DrinkIngredients[i]);
			output += "\n";
		}

		return output;
	}

}
