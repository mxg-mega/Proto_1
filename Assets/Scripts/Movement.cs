using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }
    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 movement = Vector3.zero;
            Debug.Log("Moving Right !");
            playerRigidBody.AddForce(movement * 5f, ForceMode.Impulse);
        }
        
    }
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Moving Right !");
            playerRigidBody.AddForce(Vector3.left * 5f, ForceMode.Impulse);
        }
    }
}
