using UnityEngine;
using System.Collections;

public class guiForTesting : MonoBehaviour {
	//public Texture btnTexture;

	RecipeBook rBook = new RecipeBook();
	CurrentDrinkManager drinkManager = new CurrentDrinkManager();
	void OnGUI() {

		/*
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
			Debug.Log("Clicked the button with an image");
		*/	
		
		if (GUI.Button (new Rect (10, 70, 50, 30), "Click")) {

			rBook.hotVanillaLatte.setVariants(TypesOfContainers.forHere, TypesOfMilk.milkSoy);

			//rBook.hotVanillaLatte.printAllIngredients();
			drinkManager.initialize();
			drinkManager.addContainer(TypesOfContainers.forHere, Ingredients.hotCup);
			drinkManager.addIngredient(Ingredients.expresso);
			drinkManager.addMilk(TypesOfMilk.milkSoy);
			drinkManager.addIngredient(Ingredients.steam);
			drinkManager.addIngredient(Ingredients.vanilla);
			drinkManager.addIngredient(Ingredients.vanilla);
			drinkManager.addIngredient(Ingredients.cap);
			drinkManager.addIngredient(Ingredients.cardboardCuff);

			if(drinkManager.compareToOtherDrink(rBook.hotVanillaLatte))
				Debug.Log("Correct!");
			else
				Debug.Log("Wrong...");


			
			}
				

	}
}	