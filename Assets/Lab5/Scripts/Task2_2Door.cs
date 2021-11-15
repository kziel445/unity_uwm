using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2_2Door : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 finalPosition;
    public bool goingToOpen = false;
    public bool isRunning = false;
    public float speed;
    private Vector3 direction;
    // Start is called before the first frame update

    void Start()
    {
        startPosition = transform.position;
        finalPosition = transform.position + finalPosition;
    }

    void FixedUpdate()
    {
         if (goingToOpen) direction = finalPosition;
         else direction = startPosition;
         transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);

    }
}
