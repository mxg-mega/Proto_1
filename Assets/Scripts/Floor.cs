using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject player;
   
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.forward * player.transform.position.z;
    }
}
