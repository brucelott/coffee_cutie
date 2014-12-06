using UnityEngine;
using System.Collections;

public class StalkerStationScript : MonoBehaviour {
	public StalkerScript stalker1;
	public StalkerScript stalker2;
	public StalkerScript stalker3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addStalker()
	{
		if (!stalker1.on) {
			stalker1.startWorking();
				} else if (!stalker2.on) {
			stalker2.startWorking();
				} else if (!stalker3.on) {
			stalker3.startWorking ();
				} else {
			Debug.Log("All stalkers working");
				}

	}
}
