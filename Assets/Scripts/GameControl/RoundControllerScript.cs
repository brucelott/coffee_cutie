using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundControllerScript : MonoBehaviour {


	int correctDrinks ;
	int incorrectDrinks;

	public Text registrarMachineText;
	public int drinkPrice=20;
	public int stalkersAppearAfterCorrectDrinkNum=0;
	public float maxTimeOfRoundInSeconds=120;

	public DrinkStationScript drinkStation;
	public StalkerStationScript stalkerStation;
	public RegistrarStationScript registrarStation;
	public ClockScript clock;
	public AudioSource musicPlayer;

	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void init()
	{
		correctDrinks = 0;
		incorrectDrinks = 0;
		registrarMachineText.text = "$" + (correctDrinks * drinkPrice);

		enableAllScripts ();
		musicPlayer.Play ();
		clock.init (maxTimeOfRoundInSeconds);
		drinkStation.init ();
		stalkerStation.init ();
		registrarStation.init ();
	}

	public void correctResult()
	{
		correctDrinks++;
		registrarMachineText.text = "$" + (correctDrinks * drinkPrice);
		if (correctDrinks > stalkersAppearAfterCorrectDrinkNum) {
			stalkerStation.addStalker();
				}
	}

	public void incorrectResult()
	{
		incorrectDrinks++;
	}


	public void aStalkerGotAngry()
	{
		Debug.Log ("in Round Controller Stalker Angry");
		// Penalize player by removing some time.
		clock.deductTime(2);
	}

	public void outOfTime()
	{
		endRound ();
	}

	private void endRound()
	{
		Debug.Log ("end game");
		musicPlayer.Stop ();
		disableAllScripts ();
	}

	public void startRound()
	{
		init ();
	}


	public void enableAllScripts()
	{
		drinkStation.enabled=true;
		stalkerStation.enabled=true;
		registrarStation.enabled=true;
		clock.enabled=true;
	}

	public void disableAllScripts()
	{
		registrarStation.done = true;
		drinkStation.enabled=false;
		stalkerStation.enabled=false;
		registrarStation.enabled=false;
		clock.enabled=false;
	}
}
