using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private InputHandlerManager inputManager;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float sensitivity = 1;
    [SerializeField] private bool applySensitivity = false;

    [SerializeField] private float stop = 10f;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float gravityMagnitude = 1;
    [SerializeField] private float jumpGravity = Physics.gravity.y;
    [SerializeField] private float fallGravity;
    [SerializeField] public float downWardsVelocity;

    void Awake()
    {
        inputManager = InputHandlerManager.Instance;
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fallGravity = Physics.gravity.y * gravityMagnitude;
    }

    private void Update()
    {

        if (rb.velocity.y > 0)
        {
            downWardsVelocity = jumpGravity;
        }
        else if (rb.velocity.y < 0)
        {
            downWardsVelocity = fallGravity;
        }
        else
        {
            downWardsVelocity = 0;
        }
    }

    void FixedUpdate()
    {
        Debug.Log(inputManager.DragPhase + " Position : " + inputManager.MovePosition);
        // transform.position += new Vector3(inputManager.MovePosition.x, 0, 0).normalized;
        if (transform.position.z > stop && rb.velocity.z != 0)
        {
            rb.velocity = Vector3.back;
        }
        if (!applySensitivity)
        {
            rb.velocity = new Vector3(inputManager.MovePosition.x, downWardsVelocity, speed);
        }
        else if (applySensitivity)
        {
            rb.velocity = new Vector3(inputManager.MovePosition.x * sensitivity, downWardsVelocity, speed);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            Debug.Log("hit the floor");
        }
    }

}
