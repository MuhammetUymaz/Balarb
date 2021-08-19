using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuCode : MonoBehaviour {

	//Screen Setting
	public float width;
	public float height;

	//UI items
	public GameObject playButtonTurkish;
	public GameObject playButtonEnglish;


	public GameObject letsPlayTexture;

	public GameObject quitTextureTurkish;
	public GameObject quitTextureEnglish;

	public GameObject highScore;
	public GameObject modeOfHighScore;

	//High Score Controller
	string highScoreString;
	string modeOfHighScoreString;
	string[] modeNames = new string[3];

	void Awake()
	{
		//We need to edit the camera's scales. We need to get these values before in the beginning. We must be ready
		//For X
		//gameObject.GetComponent<Transform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScreenScaleX"), gameObject.GetComponent<Transform>().localScale.y, gameObject.GetComponent<Transform>().localScale.z); 
		//For Y
		//gameObject.GetComponent<Transform>().localScale = new Vector3(gameObject.GetComponent<Transform>().localScale.x, PlayerPrefs.GetFloat("ScreenScaleY"), gameObject.GetComponent<Transform>().localScale.z); 

		if (PlayerPrefs.GetInt ("Language") == 1) {
		
			playButtonTurkish.SetActive (true);
			quitTextureTurkish.SetActive (true);
		
		}
		else if (PlayerPrefs.GetInt ("Language") == 2) {
			playButtonEnglish.SetActive (true);
			letsPlayTexture.SetActive (true);
			quitTextureEnglish.SetActive (true);
		
		}


		//We check it which language we use

		if(PlayerPrefs.GetInt("Language") == 1){
			highScoreString = "Yüksek Skor: ";
			modeOfHighScoreString = "Şu Modda: ";
			modeNames [0] = "Acemi";
			modeNames [1] = "Standart";
			modeNames [2] = "Mücadele";
		}

		if (PlayerPrefs.GetInt ("Language") == 2) {
			highScoreString = "High Score: ";
			modeOfHighScoreString = "Which Mode: ";
			modeNames [0] = "Newbie";
			modeNames [1] = "Standard";
			modeNames [2] = "Challenge";

		}


		if ((PlayerPrefs.GetInt ("highScoreMode3") >= PlayerPrefs.GetInt ("highScoreMode2")) && (PlayerPrefs.GetInt ("highScoreMode3") >= PlayerPrefs.GetInt ("highScoreMode1")))
		{
			Debug.Log ("3");
			highScore.GetComponent<Text> ().text = highScoreString + PlayerPrefs.GetInt ("highScoreMode3").ToString ();
			modeOfHighScore.GetComponent<Text> ().text = modeOfHighScoreString + modeNames [0];
		}
		else if ((PlayerPrefs.GetInt ("highScoreMode2") > PlayerPrefs.GetInt ("highScoreMode3")) && (PlayerPrefs.GetInt ("highScoreMode2") >= PlayerPrefs.GetInt ("highScoreMode1"))) 
		{
				Debug.Log ("2");
				highScore.GetComponent<Text> ().text = highScoreString + PlayerPrefs.GetInt ("highScoreMode2").ToString ();
			modeOfHighScore.GetComponent<Text> ().text = modeOfHighScoreString + modeNames [1];
		}
		else if ((PlayerPrefs.GetInt ("highScoreMode1") > PlayerPrefs.GetInt ("highScoreMode2")) && (PlayerPrefs.GetInt ("highScoreMode1") > PlayerPrefs.GetInt ("highScoreMode3")))
			{
				Debug.Log ("1");
				highScore.GetComponent<Text> ().text = highScoreString + PlayerPrefs.GetInt ("highScoreMode1").ToString ();
			modeOfHighScore.GetComponent<Text> ().text = modeOfHighScoreString + modeNames [2];
			}


	}

	// Use this for initialization
	void Start () {
		//We check the background music has been turned off
		if (PlayerPrefs.GetInt ("musicTurning") % 2 == 0) {

			//Set the time of the music
				//We look at playerPrefs from "languageScreenCamera" script
			if (PlayerPrefs.GetInt ("replayMusic") == 0) {
				gameObject.GetComponent<AudioSource> ().time = PlayerPrefs.GetFloat ("musicTime");
			}
			else {
				gameObject.GetComponent<AudioSource> ().time = 0f;
			}

			//Play it
			gameObject.GetComponent<AudioSource> ().Play();
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
