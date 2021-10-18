using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task3 : MonoBehaviour
{
    [SerializeField] public float speed;
    Rigidbody rigidbody;
    Vector3 velocity = new Vector3(0, 0, 0);
    Vector3 startPosition;
    int i = 0;
    List<Vector3> directions = new List<Vector3>()
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 0, 1),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, -1),
    };

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = rigidbody.transform.position;
    }

    void FixedUpdate()
    {
        goInCircles();        
    }
    public void goInCircles()
    {
        if (Vector3.Distance(startPosition, rigidbody.transform.position)>=10)
        {
            rotate(rigidbody);
            startPosition = rigidbody.transform.position;
            if (i == 3) i = 0;
            else i++;
        }
        goDirection(directions[i]);
    }
    public void goDirection(Vector3 direction)
    {
        velocity = direction.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + velocity);
    }
    public void rotate(Rigidbody rigidbody)
    {
        rigidbody.transform.Rotate(0, 90, 0);
    }

}
