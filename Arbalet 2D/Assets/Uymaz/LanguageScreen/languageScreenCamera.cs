using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class languageScreenCamera : MonoBehaviour {

	//Screen Setting
	public float width;
	public float height;

	void Awake()
	{
		
		//We control that we've played game before or have not
			//Also if we have been redirected by "language setting button" from the game over screen, we will not skip this scene
		if (PlayerPrefs.GetInt ("firstGame") > 0 && PlayerPrefs.GetInt("redirectingByLanguageSetting") == 0) {

			if (PlayerPrefs.GetInt ("Language") == 0) {
				PlayerPrefs.SetInt ("Language", 2); 
			}
			//DONT FORGET! OPEN THESE LıNE CODES!
			//We go to main menu
			Application.LoadLevel("uidesign");

			//The music needs to be replayed. It must not continue (on menu and next scenes). So
			PlayerPrefs.SetInt("replayMusic", 1);
		}

		//The first game experiment
		else if(PlayerPrefs.GetInt ("firstGame") == 0)
		{
			//Play the music
			gameObject.GetComponent<AudioSource>().Play();

			//We dont wanna enter this scene again automatically
			PlayerPrefs.SetInt("firstGame", 1);
		}

		//If we have been redirected:
		else if(PlayerPrefs.GetInt("redirectingByLanguageSetting") == 1)
		{
			//We switch it
			PlayerPrefs.SetInt("redirectingByLanguageSetting", 0);

			//Music for right now:
				//Background music continues on its time
			if (PlayerPrefs.GetInt ("musicTurning") % 2 != 0) {
				gameObject.GetComponent<AudioSource> ().Stop ();
			} else {
				gameObject.GetComponent<AudioSource> ().time = PlayerPrefs.GetFloat ("musicTime");
				gameObject.GetComponent<AudioSource>().Play();
			}


			//The music can continue on next scenes. So
			PlayerPrefs.SetInt("replayMusic", 0);
		}


		//SCREEN SETTıNG
		float newWidth = Screen.width * 1f;
		float newHeight = Screen.height * 1f;

		width = (newWidth / newHeight) / (480f/960f);
		height = (newHeight / newWidth) / (960f/ 480f);

		if (newWidth / newHeight < 0.5f) {
			height -= ((480f / 960f) - (newWidth / newHeight)) * (960f / 480f);
		}
		else if (newWidth / newHeight > 0.5f) {
			height += ((newWidth / newHeight) - (480f/960f)) * (960f / 480f);
		}

		//Debug.Log (PlayerPrefs.GetInt ("gameMode"));
		//Debug.Log (Screen.width + "x" + Screen.height);
		gameObject.GetComponent<Transform>().localScale = new Vector3(width, height, gameObject.GetComponent<Transform>().localScale.z); 



	}


	void Update(){
	
	
		//Debug.Log ("firstGame: " + PlayerPrefs.GetInt ("firstGame").ToString() + " redirectingByLanguageSetting :" + PlayerPrefs.GetInt("redirectingByLanguageSetting").ToString());

	}
}
