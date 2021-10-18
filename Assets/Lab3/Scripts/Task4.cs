using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4 : MonoBehaviour
{
    [SerializeField] public float speed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        var collidedWith = collision.gameObject;
        if(collidedWith.tag=="Obstacle")
        {
            //on collision object change color to black
            collidedWith.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            //message with what player collided
            Debug.Log("hit " + collision.gameObject.tag);
        }
    }
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + velocity);
    }
}
