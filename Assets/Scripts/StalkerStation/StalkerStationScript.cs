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

	public void addStalker()
	{
		if (stalker1.state==StalkerScript.StalkerStates.waitingOut) {
			stalker1.startWorking();
		} else if (stalker2.state==StalkerScript.StalkerStates.waitingOut) {
			stalker2.startWorking();
		} else if (stalker3.state==StalkerScript.StalkerStates.waitingOut) {
			stalker3.startWorking ();
				} else {
			Debug.Log("All stalkers working");
				}

	}

	public void init()
	{
		stalker1.init ();
		stalker2.init ();
		stalker3.init ();
	}
}
