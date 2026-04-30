using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {

    [Header("Input Actions Asset")]
    [SerializeField] private InputActionAsset inputActions;

    [Header("Events")]
    public UnityEvent<Vector2> onMove;
    public UnityEvent onInteract;
    public UnityEvent onFertilize;

    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction fertilizeAction;

    private void Awake() {
        var playerMap    = inputActions.FindActionMap("Player", throwIfNotFound: true);
        moveAction       = playerMap.FindAction("Move",      throwIfNotFound: true);
        interactAction   = playerMap.FindAction("Interact",  throwIfNotFound: true);
        fertilizeAction  = playerMap.FindAction("Fertilize", throwIfNotFound: true);
    }

    private void OnEnable() {
        moveAction.Enable();
        interactAction.Enable();
        fertilizeAction.Enable();
 
        interactAction.performed  += HandleInteract;
        fertilizeAction.performed += HandleFertilize;
    }

    private void OnDisable() {
        interactAction.performed  -= HandleInteract;
        fertilizeAction.performed -= HandleFertilize;
 
        moveAction.Disable();
        interactAction.Disable();
        fertilizeAction.Disable();
    }
    private void Update() {
        Vector2 dir = moveAction.ReadValue<Vector2>();
        onMove.Invoke(dir);
    }
 
    private void HandleInteract(InputAction.CallbackContext ctx) {
        onInteract.Invoke();
    }
 
    private void HandleFertilize(InputAction.CallbackContext ctx) {
        onFertilize.Invoke();
    }
}
