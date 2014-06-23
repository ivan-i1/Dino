using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour {

	enum State {
		Idle,
		JumpTowardsPlayer,
		Jumping
	}

	public float AttackDistance = 3f;
	public float gravity = -15f;

	private GameObject target;
	private State currentState;
	private CharacterController2D _controller;
	private Vector3 _velocity;
	private PlayerEnergy currentEnergy;

	// Use this for initialization
	void Start () {
		currentState = State.Idle;

		_controller = GetComponent<CharacterController2D>();
		_controller.onControllerCollidedEvent += onControllerCollider;

		target = GameObject.FindWithTag ("Player");
		currentEnergy = target.GetComponentInChildren <PlayerEnergy>();
	}

	void OnTriggerEnter2D(Collider2D thing){
		Debug.Log ("Rabbit Collision!!" + thing);

		if(thing.tag == "Player"){
			Debug.Log ("Player Attacked!");

			if (currentState == State.Idle) {
				Destroy(this.transform.parent.gameObject);
				currentEnergy.energy += 0.05f;
			}
			else {
				currentEnergy.energy -= 0.20f;
			}
		}
	}

	void onControllerCollider( RaycastHit2D hit )
	{

	}

	IEnumerator WaitForAttack(float seconds)
	{
		Debug.Log ("B");
		yield return new WaitForSeconds (seconds);
		Debug.Log ("C");
		_velocity = target.transform.position - transform.position;
		_velocity.y += 1f;
		currentState = State.Jumping;
	}
	
	// Update is called once per frame
	void Update () {
		_velocity = _controller.velocity;
		bool isClose = Vector3.Distance (target.transform.position, transform.position) <= AttackDistance;

		switch (currentState) {
		case State.Idle:
			// - AttackDistance / 2.0f
			_velocity.x = 0f;

			if (target.transform.position.x > transform.position.x) {
				currentState = State.JumpTowardsPlayer;
			}
			break;

		case State.JumpTowardsPlayer:
			//WaitForAttack(0.5f);
			_velocity = target.transform.position - transform.position;
			_velocity.y += 5f;
			_velocity.x = Mathf.Min(2.0f, _velocity.x);
			//_velocity.x *= 1.5f;
			currentState = State.Jumping;
			break;

		case State.Jumping:
			if (_controller.isGrounded) {
				currentState = isClose ? State.JumpTowardsPlayer : State.Idle;
			}

			break;
		}

		_velocity.y += gravity * Time.deltaTime;
		_controller.move(_velocity * Time.deltaTime);
	}
}
