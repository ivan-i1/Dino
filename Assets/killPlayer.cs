using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target.collider.gameObject){
			Destroy(target);
		}
	}
}
