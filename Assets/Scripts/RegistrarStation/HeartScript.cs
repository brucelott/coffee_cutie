using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {


	public Sprite aliveSprite;
	public Sprite deadSprite;
	SpriteRenderer renderer;
	public bool alive;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void init()
	{
		alive = true;
		renderer.sprite = aliveSprite;
	}

	public void die()
	{
		Debug.Log ("Heart died");
		alive = false;
		renderer.sprite = deadSprite;
	}
}
