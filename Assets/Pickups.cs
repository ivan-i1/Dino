﻿using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	private GameObject target;
	private PlayerEnergy currentEnergy;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player");
		currentEnergy = target.GetComponentInChildren <PlayerEnergy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D thing){
		Debug.Log ("Rabbit Collision!!" + thing);
		if(thing.tag == "Player"){
			Debug.Log ("Yummy!");
			currentEnergy.energy += 0.20f;
		}
	}
}
