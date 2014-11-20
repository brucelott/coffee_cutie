﻿using UnityEngine;
using System.Collections;

public class RecipeBook{



	//0
	public static Drink hotVanillaLatte = new Drink(new Ingredients[] 
								{Ingredients.hotCup, Ingredients.expresso, Ingredients.milk, Ingredients.vanilla,
								Ingredients.vanilla, Ingredients.cap, Ingredients.steam, Ingredients.cardboardCuff} , 
								"hot vanilla latte");

	//1
	public static Drink coldVanillaLatte = new Drink(new Ingredients[] 
	                              {Ingredients.coldCup, Ingredients.expresso, Ingredients.milk, Ingredients.vanilla,
								   Ingredients.vanilla, Ingredients.ice, Ingredients.lidAndStraw},
								"cold vanilla latte");




	public Drink[] allDrinksArray = {hotVanillaLatte, coldVanillaLatte};


	public Drink returnRandomDrink()
	{
		int randomIndex = Random.Range (0, allDrinksArray.Length);
		allDrinksArray [randomIndex].typeOfContainer = (TypesOfContainers)Random.Range ((int)TypesOfContainers.forHere, (int)TypesOfContainers.toGo+1);
		allDrinksArray [randomIndex].typeOfMilk = (TypesOfMilk)Random.Range ((int)TypesOfMilk.milkNonFat, (int)TypesOfMilk.milkSoy+1);
		return allDrinksArray [randomIndex];
	}
		
	public Drink returnRandomDrink(int limit)
	{
		if (limit >= allDrinksArray.Length)
						limit = allDrinksArray.Length;
		int randomIndex = Random.Range (0, limit);
		allDrinksArray [randomIndex].typeOfContainer =(TypesOfContainers) Random.Range ((int)TypesOfContainers.forHere, (int)TypesOfContainers.toGo+1);
		allDrinksArray [randomIndex].typeOfMilk =(TypesOfMilk) Random.Range ((int)TypesOfMilk.milkNonFat, (int)TypesOfMilk.milkSoy+1);
		return allDrinksArray [randomIndex];
	}



	public string translate(Ingredients thisIng)  //translates Enum elements to strings
	{
				switch (thisIng) {

				case Ingredients.cap:
						return "Cap";
				case Ingredients.cardboardCuff:
						return "Cardboard cuff";
				case Ingredients.coldCup:
						return "Cold cup";
				case Ingredients.expresso:
						return "Expresso";
				case Ingredients.hotCup:
						return "Hot Cup";
				case Ingredients.ice:
						return "Ice";
				case Ingredients.lidAndStraw:
						return "Lid and straw";
				case Ingredients.milk:
						return "Milk";
				case Ingredients.mocha:
						return "Mocha";
				case Ingredients.plainSyrup:
						return "Plain syrup";
				case Ingredients.steam:
						return "Steam";
				case Ingredients.vanilla:
						return "Vanilla";
				case Ingredients.none:
						return "NONE!!";
				default:
						Debug.Log ("Problem translating ingredient");
						return "?? ingredient";


				}


	}

	public string translate(TypesOfMilk thisMilk)  	
	{

		if (thisMilk == TypesOfMilk.milk2percent) {
			return "2% milk";
				} else if (thisMilk == TypesOfMilk.milkNonFat) {
			return "non-fat milk";
				} else if (thisMilk == TypesOfMilk.milkSoy) {
			return "soy milk";
				} else {
			Debug.Log ("Problem translating milk");
			return "?? milk";
				}
	}

	public string translate(TypesOfContainers thisContainer)
	{	
		if (thisContainer == TypesOfContainers.forHere) {
			return "for here";
		} else if (thisContainer == TypesOfContainers.toGo) {
			return "to go";
		} else {
			Debug.Log ("Problem translating container");
			return "?? container";
		}

	}

}
