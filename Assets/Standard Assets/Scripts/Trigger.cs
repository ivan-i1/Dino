using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		//Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D thing){

		if(thing.tag == "Player"){
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
