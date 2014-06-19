using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Start!");
		Debug.Log ("Trigger: " + BoxCollider2D.isTrigger);
	}

	// Update is called once per frame
	void Update () {
		//if(target.collider.gameObject){
		//	Destroy(target);
		//}

	/*void OnTriggerEnter2D(Collider2D target){
			Destroy(gameObject);
	}*/

	/*void OnCollision(){
			Destroy(gameObject);
	}*/


	void OnTriggerEnterD2(Collider2D player){
		Debug.Log ("Trigger2D");
		Destroy (player.gameObject);
		}
}
