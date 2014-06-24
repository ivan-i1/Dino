using UnityEngine;
using System.Collections;

public class ResizeCamera : MonoBehaviour {

	void Awake(){
		camera.orthographicSize = ((Screen.height/2.0f)/100f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
