using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatForm : MonoBehaviour
{
    [SerializeField] private float jumpForce = 0f;

    [Range(0, 90)]
    [SerializeField] private float angle;
    [SerializeField] private float distance;
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpHeight = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 forceDirection = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(forceDirection * jumpForce, ForceMode.Impulse);
        }
    }
}
