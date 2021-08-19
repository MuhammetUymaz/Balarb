using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class electricLineCode : MonoBehaviour {

	//Written code file
	public Writtens finalScreenWrittens;

	//Uı Text things
	public GameObject scoreTable;
	public GameObject textTable;
	public GameObject informationText;

	//Uı buttons
	public GameObject RestartButton;
	public GameObject homeButton;
	public GameObject musicButton;
	public GameObject soundButton;
	public GameObject screenSettingButton;
	// Use this for initialization

	//Game Over effect
	public GameObject particalOfLeftMagnatic;
	public bool changingLeftSideColor = false;

	//Score Table Items & Restart's written
	public string bestScore;
	public string yourScore;
	public string restartWritten;

	void Start () {

		if (PlayerPrefs.GetInt ("Language") == 1) {

			bestScore = "En Yüksek: ";
			yourScore = "Puanın: ";
			restartWritten = "Dokun: ";
		}
		else {
			bestScore = "Highest: ";
			yourScore = "Yours: ";
			restartWritten = "Tap to Play";
		}



	}
	
	// Update is called once per frame
	void Update () {
		//Change left side magnetic's color if the bool is true
		if (changingLeftSideColor == true) {
			particalOfLeftMagnatic.GetComponentInParent<SpriteRenderer>().color = Color.Lerp(particalOfLeftMagnatic.GetComponentInParent<SpriteRenderer>().color, new Color(0.32f, 0.32f, 0.32f), 0.045f);

		}
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "balloon" && (PlayerPrefs.GetInt ("gameMode") == 3 || PlayerPrefs.GetInt ("gameMode") == 2)) {
					//Destroy the balloon
			//We will make boombing balloon effect. So:
			GameObject ballonPartical =  collision.gameObject.GetComponent<balloonCode>().myChildPartical;
			//Active it
			ballonPartical.SetActive(true);
			//Destroy it
			Destroy(ballonPartical, 0.35f);
			//Make the balloon empty
			collision.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			Destroy(collision.gameObject.GetComponent<AudioSource> ());
			Destroy(collision.gameObject.GetComponent<BoxCollider2D> ());
			Destroy(collision.gameObject.GetComponent<SpriteRenderer> ());

			//Play the game over sound effect and make the partical of the left magnetic
			gameObject.GetComponent<AudioSource> ().Play ();
			GameObject partical = Instantiate (particalOfLeftMagnatic, particalOfLeftMagnatic.GetComponentInParent<Transform> ().position, particalOfLeftMagnatic.GetComponentInParent<Transform> ().rotation);
			partical.SetActive (true); //Active it. Because it is passive
			Destroy (partical, 1f); //Destroy the partical system
			changingLeftSideColor = true; //Change left side magnetic's color
	

			//Final screen
			textTable.GetComponent<Text> ().fontSize = 50;
			//High Score will be checked
			if (GameObject.Find ("Camera").GetComponent<cameraCode> ().score > PlayerPrefs.GetInt ("highScoreMode2")) {
				
				PlayerPrefs.SetInt ("highScoreMode2", GameObject.Find ("Camera").GetComponent<cameraCode> ().score);


			} else if (GameObject.Find ("Camera").GetComponent<cameraCode> ().score > PlayerPrefs.GetInt ("highScoreMode3")) {
				
				PlayerPrefs.SetInt ("highScoreMode3", GameObject.Find ("Camera").GetComponent<cameraCode> ().score);

			}

			//Show the scores
			if (PlayerPrefs.GetInt ("gameMode") == 2) {
				
				textTable.SetActive(true);
				scoreTable.SetActive (false);
				textTable.GetComponent<Text> ().text = bestScore + PlayerPrefs.GetInt ("highScoreMode2") + "\n" + yourScore + GameObject.Find ("Camera").GetComponent<cameraCode> ().score.ToString ();
			}

			else if (PlayerPrefs.GetInt ("gameMode") == 3) {
				
				textTable.SetActive(true);
				scoreTable.SetActive (false);
				textTable.GetComponent<Text> ().text = bestScore + PlayerPrefs.GetInt ("highScoreMode3") + "\n " + yourScore + GameObject.Find ("Camera").GetComponent<cameraCode> ().score.ToString ();

			}

	

			//Information text game object will be shown

			//We will see senteces or informations with which language we selected;

			int textTypeWeSee = Random.Range (0, 10);
			//0 -> Information
			//1 -> Sentece
			//We look at the which language we selected


			Debug.Log (textTypeWeSee);
			if (PlayerPrefs.GetInt ("Language") == 1) {
				if (textTypeWeSee < 5) {
					int randomOrder = Random.Range(0,finalScreenWrittens.bilgiler.Length);
					informationText.GetComponent<Text> ().text = finalScreenWrittens.bilgiler [randomOrder];
				}
				else if (textTypeWeSee > 5) {
					int randomOrder = Random.Range(0,finalScreenWrittens.kelimeler.Length);
					informationText.GetComponent<Text> ().text = finalScreenWrittens.kelimeler [randomOrder];
				}


			} else {
				if (textTypeWeSee < 5) {
					int randomOrder = Random.Range(0,finalScreenWrittens.informations.Length);
					informationText.GetComponent<Text> ().text = finalScreenWrittens.informations[randomOrder];
				}
				else if (textTypeWeSee > 5) {
					int randomOrder = Random.Range(0,finalScreenWrittens.words.Length);
					informationText.GetComponent<Text> ().text = finalScreenWrittens.words[randomOrder];
				}


			}
			informationText.SetActive (true);

			////LOOK AT THıS PART AGAıN!

			//Stop the player
			///NOTE: WE CAN DESTROY ANY COMPONENT BY THıS WAY; DESTROY(THE COMPONENT)
			Destroy (GameObject.Find ("player").GetComponent<player> ()); //Destroy the code file
			Destroy (GameObject.Find ("player").GetComponent<Rigidbody2D> ()); //Destroy the rigidbody

			//Show the ui buttons
			RestartButton.SetActive (true);
				//Restart's written will be changed
				RestartButton.GetComponentInChildren<Text>().text = restartWritten;
			homeButton.SetActive (true);
			musicButton.SetActive (true);
			soundButton.SetActive (true);
			screenSettingButton.SetActive (true);



		}
		else if (collision.tag == "balloon" && PlayerPrefs.GetInt ("gameMode") == 1) {
		
							//Destroy the balloon
			//We will make boombing balloon effect. So:
			GameObject ballonPartical =  collision.gameObject.GetComponent<balloonCode>().myChildPartical;
			//Active it
			ballonPartical.SetActive(true);
			//Destroy it
			Destroy(ballonPartical, 0.35f);
			//We will destroy the object after we' make it almost empty
			collision.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			Destroy(collision.gameObject.GetComponent<AudioSource> ());
			Destroy(collision.gameObject.GetComponent<BoxCollider2D> ());
			Destroy(collision.gameObject.GetComponent<SpriteRenderer> ());
			collision.gameObject.GetComponent<balloonCode> ().getRightNowBool = true;


			//Decreasing the score
			GameObject.Find("Camera").GetComponent<cameraCode>().score -= 1;
			GameObject.Find("Camera").GetComponent<cameraCode>().IncreasingScore();

			//When the score is smaller than 0
			if (GameObject.Find ("Camera").GetComponent<cameraCode> ().score <= 0) {

				//Play the game over sound effect and make the partical of the left magnetic
				gameObject.GetComponent<AudioSource> ().Play ();
				GameObject partical = Instantiate (particalOfLeftMagnatic, particalOfLeftMagnatic.GetComponentInParent<Transform> ().position, particalOfLeftMagnatic.GetComponentInParent<Transform> ().rotation);
				partical.SetActive (true); //Active it. Because it is passive
				Destroy (partical, 1f); //Destroy the partical system
				changingLeftSideColor = true; //Change left side magnetic's color


				//Final screen
				textTable.GetComponent<Text> ().fontSize = 50;
				//High score will be checked

				if (GameObject.Find ("Camera").GetComponent<cameraCode> ().scoreForEasyMode > PlayerPrefs.GetInt ("highScoreMode1")) {
					PlayerPrefs.SetInt ("highScoreMode1", GameObject.Find ("Camera").GetComponent<cameraCode> ().scoreForEasyMode);
				}

				//Show the scores
				textTable.SetActive(true);
				scoreTable.SetActive (false);
				textTable.GetComponent<Text> ().text = bestScore + PlayerPrefs.GetInt ("highScoreMode1") + "\n" + yourScore + GameObject.Find ("Camera").GetComponent<cameraCode> ().scoreForEasyMode.ToString ();

				//Information text game object will be shown

				//We look at the which language we selected
				if (PlayerPrefs.GetInt ("Language") == 1) {
					int randomOrder = Random.Range(0,finalScreenWrittens.kelimeler.Length);
					//int randomOrder = Time.time % finalScreenWrittens.kelimeler.Length;
					informationText.GetComponent<Text> ().text = finalScreenWrittens.kelimeler [randomOrder];
				} else {
					int randomOrder = Random.Range(0,finalScreenWrittens.words.Length);
					//int randomOrder = Time.time % finalScreenWrittens.words.Length;
					informationText.GetComponent<Text> ().text = finalScreenWrittens.words[randomOrder];
				}

				informationText.SetActive (true);

				////LOOK AT THıS PART AGAıN!

				//Stop the player
				///NOTE: WE CAN DESTROY ANY COMPONENT BY THıS WAY; DESTROY(THE COMPONENT)
				Destroy (GameObject.Find ("player").GetComponent<player> ()); //Destroy the code file
				Destroy (GameObject.Find ("player").GetComponent<Rigidbody2D> ()); //Destroy the rigidbody

				//Show the ui buttons
				RestartButton.SetActive (true);
					//Restart's written will be changed
					RestartButton.GetComponentInChildren<Text>().text = restartWritten;
				homeButton.SetActive (true);
				musicButton.SetActive (true);
				soundButton.SetActive (true);
				screenSettingButton.SetActive (true);
			}
		}


	}
}
