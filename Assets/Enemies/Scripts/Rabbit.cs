using UnityEngine;
using System.Collections;

public class Rabbit : MonoBehaviour {

	enum State {
		Idle,
		JumpTowardsPlayer,
		Jumping
	}

	public float AttackDistance = 5f;
	public float gravity = -25f;
	public GameObject target;

	private State currentState;
	private CharacterController2D _controller;
	private Vector3 _velocity;

	// Use this for initialization
	void Start () {
		currentState = State.Idle;

		_controller = GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {
		_velocity = _controller.velocity;

		switch (currentState) {
		case State.Idle:
			if (target.transform.position.x - AttackDistance / 2.0f > transform.position.x &&
			    Vector3.Distance (target.transform.position, transform.position) < AttackDistance) {
				currentState = State.JumpTowardsPlayer;
			}
			break;

		case State.JumpTowardsPlayer:
			_velocity = target.transform.position - transform.position;
			_velocity.y += 1f;
			currentState = State.Jumping;
			break;

		case State.Jumping:
			if (_controller.isGrounded) {
				currentState = State.Idle;
			}

			break;
		}

		_velocity.y += gravity * Time.deltaTime;
		_controller.move(_velocity * Time.deltaTime);
	}
}
