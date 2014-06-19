using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public string currentLevel, levelSwitch;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			reset();
		}
	}
	
	void OnTriggerEnter2D(Collider2D thing){
		Debug.Log ("Collision!!");
		reset ();
	}
	
	void reset(){
		Application.LoadLevel (currentLevel);
	}
	
}
