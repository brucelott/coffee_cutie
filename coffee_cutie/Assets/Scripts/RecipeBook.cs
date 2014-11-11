using UnityEngine;
using System.Collections;

public class RecipeBook{



	//public static Ingredients[] myIngs = {Ingredients.hotCup, Ingredients.expresso, Ingredients.milk,  
		//Ingredients.steam, Ingredients.vanilla, Ingredients.vanilla, Ingredients.cap, Ingredients.cardboardCuff} ;

	public static Ingredients[] myIngs = {Ingredients.hotCup, Ingredients.expresso, Ingredients.milk, Ingredients.vanilla,
		Ingredients.vanilla, Ingredients.cap, Ingredients.steam, Ingredients.cardboardCuff} ;

	public Drink hotVanillaLatte = new Drink(myIngs);
	

		
	 
}
