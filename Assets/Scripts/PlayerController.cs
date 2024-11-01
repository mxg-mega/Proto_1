using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float velocity;

    private float _gravity = Physics.gravity.y;
    public bool isGrounded;
    public bool _isStarted;

    [SerializeField] private float raycastDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;

    public Vector3 movement;
    private PlayerControls playerControl;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private float setBound = 5.5f;

    private void Awake()
    {
        playerControl = new PlayerControls();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        _isStarted = false;

        movement = new Vector3(0, 0, 0);
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    private void Update()
    {
        if (playerControl.Player.TouchPress.ReadValue<float>() == 1 && playerControl.Player.TouchPhase.ReadValue<UnityEngine.InputSystem.TouchPhase>() == UnityEngine.InputSystem.TouchPhase.Moved)
        {
            Debug.Log("pressed = " + playerControl.Player.TouchPress.ReadValue<float>() + " and phase = " + playerControl.Player.TouchPhase.ReadValue<UnityEngine.InputSystem.TouchPhase>());
            var screenDelta = playerControl.Player.TouchPosition.ReadValue<Vector2>();

            if (cameraMain != null)
            {
                // Lock the y axis input since we only need the body to change on the x axis only
                screenDelta.y = 0;
                // Screen position of the transform
                var screenPoint = cameraMain.WorldToScreenPoint(transform.position);

                // Add the deltaPosition
                screenPoint += (Vector3)screenDelta * sensitivity;

                // Convert back to world space
                Vector3 moveVector = cameraMain.ScreenToWorldPoint(screenPoint);

                rb.position = moveVector;
                //rb.MovePosition(moveVector * Time.deltaTime);
            }
            else
            {
                Debug.LogError("Failed to find camera. Either tag your camera as MainCamera, or set one in this component.", this);
            }
        }
    }

    public void SetisStarted(bool state)
    {
        _isStarted = state;
    }

    private void FixedUpdate()
    {
        if (_isStarted)
        {
            // Check if player is on Ground
            isGrounded = IsGrounded();

            MultiplyGravity();
            Vector3 gravityApplication = new Vector3(0, velocity, 0);
            movement = Vector3.forward * speed;
            rb.velocity = movement + gravityApplication;
        }
    }

    private void MultiplyGravity()
    {
        if (isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        // Perform a downward raycast to check if the player is touching the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer))
        {
            // Check if the hit normal is close to being vertical (indicating flat ground)
            if (Vector3.Dot(hit.normal, Vector3.up) > 0.5f)
            {
                return true;
            }
        }
        return false;
    }
}