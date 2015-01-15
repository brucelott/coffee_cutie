using UnityEngine;
using System.Collections;

public class boundsTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("min x " + GetComponent<SpriteRenderer> ().bounds.min.x);
		Debug.Log ("min y" + GetComponent<SpriteRenderer> ().bounds.min.y);
		Debug.Log ("max " + GetComponent<SpriteRenderer> ().bounds.max);

	}
}
