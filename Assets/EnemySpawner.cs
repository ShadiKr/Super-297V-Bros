using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawnPoint in gameObject.GetComponentInChildren<Transform>())
        {
            spawnPositions.Add(spawnPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
