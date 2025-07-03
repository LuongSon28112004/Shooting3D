using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    
    [Header("Input Settings")]
    private PlayerInputAction playerInputAction;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private bool jumpInput;
    [SerializeField] private bool attackInput;
    [SerializeField] private bool swapInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector2 MoveInput { get => moveInput; }
    public bool JumpInput { get => jumpInput; }
    public bool AttackInput { get => attackInput; }
    public static InputManager Instance { get => instance;}
    public bool SwapInput { get => swapInput; }

    private void OnEnable()
    {
        if (playerInputAction == null)
        {
            playerInputAction = new PlayerInputAction();
        }
        playerInputAction.Enable();
        playerInputAction.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputAction.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        playerInputAction.Player.Jump.performed += ctx => jumpInput = true;
        playerInputAction.Player.Jump.canceled += ctx => jumpInput = false;
        playerInputAction.Player.Attack.performed += ctx => attackInput = true;
        playerInputAction.Player.Attack.canceled += ctx => attackInput = false;
        playerInputAction.Player.Swap.performed += ctx => swapInput = true;
        playerInputAction.Player.Swap.canceled += ctx => swapInput = false;
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

}
