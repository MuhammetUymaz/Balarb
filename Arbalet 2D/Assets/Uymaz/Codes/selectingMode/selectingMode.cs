using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectingMode : MonoBehaviour {

	//We will determine the prefab about Game Mode

	public void FirstMode()
	{
		PlayerPrefs.SetInt ("gameMode", 1);

		Application.LoadLevel ("StandardMode");
	}

	public void SecondMode()
	{
		PlayerPrefs.SetInt ("gameMode", 2);	

		Application.LoadLevel ("StandardMode");
	}

	public void ThirdMode()
	{
		PlayerPrefs.SetInt ("gameMode", 3);

		Application.LoadLevel ("StandardMode");
	}


}
