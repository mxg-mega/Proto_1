using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject track;
    public Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = Vector3.zero;
        for (int i = 0; i < 10; i++)
        {
            SpawnTrack(spawnPosition);
            Debug.Log(spawnPosition);
        }
    }

    private void SpawnTrack(Vector3 spawnPosition)
    {
        Instantiate(track, spawnPosition, Quaternion.identity);
        this.spawnPosition += Vector3.Scale(track.GetComponent<BoxCollider>().size, Vector3.forward);
    }
}
