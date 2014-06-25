using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    public float Damage = 0.35f;

    public float Wiggle = 0.15f;
    public float WiggleSpeed = 4f;

    public int StemCount = 4;

    public bool StemGoesDown = true;

    public bool Wiggles = true;

    public GameObject Stem;

    private Vector3 _origPosition;

    // Use this for initialization
    void Start()
    {
        _origPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject s = Stem;

        for (int i = 1; i < StemCount; i++)
        {
            s = Instantiate(Stem, Stem.transform.position + new Vector3(0f, 0.15f * i * (StemGoesDown ? -1f : 1f), 0f), new Quaternion()) as GameObject;
            s.transform.parent = this.gameObject.transform.parent.transform;
        }

        s.GetComponent<PlantStem>().Wiggles = false;
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
