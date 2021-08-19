using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	//Rigidbody
	Rigidbody2D myRB;

	//Moving
	public int movingDirection = 0; //0 is right, 1 is left
	public float speed = 1400;
	public float coefficientSpeed; //We must consider width of the screen
	//The player's Children
	public GameObject leftChild;
	public GameObject rightChild;
	//The target children
	public GameObject leftPolarPosition;
	public GameObject rightPolarPosition;
	//Distance for tolerance
	public float distanceTolerance = 0.3f;

	//Shooting
	public GameObject maze;
	public GameObject bullet;
	public float bulletSpeed = 1250;
	public float coefficientSpeedOfBullet; //We must consider height of the screen
		//Shooting Time
	public bool canShoot = true;
		//They must be same
	public float waitingForShooting = 1f;
	public float waitingForShootingStore = 1f;
		//Increasing of the waiting time
	public float decreasingOfWaitingOfShooting = 0.04f;
		//Hiding image of the bullet on the arbalet
	public GameObject bulletImage;
		//We make animation of the arbalet
	public GameObject arbaletA;
	public GameObject arbaletB;



	// Use this for initialization
	void Awake()
	{

	}
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();

		//We should get width of the screen as speed of coefficient. It is important. Because every screen will not be same with each other
		coefficientSpeed = GameObject.Find("Camera").GetComponent<Transform>().localScale.x;
		speed *= coefficientSpeed;

		//We should get height of the screen as bullet's speed of coefficient.
		coefficientSpeedOfBullet = GameObject.Find("Camera").GetComponent<Transform>().localScale.y;
		bulletSpeed *= coefficientSpeedOfBullet;

	}
	
	// Update is called once per frame
	void Update () {

					//MAKE BELOW LıNE CODE (ıF STATEMENT!) !
		//Make constant the bullet speed. We'd like to hold speed of the bullet after time scale will be bigger than 1.6f
		if (Time.timeScale >= 1.6f) {
			
		}

		//Moving
		if (movingDirection == 0) {
			myRB.velocity = new Vector2 (speed * Time.deltaTime, 0);
		}
		else if(movingDirection == 1)
		{
			myRB.velocity = new Vector2 (-speed * Time.deltaTime, 0);
		}

		//Collision with the Magnetics' children

		//When the player moves right (direnction = 0) && the player's position.x is equal to or bigger than rightPolarPosition.x;
		if (movingDirection == 0 && rightChild.transform.position.x + distanceTolerance >= rightPolarPosition.transform.position.x) {
			movingDirection = 1; //We need to return, left
		}
		//When the player moves left (direnction = 1) && the player's position.x is equal to or smaller than leftPolarPosition.x;
		else if (movingDirection == 1 && leftChild.transform.position.x - distanceTolerance <= leftPolarPosition.transform.position.x) {
			movingDirection = 0; //We need to return, right
		}
			
		//Shooting
		if (Input.GetMouseButtonDown (0) && canShoot == true) {
			GameObject newBullet = Instantiate (bullet, maze.transform.position, maze.transform.rotation);
			//We should edit scale of the bullet. We take advantage of prefab 
			newBullet.GetComponent<Transform> ().localScale = new Vector3 (GameObject.Find ("bulletPrefab").GetComponent<Transform> ().lossyScale.x, GameObject.Find ("bulletPrefab").GetComponent<Transform> ().lossyScale.y, GameObject.Find ("bulletPrefab").GetComponent<Transform> ().lossyScale.z);
			newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, bulletSpeed * Time.deltaTime);

			//Play the sound effect of the new bullet (except the sound effects haven't been turned off)
			if (PlayerPrefs.GetInt ("soundEffectTurning") % 2 == 0){
				newBullet.GetComponent<AudioSource> ().Play ();
			}


			//Now, we wait to shoot again
			canShoot = false;
			//Hide the image of the arbalet
			bulletImage.SetActive(false);

			//Switch arbalet's images
			arbaletA.SetActive(false);
			arbaletB.SetActive (true);

		} else if (canShoot == false) {
			//If we have a break for game, the bullet will not be loaded
			if (Time.timeScale != 0) {
				waitingForShooting -= decreasingOfWaitingOfShooting;
			}


				if(waitingForShooting <= 0)
					{
						//We can shoot again
						canShoot = true;
						//Waiting time is old version of it
						waitingForShooting = waitingForShootingStore;
						//Show the image of the arbalet
				bulletImage.SetActive(true);

				//Switch arbalet's images
				arbaletB.SetActive(false);
				arbaletA.SetActive (true);
					}
		}

	}
}
