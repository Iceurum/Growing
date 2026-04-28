using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Attach this component to the Player GameObject.
// In the Inspector, assign the InputActionAsset (PlayerInputActions.inputactions)
// ke field "Input Actions", lalu hubungkan onMove dan onInteract ke component lain.
public class PlayerInput : MonoBehaviour {

    [Header("Input Actions Asset")]
    [SerializeField] private InputActionAsset inputActions;

    [Header("Events")]
    public UnityEvent<Vector2> onMove;
    public UnityEvent onInteract;

    private InputAction moveAction;
    private InputAction interactAction;

    private void Awake() {
        // Ambil action map "Player" dari asset
        var playerMap = inputActions.FindActionMap("Player", throwIfNotFound: true);

        moveAction     = playerMap.FindAction("Move",     throwIfNotFound: true);
        interactAction = playerMap.FindAction("Interact", throwIfNotFound: true);
    }

    private void OnEnable() {
        moveAction.Enable();
        interactAction.Enable();

        // Subscribe ke event — dipanggil hanya saat ada input, bukan tiap frame
        interactAction.performed += HandleInteract;
    }

    private void OnDisable() {
        interactAction.performed -= HandleInteract;

        moveAction.Disable();
        interactAction.Disable();
    }

    private void Update() {
        // ReadValue<Vector2> sudah ternormalisasi oleh Input System
        // (diagonal tidak lebih cepat selama pakai "Normalize" di binding composite)
        Vector2 dir = moveAction.ReadValue<Vector2>();
        onMove.Invoke(dir);
    }

    private void HandleInteract(InputAction.CallbackContext ctx) {
        onInteract.Invoke();
    }
}
