using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject duckPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 2f);
    }

    private void SpawnEnemy()
    {
        Instantiate(duckPrefab, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
