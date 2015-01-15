using UnityEngine;
using System.Collections;

public class HeartManagerScript : MonoBehaviour {



	public HeartScript heart1;
	public HeartScript heart2;
	public HeartScript heart3;

	public RoundControllerScript roundController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void takeHeartOff()
	{
		Debug.Log ("Take heart off in heart manager");
		if (heart3.alive) {
						heart3.die ();
						//return true;
				} else if (heart2.alive) {
						heart2.die ();
						//return true;
				} else if (heart1.alive) {
						heart1.die ();
						//return true;
				} else {
						//return false;
					outOfHearts();
				}
	}

	public void outOfHearts()
	{
		roundController.outOfHearts ();
	}

	public void init()
	{
		heart1.init ();
		heart2.init ();
		heart3.init ();

	}
}
