using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2SlideDoor : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public List<GameObject> doors;
    public float openWide = 5;

    // Start is called before the first frame update

    
    public void OnTriggerEnter(Collider other)
    {
        foreach(GameObject door in doors)
        {
            Task2_2Door doorStatus = door.GetComponent<Task2_2Door>();
            doorStatus.goingToOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject door in doors)
        {
            Task2_2Door doorStatus = door.GetComponent<Task2_2Door>();
            doorStatus.goingToOpen = false;
        }
    }
}
