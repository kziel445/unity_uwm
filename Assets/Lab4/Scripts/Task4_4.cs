using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    float mouseXMove = 0f;
    float mouseYMove = 0f;

    float xMax = 90;
    float xMin = -90;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseXMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseYMove = Mathf.Clamp(mouseYMove, -90f, 90f);

        transform.eulerAngles = new Vector3(mouseYMove, 0, 0);
        // wykonujemy rotację wokół osi Y
        //player.transform.eulerAngles = new Vector3(0,mouseXMove,0);

        // a dla osi X obracamy kamerę dla lokalnych koordynatów
        // -mouseYMove aby uniknąć ofektu mouse inverse
        //transform.rotation = Quaternion.Euler(-mouseYMove, 0f, 0f);
        //transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);

    }
}