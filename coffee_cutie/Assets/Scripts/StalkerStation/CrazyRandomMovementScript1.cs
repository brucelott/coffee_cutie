using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrazyRandomMovementScript : MonoBehaviour {

	RectTransform rectTransform;
	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
	}
}
