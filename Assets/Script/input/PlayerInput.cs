using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    
    public UnityEvent<Vector2> onMove;
    public UnityEvent onInteract;

    private void Update() {
        Vector2 dir = Vector2.zero;
        if (Keyboard.current.wKey.isPressed) dir.y = 1f;
        if (Keyboard.current.sKey.isPressed) dir.y = -1f;
        if (Keyboard.current.aKey.isPressed) dir.x = -1f;
        if (Keyboard.current.dKey.isPressed) dir.x = 1f;
        onMove.Invoke(dir);

        if (Keyboard.current.eKey.wasPressedThisFrame) {
            onInteract.Invoke();
        }
    }
}