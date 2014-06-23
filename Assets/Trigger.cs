using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public string currentLevel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D thing){
		Debug.Log ("Collision!!" + thing);
		if(thing.tag == "Danger"){
			Debug.Log ("Danger Touched");
			reset ();
		}
	}
	
	void reset(){
		Application.LoadLevel (currentLevel);
	}
	
}
