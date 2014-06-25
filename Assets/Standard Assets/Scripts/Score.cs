using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float mainScore;
	private float advanceRate = 20f;
	private float current = 0f;

	// Use this for initialization
	void Start () {
		mainScore = 0f;
		current = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		current += Time.deltaTime * advanceRate;
		
		if (current > 9.9f) {
			current = 0f;
			mainScore += 10f;
		}
	}

	void OnGUI(){
		GUI.Box (new Rect(10,10,100,25),("Score: "+(int)mainScore));
	}
}
