using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeMenu : MonoBehaviour {

	//Screen Setting
	public float width;
	public float height;


	//UI items
	public GameObject selectModeText;
	public GameObject modSecimiYazi;
	public GameObject QuitButton;
	public GameObject oyunKapat;

	//Modes' Texts
	public GameObject[] modeNamesTextBoard;
	string[] modeNamesStrings = new string[3];

	// Use this for initialization
	void Start () {
		
		//Background music continues on its time if background music is opened
		if (PlayerPrefs.GetInt ("musicTurning") % 2 != 0) {
			gameObject.GetComponent<AudioSource> ().Stop ();
		} else {
			gameObject.GetComponent<AudioSource> ().time = PlayerPrefs.GetFloat ("musicTime");
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


		//Uı ıtems
		if (PlayerPrefs.GetInt ("Language") == 1) {
			modSecimiYazi.SetActive (true);
			oyunKapat.SetActive (true);

			modeNamesStrings [0] = "Acemi";
			modeNamesStrings [1] = "Standart";
			modeNamesStrings [2] = "Mücadele";

			modeNamesTextBoard [0].GetComponent<Text> ().text = modeNamesStrings [0];
			modeNamesTextBoard [1].GetComponent<Text> ().text = modeNamesStrings [1];
			modeNamesTextBoard [2].GetComponent<Text> ().text = modeNamesStrings [2];

		} else if(PlayerPrefs.GetInt("Language") == 2){
			selectModeText.SetActive (true);
			QuitButton.SetActive (true);

			modeNamesStrings [0] = "Newbie";
			modeNamesStrings [1] = "Standard";
			modeNamesStrings [2] = "Challenge";

			modeNamesTextBoard [0].GetComponent<Text> ().text = modeNamesStrings [0];
			modeNamesTextBoard [1].GetComponent<Text> ().text = modeNamesStrings [1];
			modeNamesTextBoard [2].GetComponent<Text> ().text = modeNamesStrings [2];



		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
