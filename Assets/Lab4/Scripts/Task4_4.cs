using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    float xMax = 90;
    float xMin = -90;
    float mouseYMove;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouseYMove = Mathf.Clamp(mouseYMove, xMin, xMax);


        transform.localRotation = Quaternion.Euler(-mouseYMove, 0f, 0f);
        player.Rotate(Vector3.up * mouseXMove);
 

    }
}