using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

	//Sprites for music and sound buttons
	public Sprite spriteMute;
	public Sprite musicSpritePlaying;

	public Sprite soundSpritePlaying;

	public GameObject playContinueButton;
	public GameObject pauseGameButton;

	public void restartClick()
	{
		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);

		//We write this code later. Otherwise, the level will be passed without setting musicTime
			//HEY! ı WROTE 3 TEMPORARıLY
		Application.LoadLevel ("StandardMode");

	}

	public void TurkceDil()
	{
		//1 represents Türkçe,
		//2 represents English
		PlayerPrefs.SetInt ("Language", 1);

		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);



		//Go to mode screen
		Application.LoadLevel("uidesign");
	}

	public void EnglishLanguage()
	{
		//1 represents Türkçe,
		//2 represents English
		PlayerPrefs.SetInt ("Language", 2);

		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);

		//Go to mode screen
		Application.LoadLevel("uidesign");
	}

	public void	homeClick()
	{
		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);

		//Go to home scene
		Application.LoadLevel("Menu");
	}

	public void musicClick()
	{
		//We need to check the music's situation. We can turn on or turn off
					//Even numbers: we can turn off; Odd numbers: we can turn on

		//Turn off the music
		if (PlayerPrefs.GetInt ("musicTurning") % 2 == 0) {
			//Turn it off
			GameObject.Find ("Camera").GetComponent<AudioSource> ().Stop ();
			//Mute icon
			gameObject.GetComponent<Image> ().sprite = spriteMute;
			//Increase the pref
			PlayerPrefs.SetInt("musicTurning", PlayerPrefs.GetInt("musicTurning")+1);
		}
		else {
			//Turn it on
			GameObject.Find ("Camera").GetComponent<AudioSource> ().Play();
			//Playing icon
			gameObject.GetComponent<Image> ().sprite = musicSpritePlaying;
			//Increase the pref
			PlayerPrefs.SetInt("musicTurning", PlayerPrefs.GetInt("musicTurning")+1);
		}


	}

	public void languageScreenClick()
	{
		//Save time of background music to be able to continue later
		PlayerPrefs.SetFloat("musicTime", GameObject.Find("Camera").GetComponent<AudioSource>().time);

		//Edit the redirecting player pref
		PlayerPrefs.SetInt("redirectingByLanguageSetting", 1);

		//Go to language setting screen
		Application.LoadLevel ("languageScreen");

	}


	public void soundClick()
	{
		//We need to check the sound effect's situation. We can turn on or turn off
		//Even numbers: we can turn off; Odd numbers: we can turn on

		//Turn off the sound effect
		if (PlayerPrefs.GetInt ("soundEffectTurning") % 2 == 0) {
			//Turn them off
			GameObject.Find ("balloonA").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonB").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonC").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonD").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonE").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonF").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("bulletPrefab").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("electricLine").GetComponent<AudioSource> ().mute = false;
			//Mute icon
			gameObject.GetComponent<Image> ().sprite = spriteMute;
			//Increase the pref
			PlayerPrefs.SetInt("soundEffectTurning", PlayerPrefs.GetInt("soundEffectTurning")+1);
		}
		else {
			//Turn them on
			GameObject.Find ("balloonA").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("balloonB").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("balloonC").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("balloonD").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("balloonE").GetComponent<AudioSource> ().mute =true;
			GameObject.Find ("balloonF").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("bulletPrefab").GetComponent<AudioSource> ().mute = true;
			GameObject.Find ("electricLine").GetComponent<AudioSource> ().mute = true;
			//Playing icon
			gameObject.GetComponent<Image> ().sprite = soundSpritePlaying;
			//Increase the pref
			PlayerPrefs.SetInt("soundEffectTurning", PlayerPrefs.GetInt("soundEffectTurning")+1);
		}
	}


	public void pause()
	{
		//Save the time scale for right now
		PlayerPrefs.SetFloat ("nowTimeScale", Time.timeScale);

		//Stop the game
		Time.timeScale = 0;

		//Make PlayButton  active
		playContinueButton.SetActive(true);

		//Make the gameobject passive
		gameObject.SetActive(false);
	}

	public void playContinue()
	{
		//Use the time scale which we've saved
		Time.timeScale = PlayerPrefs.GetFloat ("nowTimeScale");

		//Make active 
		pauseGameButton.SetActive (true);

		//Make the gameobject passive
		gameObject.SetActive (false);
	}

}
