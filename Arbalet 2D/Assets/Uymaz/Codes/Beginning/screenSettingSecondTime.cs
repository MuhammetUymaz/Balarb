using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenSettingSecondTime : MonoBehaviour {

	public GameObject camera;
	public float sum = 0.01f;
	//We will be trying to resize the screen's scale

	//Actually, we will share this script file all game objects included Camera
	//So below line code will be run if the gameobject is the camera
	void Start()
	{
		if (PlayerPrefs.GetInt ("musicTurning") % 2 == 0 && gameObject.name == "Camera") {
			//Background music continues on its time
			gameObject.GetComponent<AudioSource>().time = PlayerPrefs.GetFloat("musicTime");
			//Play it
			gameObject.GetComponent<AudioSource> ().Play ();
		}
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

		//We go to game again. Because we've come from the game. This isn't first time
		Application.LoadLevel ("StandardMode");	

		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);
	}

	void onApplicationQuit() {
		PlayerPrefs.SetFloat ("musicTime", 0);
	} 
}
