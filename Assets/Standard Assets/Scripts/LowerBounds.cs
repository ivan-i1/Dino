using UnityEngine;
using System.Collections;

public class LowerBounds : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Hurt(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
