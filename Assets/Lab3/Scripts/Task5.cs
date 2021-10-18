using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float cubeWidth=1;
    [SerializeField] private float spawnDelay = 1;
    [SerializeField] private int amount = 10;
    private float nextSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnInArea(new Vector3(0, 1, 0), new Vector3(10, 1, 10));
    }
    void Spawn(Vector3 position)
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(cube, position, transform.rotation);
    }
    void spawnInArea(Vector3 corner1, Vector3 corner2)
    {
        //cubes are spawned from center, so half of width are changed in max spawn area
        corner1 += new Vector3(0.5f, 0, 0.5f);
        corner2 += new Vector3(-0.5f, 0, -0.5f);
        if (amount > 0)
        {
            if (Time.time >= nextSpawnTime)
            {
                Vector3 randomVector = new Vector3(Random.Range(corner1.x, corner2.x), corner1.y, Random.Range(corner1.z, corner2.z));
                while (checkIfFree(randomVector, cubeWidth))
                {
                    if (checkIfFree(randomVector, cubeWidth))
                    {
                        Spawn(randomVector);
                        amount--;
                    }
                    randomVector = new Vector3(Random.Range(corner1.x, corner2.x), corner1.y, Random.Range(corner1.z, corner2.z));
                };
            }
        }
    }
    bool checkIfFree(Vector3 center, float cubeWidth)
    {
        cubeWidth /= 2;
        Collider[] colliderArray = Physics.OverlapBox(center, new Vector3(cubeWidth, cubeWidth, cubeWidth));
        Debug.Log(cubeWidth + " " + center);
        foreach(Collider collider in colliderArray)
        {
            GameObject objects = collider.GetComponent<GameObject>();
            Debug.Log("something");
            if (objects != null) return false;
        }
        return true;
    }
}

