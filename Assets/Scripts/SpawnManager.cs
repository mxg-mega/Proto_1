using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject player;

    private Vector3 targetSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        //InvokeRepeating("SpawnObstacles", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distanceToHorizon = Vector3.Distance(player.transform.position, targetSpawnPos);
        if (distanceToHorizon < 220)
        {
            SpawnObstacles();
        }

    }
    void SpawnObstacles() 
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

        targetSpawnPos = new Vector3(0, 0, targetSpawnPos.z + 20);

        Instantiate(obstaclePrefabs[obstacleIndex], targetSpawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
    
}
