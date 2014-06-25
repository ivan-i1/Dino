﻿using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    public float Damage = 0.35f;

    public float Wiggle = 0.15f;
    public float WiggleSpeed = 4f;

    public bool Wiggles = true;

    private Vector3 _origPosition;

    // Use this for initialization
    void Start()
    {
        _origPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerEnergy>().energy -= Damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Wiggles)
        {
            this.transform.position = _origPosition + new Vector3(Mathf.Sin((Time.time + this.transform.position.y) * WiggleSpeed) * Wiggle, 0f, 0f);
        }
    }
}
