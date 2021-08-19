using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Destroying the balloon and the bullet
		if (collision.tag == "balloon") {
				

			//Play the booming effect of the balloon (except the sound effects haven't been turned off)
			if (PlayerPrefs.GetInt ("soundEffectTurning") % 2 == 0) {
				GameObject.Find (collision.name.Replace("balloon" + collision.name[7] + "(Clone)", "balloon" + collision.name[7]) ).GetComponent<AudioSource>().Play();
			}

			//We will make boombing balloon effect. So:
			GameObject ballonPartical =  collision.gameObject.GetComponent<balloonCode>().myChildPartical;
				//Active it
			ballonPartical.SetActive(true);
				//Destroy iy
			Destroy(ballonPartical, 0.35f);


			//We will destroy the object after we' make it almost empty
			collision.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
			Destroy(collision.gameObject.GetComponent<AudioSource> ());
			Destroy(collision.gameObject.GetComponent<BoxCollider2D> ());
			Destroy(collision.gameObject.GetComponent<SpriteRenderer> ());
			collision.gameObject.GetComponent<balloonCode> ().getRightNowBool = true;
			//Destroy (collision.gameObject, 2);
			Destroy (gameObject);

			//Increasing the score
			GameObject.Find("Camera").GetComponent<cameraCode>().score += 1;

			if (PlayerPrefs.GetInt ("gameMode") == 1) { // For easy mode
				GameObject.Find ("Camera").GetComponent<cameraCode> ().scoreForEasyMode += 1;
			}

			GameObject.Find("Camera").GetComponent<cameraCode>().IncreasingScore();

			//We can shoot again
			GameObject.Find("player").GetComponent<player>().waitingForShooting = 0;

			//Be faster the game (if game speed isn't bigger than 2)
			if (Time.timeScale <= 2) {
					Time.timeScale += GameObject.Find("Camera").GetComponent<cameraCode>().increaseGameSpeed;
					//We need to decrease of the bullet's waiting time (shooting store). Becase game's speed has been increased
					GameObject.Find("player").GetComponent<player>().waitingForShootingStore /= Time.timeScale;
			}


			//Making new ballon. However, we cant make the balloon instantly. Because we should give some times to player to breathe

			//GameObject.Find("Camera").GetComponent<cameraCode>().makingBalloon();
		}


	}

















}
