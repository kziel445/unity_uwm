using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] public float speed;
    Rigidbody rigidbody;
    Vector3 velocity = new Vector3(0, 0, 0);
    bool goRight = true;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = rigidbody.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //
        if(rigidbody.transform.position.x > startPosition.x+10)
        {
            goRight = false;
        }
        else if(rigidbody.transform.position.x < startPosition.x)
        {
            goRight = true;
        }
        if(goRight) velocity = new Vector3(1, 0, 0);
        else velocity = new Vector3(-1, 0, 0);
        velocity = velocity.normalized * speed * Time.deltaTime;
        
        rigidbody.MovePosition(transform.position + velocity);
    }
}
