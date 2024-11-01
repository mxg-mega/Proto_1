using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputHandlerManager : MonoBehaviour
{
    /*[Header("inout Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Input Action Refrences")]
    [SerializeField] private string position = "TouchPosition";
    [SerializeField] private string pressed = "TouchPress";
    [SerializeField] private string phase = "TouchPhase";*/

    private InputAction touchPosition;
    private InputAction touchPhase;
    private InputAction touchPress;

    private PlayerControls _inputActions;
    public Vector2 MovePosition { get; private set; }
    public float TouchPressed { get; private set; }
    public UnityEngine.InputSystem.TouchPhase DragPhase { get; private set; }

    public static InputHandlerManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        /*touchPosition = playerControls.FindActionMap(actionMapName).FindAction(position);
        touchPhase = playerControls.FindActionMap(actionMapName).FindAction(phase);
        touchPress = playerControls.FindActionMap(actionMapName).FindAction(pressed);*/
        _inputActions = new PlayerControls();
        touchPosition = _inputActions.Player.TouchPosition;
        touchPhase = _inputActions.Player.TouchPhase;
        touchPress = _inputActions.Player.TouchPress; ;

        RegisterActions();
    }
    void RegisterActions()
    {
        touchPosition.performed += context => MovePosition = context.ReadValue<Vector2>();
        touchPosition.canceled += context => MovePosition = Vector2.zero;

        touchPhase.performed += context => DragPhase = context.ReadValue<UnityEngine.InputSystem.TouchPhase>();
        touchPhase.canceled += context => DragPhase = UnityEngine.InputSystem.TouchPhase.Canceled;

        touchPress.performed += context => TouchPressed = context.ReadValue<float>();
        touchPress.canceled += context => TouchPressed = context.ReadValue<float>();
    }

    void OnEnable()
    {
        touchPosition.Enable();
        touchPress.Enable();
        touchPhase.Enable();
    }
    void OnDisable()
    {
        touchPosition.Disable();
        touchPress.Disable();
        touchPhase.Disable();
    }

}
