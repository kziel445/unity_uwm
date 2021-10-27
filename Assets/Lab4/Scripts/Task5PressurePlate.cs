using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5PressurePlate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider objectToThrow)
    {
        Debug.Log("Hop " + objectToThrow);
    }
}
