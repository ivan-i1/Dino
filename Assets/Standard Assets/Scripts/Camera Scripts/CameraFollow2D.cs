using UnityEngine;
using System.Collections;

public class CameraFollow2D : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            Vector3 targetPosition = target.position + new Vector3(2.5f, 0, 0);
            //targetPosition.y = 1.5f;
            Vector3 point = camera.WorldToViewportPoint(targetPosition);
            Vector3 delta = targetPosition - camera.ViewportToWorldPoint(new Vector3(0.3f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

		/*
		var z = target.position.z -dampTime;
		var y = 0;
		var x = target.position.x;
		transform.position = new Vector3(x, y,z);
		*/
    }
}