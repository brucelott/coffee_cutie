using UnityEngine;
using System.Collections;
using System;

public class DrinkVisualizerScript : MonoBehaviour {


	// Use this for initialization
	AudioSource soundPlayer;

	SpriteRenderer renderer;

	public Sprite ColdGoEmpty, ColdGoExpresso1, ColdGoExpresso2, ColdGoMilk, ColdGoIce, ColdGoLidStraw;
	public Sprite ColdHereEmpty, ColdHereExpresso1, ColdHereExpresso2, ColdHereMilk, ColdHereIce;
	public Sprite HotGoEmpty, HotGoExpresso1, HotGoExpresso2, HotGoMilk, HotGoSteam, HotGoLid, HotGoCuff;
	public Sprite HotHereEmpty, HotHereExpresso1, HotHereExpresso2, HotHereMilk, HotHereSteam;



	public AudioClip cupSetSound, expressoSound, milkSound, steamSound, 
		syrupSound, capSound, cuffSound, ruinsSound, cantAddSound, iceSound;

	private int expressoAmount;
	private Ingredients hotOrCold;

	void Start () {
		soundPlayer = GetComponent<AudioSource> ();
		renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getsRuined()
	{
		//play ruined sound
		Debug.Log("Got ruined!");
		soundPlayer.PlayOneShot (ruinsSound, 0.7f);
	}

	public void addIngredient(Ingredients ing, TypesOfContainers container)
	{
		//Debug.Log ("Yesshhh");
		Debug.Log ("Added: " + Enum.GetName(typeof(Ingredients), ing) + "on" +  Enum.GetName(typeof(TypesOfContainers), container));

		switch (ing) {
		
		case Ingredients.coldCup:
			hotOrCold = Ingredients.coldCup;
			soundPlayer.PlayOneShot(cupSetSound, 0.7f);
			if(container==TypesOfContainers.forHere)
				renderer.sprite=ColdHereEmpty;
			if(container==TypesOfContainers.toGo)
				renderer.sprite=ColdGoEmpty;
			break;
		case Ingredients.hotCup:
			hotOrCold = Ingredients.hotCup;
			soundPlayer.PlayOneShot(cupSetSound, 0.7f);
			if(container==TypesOfContainers.forHere)
				renderer.sprite=HotHereEmpty;
			if(container==TypesOfContainers.toGo)
				renderer.sprite=HotGoEmpty;
			break;
		case Ingredients.milk:
			soundPlayer.PlayOneShot(milkSound, 1.0f);
			if(container==TypesOfContainers.forHere)
				{
				if(hotOrCold==Ingredients.hotCup)
				renderer.sprite=HotHereMilk;
				if(hotOrCold==Ingredients.coldCup)
					renderer.sprite=ColdHereMilk;
				}
			if(container==TypesOfContainers.toGo)
				{
				if(hotOrCold==Ingredients.hotCup)
					renderer.sprite=HotGoMilk;
				if(hotOrCold==Ingredients.coldCup)
					renderer.sprite=ColdGoMilk;
				}
			break;
		case Ingredients.expresso:
			soundPlayer.PlayOneShot(expressoSound, 0.7f);
			if (expressoAmount==0)
			{

				if(container==TypesOfContainers.forHere)
				{
					if(hotOrCold==Ingredients.hotCup)
						renderer.sprite=HotHereExpresso2;
					if(hotOrCold==Ingredients.coldCup)
						renderer.sprite=ColdHereExpresso2;
				}
				if(container==TypesOfContainers.toGo)
				{
					if(hotOrCold==Ingredients.hotCup)
						renderer.sprite=HotGoExpresso2;
					if(hotOrCold==Ingredients.coldCup)
						renderer.sprite=ColdGoExpresso2;
				}

			}
			else
			{
				if(container==TypesOfContainers.forHere)
				{
					if(hotOrCold==Ingredients.hotCup)
						renderer.sprite=HotHereExpresso1;
					if(hotOrCold==Ingredients.coldCup)
						renderer.sprite=ColdHereExpresso1;
				}
				if(container==TypesOfContainers.toGo)
				{
					if(hotOrCold==Ingredients.hotCup)
						renderer.sprite=HotGoExpresso1;
					if(hotOrCold==Ingredients.coldCup)
						renderer.sprite=ColdGoExpresso1;
				}
			}
			expressoAmount++;
			break;
		case Ingredients.steam:
			soundPlayer.PlayOneShot(steamSound, 0.7f);
			if(container==TypesOfContainers.forHere)
			{
				if(hotOrCold==Ingredients.hotCup)
					renderer.sprite=HotHereSteam;

			}
			if(container==TypesOfContainers.toGo)
			{
				if(hotOrCold==Ingredients.hotCup)
					renderer.sprite=HotGoSteam;
			}
			break;
		case Ingredients.plainSyrup:
		case Ingredients.mocha:
		case Ingredients.vanilla:
			soundPlayer.PlayOneShot(syrupSound, 1.0f);	
			break;
		case Ingredients.cap:
			soundPlayer.PlayOneShot(capSound, 0.7f);
			if(container==TypesOfContainers.forHere)
			{

			}
			if(container==TypesOfContainers.toGo)
			{
				if(hotOrCold==Ingredients.hotCup)
					renderer.sprite=HotGoLid;

			}
			break;
		case Ingredients.lidAndStraw:
			soundPlayer.PlayOneShot(capSound, 0.7f);
			if(container==TypesOfContainers.forHere)
			{

			}
			if(container==TypesOfContainers.toGo)
			{

				if(hotOrCold==Ingredients.coldCup)
					renderer.sprite=ColdGoLidStraw;
			}
			break;
		case Ingredients.ice:
			soundPlayer.PlayOneShot(iceSound, 0.7f);
			if(container==TypesOfContainers.forHere)
			{
				if(hotOrCold==Ingredients.coldCup)
					renderer.sprite=ColdHereIce;
			}
			if(container==TypesOfContainers.toGo)
			{
				if(hotOrCold==Ingredients.coldCup)
					renderer.sprite=ColdGoIce;
			}
			break;
		case Ingredients.cardboardCuff:
			soundPlayer.PlayOneShot(capSound, 0.7f);
			if(container==TypesOfContainers.forHere)
			{
					
			}
			if(container==TypesOfContainers.toGo)
			{
				if(hotOrCold==Ingredients.hotCup)
				renderer.sprite=HotGoCuff;

			}
			break;
		default:
			Debug.Log ("There's a something wrong when adding ingredients to the visualizer!");
			break;
				}

	}

	public void cantAddSoundPlay()
	{
		Debug.Log("Can't add when ruined!");
		soundPlayer.PlayOneShot (cantAddSound, 0.7f);
	}

	public void initialize()
	{
		Debug.Log ("Visual initialized");
		soundPlayer.PlayOneShot (cupSetSound, 0.7f);
		renderer.sprite = null;
		expressoAmount = 0;
		hotOrCold = Ingredients.none;
	}


}
