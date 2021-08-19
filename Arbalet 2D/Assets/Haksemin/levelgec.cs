using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelgec : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.UnloadLevel("uidesign");
		PlayerPrefs.SetFloat ("musicTime", GameObject.Find ("Camera").GetComponent<AudioSource> ().time);
		Application.LoadLevel("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
