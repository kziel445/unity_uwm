using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1PlatformMove : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 finalPosition;
    public float xDistance = 5;
    public float zDistance = 5;
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private Vector3 direction;
    private Transform oldParent;


    void Start()
    {
        startPosition = transform.position;
        finalPosition = new Vector3(transform.position.x + xDistance,transform.position.y,transform.position.z + zDistance);
    }

    void FixedUpdate()
    {
        if (isRunningForward && transform.position.x >= finalPosition.x)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.x <= startPosition.x)
        {
            isRunning = false;
        }

        if (isRunning)
        {

            if (isRunningForward) direction = finalPosition;
            else if (isRunningBackward) direction = -finalPosition;
            //else direction = startPosition;

            Vector3 move = direction.normalized * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            Debug.Log(oldParent);
            other.gameObject.transform.parent = transform;

            if (transform.position.x >= finalPosition.x)
            {
                isRunningBackward = true;
                isRunningForward = false;

            }
            else if (transform.position.x <= startPosition.x)
            {
                isRunningBackward = false;
                isRunningForward = true;

            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
