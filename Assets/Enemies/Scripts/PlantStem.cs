using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantStem : MonoBehaviour
{
    public float Wiggle = 0.15f;
    public float WiggleSpeed = 4f;
    public float EnergyRecoverAmount = 0.15f;

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
            Destroy(this.transform.parent.gameObject);
            other.GetComponent<PlayerEnergy>().energy += EnergyRecoverAmount;
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
