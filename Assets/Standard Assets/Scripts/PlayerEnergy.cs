using UnityEngine;
using System.Collections;

public class PlayerEnergy : MonoBehaviour {

	public float energy = 1f;

	public float energyDrainRate = 0.05f;
	public float resetAfterDeathTime = 5f;

	public string currentLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		energy -= Time.deltaTime * energyDrainRate;
		energy = Mathf.Min(1.0f, energy);

		if (energy <= 0 || Input.GetKeyDown(KeyCode.Return)) {
			Die ();
		}
	}

	void Die() {
		Destroy (this.transform.parent.gameObject);
		Application.LoadLevel (Application.loadedLevel);
	}
}
