using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody rb;


    public Vector3 velocity;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            velocity = rb.velocity;
            velocity.x = transform.forward.x * speed;
            velocity.z = transform.forward.z * speed;
            rb.velocity = velocity;
        }
        if (Input.GetKey("s"))
        {
            velocity = rb.velocity;
            velocity.x = transform.forward.x * -speed;
            velocity.z = transform.forward.z * -speed;
            rb.velocity = velocity;
        }
        if (Input.GetKey("a"))
        {
            velocity = rb.velocity;
            velocity.x = transform.right.x * -speed;
            velocity.z = transform.right.z * -speed;
            rb.velocity = velocity;
        }
        if (Input.GetKey("d"))
        {
            velocity = rb.velocity;
            velocity.x = transform.right.x * speed;
            velocity.z = transform.right.z * speed;
            rb.velocity = velocity;
        }
    }
}
