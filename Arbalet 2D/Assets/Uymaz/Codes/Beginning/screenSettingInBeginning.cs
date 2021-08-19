using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenSettingInBeginning : MonoBehaviour {
	public GameObject camera;
	public float sum = 0.01f;
	//We will be trying to resize the screen's scale

	//We will share this script file with all game objects included camera.

	void Awake(){

		//If we have played game before, we will pass the screen setting scene. 
		//Otherwise, we will meet with it. So we need to change the pref for we will not meet with it again.
	//	if (PlayerPrefs.GetInt ("thisIsFirstTimePlaying") == 0) {
			//Change the pref
	//		PlayerPrefs.SetInt ("thisIsFirstTimePlaying", 1);
	//	}
	//	else{
			//Pass the scene
	//		Application.LoadLevel ("uidesign");	
	//	}
	}


	public void HeightIncrease()
	{
		//camera.GetComponent<Camera> ().fieldOfView += sum;
		camera.GetComponent<Transform>().localScale = new Vector3(camera.GetComponent<Transform>().localScale.x, camera.GetComponent<Transform>().localScale.y + sum, camera.GetComponent<Transform>().localScale.z);
	}

	//Decrase the screen (magnifying)
	public void HeightDecrease()
	{
		//camera.GetComponent<Camera> ().fieldOfView -= sum;
		camera.GetComponent<Transform>().localScale = new Vector3(camera.GetComponent<Transform>().localScale.x, camera.GetComponent<Transform>().localScale.y - sum, camera.GetComponent<Transform>().localScale.z);

	}

	//Increase the screen (smalling screen)
	public void WidthIncrease()
	{
		//camera.GetComponent<Camera> ().fieldOfView += sum;
		camera.GetComponent<Transform>().localScale = new Vector3(camera.GetComponent<Transform>().localScale.x + sum, camera.GetComponent<Transform>().localScale.y, camera.GetComponent<Transform>().localScale.z);

	}

	//Decrase the screen (magnifying)
	public void WidthDecrease()
	{
		//camera.GetComponent<Camera> ().fieldOfView -= sum;
		camera.GetComponent<Transform>().localScale = new Vector3(camera.GetComponent<Transform>().localScale.x - sum, camera.GetComponent<Transform>().localScale.y, camera.GetComponent<Transform>().localScale.z);
	}



	public void GoToGame()
	{
		//We need to get the camera's scale values
		//For X
		PlayerPrefs.SetFloat ("ScreenScaleX", camera.GetComponent<Transform>().localScale.x);
		//For Y
		PlayerPrefs.SetFloat ("ScreenScaleY", camera.GetComponent<Transform>().localScale .y);

		//We go to "uidesign" scene
		Application.LoadLevel ("uidesign");	

		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);
	}

	void onApplicationQuit() {
		PlayerPrefs.SetFloat ("musicTime", 0);
	} 
}
