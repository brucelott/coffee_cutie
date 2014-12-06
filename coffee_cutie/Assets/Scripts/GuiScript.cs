using UnityEngine;
using System;

public class GuiScript : MonoBehaviour 
{
	/*
	RecipeBook rBook = new RecipeBook();
	Drink referenceDrink;
	CurrentDrinkManager drinkManager = new CurrentDrinkManager();

	public GameObject milkSoyObj;
	public CustomGuiButton milkSoy;

	public CustomGuiButton milkNonfat;
	public CustomGuiButton milkTwoPercent;
	public CustomGuiButton pullExpresso;
	public CustomGuiButton steam;
	public CustomGuiButton plainSyrup;
	public CustomGuiButton vanillaSyrup;
	public CustomGuiButton mochaSyrup;
	public CustomGuiButton cuff;
	public CustomGuiButton cap;
	public CustomGuiButton ice;
	public CustomGuiButton strawAndLid;
	public CustomGuiButton hotCupToGo;
	public CustomGuiButton hotCupForHere;
	public CustomGuiButton coldCupToGo;
	public CustomGuiButton coldCupForHere;
	public CustomGuiButton restart;
	public CustomGuiButton finish;

	void Start()
	{
		milkSoy.setSprite (milkSoyObj);
	}
	
	void OnGUI() 
	{

		if(milkSoy.OnMouseClick()){ 
			Debug.Log("clicked milkSoy");
			drinkManager.addMilk(TypesOfMilk.milkSoy);

		}
		/*
		else if(milkNonfat.OnMouseClick()){ 
			Debug.Log("clicked milkNonfat");
			drinkManager.addMilk(TypesOfMilk.milkNonFat);

		}
		else if(milkTwoPercent.OnMouseClick()){ 
			Debug.Log("clicked milkTwoPercent");
			drinkManager.addMilk(TypesOfMilk.milk2percent);

		}
		else if(pullExpresso.OnMouseClick()){ 
			Debug.Log("clicked expresso");
			drinkManager.addIngredient(Ingredients.expresso);

		}
		else if(steam.OnMouseClick()){ 
			Debug.Log("clicked steam");
			drinkManager.addIngredient(Ingredients.steam);

		}
		else if(plainSyrup.OnMouseClick()){ 
			Debug.Log("clicked plainSyrup");
			drinkManager.addIngredient(Ingredients.plainSyrup);

		}
		else if(vanillaSyrup.OnMouseClick()){ 
			Debug.Log("clicked vanilla");
			drinkManager.addIngredient(Ingredients.vanilla);

		}
		else if(mochaSyrup.OnMouseClick()){ 
			Debug.Log("clicked mocha");
			drinkManager.addIngredient(Ingredients.mocha);

		}
		else if(cuff.OnMouseClick()){ 
			Debug.Log("clicked cardboard cuff");
			drinkManager.addIngredient(Ingredients.cardboardCuff);

		}
		else if(cap.OnMouseClick()){ 
			Debug.Log("clicked cap");
			drinkManager.addIngredient(Ingredients.cap);

		}
		else if(ice.OnMouseClick()){ 
			Debug.Log("clicked ice");
			drinkManager.addIngredient(Ingredients.ice);

		}
		else if(strawAndLid.OnMouseClick()){ 
			Debug.Log("clicked lid and straw");
			drinkManager.addIngredient(Ingredients.lidAndStraw);

		}
		else if(hotCupToGo.OnMouseClick()){ 
			Debug.Log("clicked hot cup to go");
			drinkManager.addContainer(TypesOfContainers.toGo, Ingredients.hotCup);
		}
		else if(hotCupForHere.OnMouseClick()){ 
			Debug.Log("clicked hot cup for here");
			drinkManager.addContainer(TypesOfContainers.forHere, Ingredients.hotCup);
		}
		else if(coldCupToGo.OnMouseClick()){ 
			Debug.Log("clicked cold cup to go");
			drinkManager.addContainer(TypesOfContainers.toGo, Ingredients.coldCup);
		}
		else if(coldCupForHere.OnMouseClick()){ 
			Debug.Log("clicked cold cup for here");
			drinkManager.addContainer(TypesOfContainers.forHere, Ingredients.coldCup);
		}
		else if(restart.OnMouseClick()){ 
			drinkManager.initialize();
			referenceDrink = rBook.returnRandomDrink();
			Debug.Log ( "Can I have a " + referenceDrink.name + " with " + rBook.translate(referenceDrink.typeOfMilk)
			           + ", " + rBook.translate(referenceDrink.typeOfContainer) + " please?" );
		}
		else if(finish.OnMouseClick()){ 
			if(drinkManager.compareToOtherDrink(referenceDrink))
				Debug.Log("Correct!");
			else
				Debug.Log("Wrong...");
		}

	}
	*/
	
}

//[Serializable] // Exposes public variables of custom class to Unity's Inspector.
public class CustomGuiButton
{
	GameObject thisSprite_m;
	Rect bounds;
	//CustomGuiButton()
	//{

	//	}

	public void setSprite(GameObject thisSprite)
	{
		thisSprite_m = thisSprite;
		bounds = new Rect (thisSprite_m.GetComponent<SpriteRenderer> ().bounds.min.x, 
		                  thisSprite_m.GetComponent<SpriteRenderer> ().bounds.min.y, 
		                  thisSprite_m.GetComponent<SpriteRenderer> ().bounds.max.x, 
		                   thisSprite_m.GetComponent<SpriteRenderer> ().bounds.max.y);
		                  // thisSprite_m.GetComponent<SpriteRenderer> ().bounds.max);
	}
	public GUIStyle style = new GUIStyle();
	//public Vector2 position = new Vector2(100,100);

	/*
	public bool OnMouseClick(){
		return GUI.Button(new Rect(position.x, 
								   position.y, 
								   style.normal.background.width,
								   style.normal.background.height),
						  "", 
						  style);
	}
*/

	
	public bool OnMouseClick(){
		return GUI.Button (bounds, "");
		//return false;
	}
}		