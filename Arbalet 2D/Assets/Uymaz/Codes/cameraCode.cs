using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraCode : MonoBehaviour {

	//Canvas Items
		//Score
	public GameObject scoreTable;
	public int score = 0;
	public int scoreForEasyMode = 0;
		//When game over
	public GameObject musicButton;
	public GameObject soundButton;

	//Screen Setting
	public float width;
	public float height;


	//Ballons
	public GameObject[] balloons;
		//Balloon's speed
	public float balloonSpeed = 300;
		//Coefficient of speed. We should select height of the Screen. Because balloons will move along the height of the Screen
	float coefficientOfSpeed;
		//Pieces of making balloons
	public int piecesOfMakingBalloon = 5;
		//Time to make new balloon
	public int timeForNewBalloon = 1;
		//Range of making ballon
	public GameObject leftRangeGameObject;
	public GameObject rightRangeGameObject;
	float leftRange;
	float rightRange;
	float heightOfRange;
	float ZPositionOfRange; //We can take advantage of background. Dont forget that the new balloons will not be children of Camera. 
		//Making Balloon Time
	public float balloonTime = 2; //We will get this value from balloonCode
		

	//Min & Max Game Speed for Challenge Mode
	public float minGameSpeed;
	public float maxGameSpeed;

	//Game Speed's Increase (When we shoot the balloon, the game will be faster)
	//DONT FORGET THAT! Game Speed involves all the game. So we should write Time.timeScale = 1 in Start() function
	public float increaseGameSpeed = 0.001f; 

		
	void Awake()
	{
		//We need to edit the camera's scales. We need to get these values before in the beginning. We must be ready

		//For X
		//gameObject.GetComponent<Transform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScreenScaleX"), gameObject.GetComponent<Transform>().localScale.y, gameObject.GetComponent<Transform>().localScale.z); 



		//For Y
		//gameObject.GetComponent<Transform>().localScale = new Vector3(gameObject.GetComponent<Transform>().localScale.x, PlayerPrefs.GetFloat("ScreenScaleY"), gameObject.GetComponent<Transform>().localScale.z); 

		//width = Screen.width / Screen.height;
		//height = Screen.height / 800f;
		//Debug.Log (width + "x" + height);
		//gameObject.GetComponent<Transform>().localScale = new Vector3(width, height, gameObject.GetComponent<Transform>().localScale.z); 

		//We have only 1 game scene and 3 modes. So we should increase the game speed for third mode
			//If the game mode is 3 and the game speed is lower than game speed which is for right now
		if (PlayerPrefs.GetInt ("gameMode") == 3 && Time.timeScale < maxGameSpeed) {
			//We start the game with MinGameSpeed
			Time.timeScale = minGameSpeed;

			gameObject.GetComponent<cameraCode> ().increaseGameSpeed = 0.03f;
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

	// Use this for initialization
	void Start () {
		//Game speed should be: 1 if the gameMode isn't 3
		if (PlayerPrefs.GetInt ("gameMode") == 3) {
			
			//We start the game with MinGameSpeed
			Time.timeScale = minGameSpeed;
		
		} else if (PlayerPrefs.GetInt ("gameMode") == 1 || PlayerPrefs.GetInt ("gameMode") == 2) {

			//We start the game with 1f
			Time.timeScale = 1f;
		}






		//Background music continues on its time
		gameObject.GetComponent<AudioSource>().time = PlayerPrefs.GetFloat("musicTime");

		//CHECK THE ıCONS' SıTUATıONS
		//Music
		if (PlayerPrefs.GetInt ("musicTurning") % 2 == 0) {

			musicButton.GetComponent<Image> ().sprite = musicButton.GetComponent<Restart> ().musicSpritePlaying;
		
		} else {
			
			//Turn off the background music
		    gameObject.GetComponent<AudioSource>().Stop();

			//Mute icon
			musicButton.GetComponent<Image> ().sprite = musicButton.GetComponent<Restart> ().spriteMute;

		}
		//Sound
		if (PlayerPrefs.GetInt ("soundEffectTurning") % 2 == 0) {
		
			soundButton.GetComponent<Image> ().sprite = soundButton.GetComponent<Restart> ().soundSpritePlaying;
		
		} else {
			
			//Turn off the sound effects
			GameObject.Find ("balloonA").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonB").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonC").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonD").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonE").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("balloonF").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("bulletPrefab").GetComponent<AudioSource> ().mute = false;
			GameObject.Find ("electricLine").GetComponent<AudioSource> ().mute = false;
			//Mute icon
			soundButton.GetComponent<Image> ().sprite = soundButton.GetComponent<Restart>().spriteMute;
		}




		//We need to get the positions of making ballon ranges
			//For position's X
		leftRange = leftRangeGameObject.transform.position.x;
		rightRange = rightRangeGameObject.transform.position.x;
			//For position's Y
		heightOfRange = leftRangeGameObject.transform.position.y;
			//For position's Z //We will get Z position of background
		ZPositionOfRange = GameObject.Find("background").transform.position.z;

		//We get the height of screen to determine speed of balloons
		coefficientOfSpeed = gameObject.transform.localScale.y;
		balloonSpeed *= coefficientOfSpeed;

		//We get the balloon objects. They've had to be resized in awake by their parent. So they must be available for the screen
			//NOTE: WE GET ONLY SCALE OF THEM. NOT POSıTON OR ROTATıON
		balloons[0] = GameObject.Find("balloonA");
		balloons [0].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonA").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonA").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonA").GetComponent<Transform>().lossyScale.z);

		balloons[1] = GameObject.Find("balloonB");
		balloons [1].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonB").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonB").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonB").GetComponent<Transform>().lossyScale.z);

		balloons[2] = GameObject.Find("balloonC");
		balloons [2].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonC").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonC").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonC").GetComponent<Transform>().lossyScale.z);

		balloons[3] = GameObject.Find("balloonD");
		balloons [3].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonD").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonD").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonD").GetComponent<Transform>().lossyScale.z);

		balloons[4] = GameObject.Find("balloonE");
		balloons [4].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonE").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonE").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonE").GetComponent<Transform>().lossyScale.z);

		balloons[5] = GameObject.Find("balloonF");
		balloons [5].GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find("balloonF").GetComponent<Transform>().lossyScale.x, GameObject.Find("balloonF").GetComponent<Transform>().lossyScale.y, GameObject.Find("balloonF").GetComponent<Transform>().lossyScale.z);

	}
	
	// Update is called once per frame
	void Update () {





		//We make some balloons in the beginning
		if (piecesOfMakingBalloon != 0) {
			makingBalloon ();
			piecesOfMakingBalloon--;

		}
			

		//We make balloon when the player shootes any of them





	}

	//If we say "public" we can reach this function with other script files. Otherwise, we cant reach with other script files.
	public void IncreasingScore()
	{
		scoreTable.GetComponent<Text> ().text = score.ToString();
	}

	public void makingBalloon()
	{
		//We select a random number and make the balloon of the number 
		int balloonNumber = Random.Range (0, 5);

		//We can edit the positions of the objects, again!
			//The positions of new balloons must be interval in leftRange and rightRange
			//We've determined the Y position of the new balloons in Start function
			//We can determine the Z position of new balloons
		switch (balloonNumber) {
		case 0:
			GameObject newBalloonA = Instantiate (balloons [0], new Vector3 (Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonA.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;
		case 1:
			GameObject newBalloonB = Instantiate(balloons[1], new Vector3(Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonB.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;
		case 2:
			GameObject newBalloonC = Instantiate(balloons[2], new Vector3(Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonC.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;
		case 3:
			GameObject newBalloonD = Instantiate(balloons[3], new Vector3(Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonD.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;
		case 4:
			GameObject newBalloonE = Instantiate(balloons[4], new Vector3(Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonE.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;
		case 5:
			GameObject newBalloonF = Instantiate(balloons[5], new Vector3(Random.Range(leftRange, rightRange), heightOfRange, ZPositionOfRange ), gameObject.transform.rotation);
			newBalloonF.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, balloonSpeed);
			break;

		}
	}

	void onApplicationQuit() {
		PlayerPrefs.SetFloat ("musicTime", 0);
	}
}
