using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float cubeWidth = 1;
    [SerializeField] private float spawnDelay = 0.25f;
    [SerializeField] private int amount = 10;
    private float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        spawnInArea(new Vector3(0, 1, 0), new Vector3(10, 1, 10));
    }
    void spawnInArea(Vector3 corner1, Vector3 corner2)
    {
        //cubes are spawned from center, so half of width are changed in max spawn area
        corner1 += new Vector3(cubeWidth/2, 0, cubeWidth / 2);
        corner2 += new Vector3(-cubeWidth / 2, 0, -cubeWidth / 2);
        if (amount > 0)
        {
            if (Time.time >= nextSpawnTime)
            {
                Vector3 randomVector = new Vector3(Random.Range(corner1.x, corner2.x), corner1.y, Random.Range(corner1.z, corner2.z));
                do
                {   
                    if (checkIfFree(randomVector, cubeWidth))
                    {
                        Debug.Log("Spawn");
                        Spawn(randomVector);
                        amount--;
                        if (amount == 0) Debug.Log("All cubes spawned");
                        break;
                    }
                    Debug.Log("Bad position!");
                    randomVector = new Vector3(Random.Range(corner1.x, corner2.x), corner1.y, Random.Range(corner1.z, corner2.z));
                } while (!checkIfFree(randomVector, cubeWidth));
            }
        }
    }
    void Spawn(Vector3 position)
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(cube, position, transform.rotation);
    }
    bool checkIfFree(Vector3 center, float cubeWidth)
    {
        var checkResult = Physics.OverlapBox(center, new Vector3(cubeWidth / 2, cubeWidth / 2, cubeWidth / 2));
        if (checkResult.Length == 0)
        {
            return true;
        }
        return false;
    }
}

