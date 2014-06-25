﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    // movement config
    public float gravity = -25f;
    public float runSpeed = 8f;
    public float groundDamping = 20f; // how fast do we change direction? higher means faster
    public float jumpHeight = 3f;
    public float maxFallSpeed = 20f;

    [HideInInspector]
    private float normalizedHorizontalSpeed = 0;

    private CharacterController2D _controller;
    //private Animator _animator;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 _velocity;

    void Awake()
    {
        //_animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController2D>();

        // listen to some events for illustration purposes
        _controller.onControllerCollidedEvent += onControllerCollider;
    }


    #region Event Listeners

    void onControllerCollider(RaycastHit2D hit)
    {
        // _controller.skinWidth = 0.22f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("BBBB");
        }
    }

    #endregion


    // the Update loop contains a very simple example of moving the character around and controlling the animation
    void Update()
    {
        // grab our current _velocity to use as a base for all calculations
        _velocity = _controller.velocity;

        if (_controller.isGrounded)
            _velocity.y = 0;

        normalizedHorizontalSpeed = 1;
        if (transform.localScale.x < 0f)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        //if( _controller.isGrounded )
        //	_animator.Play( Animator.StringToHash( "Run" ) );

        if (_velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _velocity.y = 0;
        }

        // we can only jump whilst grounded
        if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            //_animator.Play( Animator.StringToHash( "Jump" ) );
        }


        // apply horizontal speed smoothing it
        _velocity.x = Mathf.Lerp(_velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * groundDamping);

        // apply gravity before moving
        _velocity.y = Mathf.Min(_velocity.y + gravity * Time.deltaTime, maxFallSpeed);

        _controller.move(_velocity * Time.deltaTime);
    }
}