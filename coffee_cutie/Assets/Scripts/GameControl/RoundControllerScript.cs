using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundControllerScript : MonoBehaviour {


	int correctDrinks ;
	int incorrectDrinks;

	public Text registrarMachineText;
	public int drinkPrice=20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void init()
	{
		correctDrinks = 0;
		incorrectDrinks = 0;
	}

	public void correctResult()
	{
		correctDrinks++;
		registrarMachineText.text = "$" + (correctDrinks * drinkPrice);
	}

	public void incorrectResult()
	{
		incorrectDrinks++;
	}
}
