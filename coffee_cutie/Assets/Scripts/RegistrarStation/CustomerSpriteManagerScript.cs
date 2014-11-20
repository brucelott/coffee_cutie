using UnityEngine;
using System.Collections;

public class CustomerSpriteManagerScript : MonoBehaviour {

	public Sprite[] possibleSprites;
	// Use this for initialization
	SpriteRenderer spRenderer;
	void Start () {
	
		spRenderer = GetComponent<SpriteRenderer> ();
		//setRandomSprite ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setRandomSprite()
	{
		int randomIndex = Random.Range (0, possibleSprites.Length);
		spRenderer.sprite = possibleSprites [randomIndex];
	}
}
