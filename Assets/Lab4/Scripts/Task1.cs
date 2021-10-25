using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Task1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    // task 1.1
    public int objectToSpawn=1;
    private float xPlatform, zPlatform;
    public List<Material> materials = new List<Material>();

    void Start()
    {
        xPlatform = this.gameObject.GetComponent<Collider>().bounds.size.x;
        zPlatform = this.gameObject.GetComponent<Collider>().bounds.size.z;
        Debug.Log(xPlatform + " " + zPlatform);
        Debug.Log(-(int)xPlatform + " " + -(int)zPlatform);
        // w momecie uruchomienia generuje objectToSpawn kostek w zakresie od -xPlatform(jako wspolrzedna) bierze xPlatform elementów
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)-xPlatform/2,(int)xPlatform).OrderBy(x => Guid.NewGuid()).Take(objectToSpawn));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)-zPlatform/2,(int)zPlatform).OrderBy(x => Guid.NewGuid()).Take(objectToSpawn));
        Debug.Log(xPlatform + " " + zPlatform);
        for(int i=0; i<objectToSpawn; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            //Random rnd = new Random();
            this.block.GetComponent<MeshRenderer>().material=materials[Random.Range(0,5)];
            Instantiate(this.block, transform.localPosition + pos, Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}