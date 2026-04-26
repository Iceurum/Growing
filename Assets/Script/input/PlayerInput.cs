using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {
    
    public UnityEvent<Vector2> onMove;
    public UnityEvent onInteract;

    private void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        onMove.Invoke(dir);

        if (Input.GetKeyDown(KeyCode.E)) {
            onInteract.Invoke();
        }
    }
}