using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawnPositions;
    public float waitTime = 1f;
    public int rateOfSpawn = 1;
    public int startTime = 0;
    public GameObject objectToSpawn;

    private Transform spawnPosition;
    private bool didSpawn = false;
    private bool startSpawning = false;
    private bool initialSpawn;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawnPoint in gameObject.GetComponentInChildren<Transform>())
        {
            spawnPositions.Add(spawnPoint);
        }
        StartCoroutine(startSpawnObject(startTime));
    }

    void FixedUpdate()
    {
        if (startSpawning)
        {
            if (initialSpawn == false)
            {
                if (!didSpawn)
                {
                    StartCoroutine(SpawnObject(0));
                    initialSpawn = true;
                }
            }
            else
            {
                if (!didSpawn)
                {
                    StartCoroutine(SpawnObject(waitTime));
                }
            }
        }
    }

    void SpawnRandom()
    {
        for (int i = 0; i < rateOfSpawn; i++)
        {
            spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
            Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);
        }
    }

    IEnumerator SpawnObject(float wait)
    {
        didSpawn = true;
        yield return new WaitForSeconds(wait);
        SpawnRandom();
        didSpawn = false;
    }

    IEnumerator startSpawnObject(float start)
    {
        startSpawning = false;
        yield return new WaitForSeconds(start);
        startSpawning = true;
    }
}
