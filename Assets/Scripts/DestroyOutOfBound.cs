using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float boundary = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.z < (player.transform.position.z - boundary))
        {
            Debug.Log("Destroyed !");
            Destroy(gameObject);
        }




        /*if obeject gets past the top view of player it is destroyed
        if (transform.position.z > boundary)
        {
            Destroy(gameObject);
        }
        //if object (animals) gets past view it is destroyed
        else if (transform.position.z < lowerBoundary)
        {
            //shout "Game Over" if it pasts
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }*/
    }
}
