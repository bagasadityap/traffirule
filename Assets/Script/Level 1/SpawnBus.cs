using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBus : MonoBehaviour
{
    public GameObject busPrefab;
    public GameObject carPrefab;
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }

    void Spawn()
    {
        if (!FindObjectOfType<TrafficController>().canWalk)
        {
            var RandomValue = UnityEngine.Random.Range(1,3);
            if (RandomValue == 1)
            {
                Instantiate(busPrefab, transform.GetChild(0).position, Quaternion.identity);
            }
            else
            {
                Instantiate(carPrefab, transform.GetChild(0).position, Quaternion.identity);
            }       
        }

    }
}
