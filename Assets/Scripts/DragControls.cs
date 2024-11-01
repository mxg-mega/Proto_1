using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Dreamteck.Forever;

public class DragControls : MonoBehaviour
{
    private PlayerControls playerControl;
    private Runner runner;
    [SerializeField] private Camera camera;
    private Vector2 startOffset;
    [SerializeField] float sensitivity = 1f;
    [SerializeField] private float setBound = 5.5f;
    void Awake()
    {
        playerControl = new PlayerControls();
    }
    void Start()
    {
        runner = GetComponent<Runner>();
        startOffset = runner.motion.offset;
    }

    void OnEnable()
    {
        playerControl.Enable();
    }

    void OnDisable()
    {
        playerControl.Disable();
    }
    void Update()
    {
        if (playerControl.Player.TouchPress.ReadValue<float>() == 1 && playerControl.Player.TouchPhase.ReadValue<UnityEngine.InputSystem.TouchPhase>() == UnityEngine.InputSystem.TouchPhase.Moved)
        {
            Debug.Log("pressed = " + playerControl.Player.TouchPress.ReadValue<float>() + " and phase = " + playerControl.Player.TouchPhase.ReadValue<UnityEngine.InputSystem.TouchPhase>());
            var screenDelta = playerControl.Player.TouchPosition.ReadValue<Vector2>();

            if (camera != null)
            {
                screenDelta.y = 0;
                // Screen position of the transform
                var screenPoint = camera.WorldToScreenPoint(transform.position);
                //var screenPoint = camera.WorldToScreenPoint((Vector3)runner.motion.offset);

                // Add the deltaPosition
                screenPoint += (Vector3)screenDelta * sensitivity;

                // Convert back to world space
                Vector3 moveVector = camera.ScreenToWorldPoint(screenPoint);
                //transform.position = moveVector;

                runner.motion.offset.x = startOffset.x + Mathf.Clamp(moveVector.x, -setBound, setBound);
            }
            else
            {
                Debug.LogError("Failed to find camera. Either tag your camera as MainCamera, or set one in this component.", this);
            }
        }
    }

    /*[SerializeField] private InputAction press, screenPosition;
    private Vector3 currentScreenPos;
    private Camera camera;
    private bool isDragging;

    private Vector3 WorldPos
    {
        get
        {
            float z = camera.WorldToScreenPoint(transform.position).z;
            return camera.ScreenToWorldPoint(currentScreenPos + new Vector3(0, 0, z));
        }
    }

    private bool isClickedOn
    {
        get
        {
            Ray ray = camera.ScreenPointToRay(currentScreenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }
    }

    private void Awake()
    {
        camera = Camera.main;
        press.Enable();
        screenPosition.Enable();
        screenPosition.performed += context => { currentScreenPos = context.ReadValue<Vector2>(); };
        press.performed += _ => { if (isClickedOn) StartCoroutine(Drag()); };
        press.canceled += _ => { isDragging = false; };
    }

    private IEnumerator Drag()
    {
        Vector3 offset = transform.position - WorldPos;
        isDragging = true;
        while (isDragging)
        {
            transform.position = WorldPos + offset;
            yield return null;
        }
    }*/
}
