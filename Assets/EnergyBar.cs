using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	public float barDisplay = 0;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size= new Vector2(60,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	private PlayerEnergy player;

	void Start()
	{
		var p = GameObject.FindGameObjectWithTag ("Player");
		player = p.GetComponentInChildren<PlayerEnergy> ();
	}

	void OnGUI()
	{
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect(0,0, size.x, size.y), progressBarEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),progressBarFull);
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}

	void Update()
	{
		barDisplay = player.energy;
	}
}
