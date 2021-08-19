using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gg : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.UnloadLevel("2");
        Application.LoadLevel("Beginning");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
