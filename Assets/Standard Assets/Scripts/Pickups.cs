using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	private GameObject target;
	private PlayerEnergy currentEnergy;
	private Score scr;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player");
		currentEnergy = target.GetComponentInChildren <PlayerEnergy>();
		scr = target.GetComponentInChildren <Score> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D thing){
		Debug.Log ("Watermelon Collision!!" + thing);
		if(thing.tag == "Player"){
			Debug.Log ("Yummy!");
			Destroy(this.transform.parent.gameObject);
			currentEnergy.energy += 0.20f;
			scr.mainScore += 100.0f;
		}
	}
}
