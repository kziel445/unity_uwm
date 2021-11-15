using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3MovingPlatform : MonoBehaviour
{
    //list of waypoints
    public List<Vector3> waypoints;
    public int waypointCounter=-1;
    public bool counterAsc = true;
    public bool isRunning = true;
    public Vector3 direction;
    public float speed = 10;

    private void Awake()
    {
        waypoints.Insert(0, transform.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRunning)
        {
            if (transform.position == direction)
            {
                if (counterAsc)
                {
                    waypointCounter++;
                    if (waypoints.Count-1 <= waypointCounter) counterAsc = false;
                }
                else if (!counterAsc)
                {
                    waypointCounter--;
                    if (0 > waypointCounter) counterAsc = true;
                }

            }
            direction = waypoints[waypointCounter];
            Debug.Log(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }
    }
}
