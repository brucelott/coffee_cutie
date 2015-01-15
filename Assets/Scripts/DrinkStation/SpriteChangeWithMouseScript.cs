using UnityEngine;
using System.Collections;

public class SpriteChangeWithMouseScript : MonoBehaviour {

	public Sprite idleSprite;
	public Sprite mouseHoverSprite;
	SpriteRenderer renderer;
	bool mouseHovering;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = idleSprite;
		mouseHovering = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!mouseHovering) {
						renderer.sprite = idleSprite;//change to when the mouse leaves the icon (if there's a method)
				}
		mouseHovering = false;
	
	}
		
	void OnMouseOver()
	{
		renderer.sprite = mouseHoverSprite;
		mouseHovering = true;
	}
}
