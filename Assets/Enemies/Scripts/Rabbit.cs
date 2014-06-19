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

	private GameObject target;
	private State currentState;
	private CharacterController2D _controller;
	private Vector3 _velocity;

	// Use this for initialization
	void Start () {
		currentState = State.Idle;

		_controller = GetComponent<CharacterController2D>();
		_controller.onControllerCollidedEvent += onControllerCollider;

		target = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log("AAAA");
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

		switch (currentState) {
		case State.Idle:
			if (target.transform.position.x > transform.position.x &&
			    Vector3.Distance (target.transform.position, transform.position) <= AttackDistance) {
				currentState = State.JumpTowardsPlayer;
			}
			break;

		case State.JumpTowardsPlayer:
			WaitForAttack(0.5f);
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
