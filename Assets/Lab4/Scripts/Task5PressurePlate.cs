using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5PressurePlate : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        YeetFunction(collider);
    }
    private void YeetFunction(Collider collider)
    {
        var objectToThrow = collider.GetComponent<Task4_4_1MoveController>();
        objectToThrow.Jump(objectToThrow.jumpHeight * 3);
    }
}
