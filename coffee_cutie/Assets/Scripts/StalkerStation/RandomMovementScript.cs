using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomMovementScript : MonoBehaviour {

	RectTransform rectTransform;
	Vector3 speed;
	public float maxSpeed=4;
	//private Text text;
	//public Transform startingPositionObj;
	private Vector3 startPosition;
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		//text = GetComponentInChildren<Text> ();
		startPosition = rectTransform.position;
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTransform.position = rectTransform.position + speed;
		if (rectTransform.position.x > Screen.width || rectTransform.position.x < 0) 
			{
			rectTransform.position = rectTransform.position - speed;
			speed.x=speed.x*-1;
			}
		else if (rectTransform.position.y > Screen.height || rectTransform.position.y < 0)
			{
			rectTransform.position = rectTransform.position - speed;
			speed.y=speed.y*-1;
			}


	}


	void randomPosition()
	{

	}

	public void init()
	{
		rectTransform.position=startPosition;
			speed=new Vector3(Random.Range(-1*maxSpeed, maxSpeed), Random.Range(-1*maxSpeed, maxSpeed), 0);

	}

	//		rectTransform.position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));


}
