using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DamageTile : MonoBehaviour
{
    public float Damage = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                other.GetComponentInChildren<PlayerEnergy>().energy -= Damage;
                break;

            case "Enemy":
                Destroy(other.transform.parent.gameObject);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
