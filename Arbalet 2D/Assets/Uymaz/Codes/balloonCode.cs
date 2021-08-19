using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonCode : MonoBehaviour {

	//Time
	float rightNowTime;
	float limitedTime;
	public bool getRightNowBool = false;
	public bool startTimerBool = false;

	//The partical of the balloon
	public GameObject myChildPartical;


	// Use this for initialization
	void Start () {
		//We get llimited time from cameraCode
		limitedTime = GameObject.Find ("Camera").GetComponent<cameraCode>().balloonTime;
	}
	
	// Update is called once per frame
	void Update () {
			//We get current time
		if (getRightNowBool == true) {
			rightNowTime = Time.time;
			startTimerBool = true;
			getRightNowBool = false;
		}

			//We start timer
		if(startTimerBool == true){
			if (limitedTime + rightNowTime - Time.time <= 0) {
				//Time's up
				GameObject.Find ("Camera").GetComponent<cameraCode> ().makingBalloon (); //Making new ballon by cameraCode
				Destroy (gameObject); //Destroy this object
			}
		}

	}


}
