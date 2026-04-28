using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Settings")]
    public float speed = 5f;

    private Vector2 moveDir;

    // Dipanggil oleh PlayerInput.onMove via UnityEvent
    public void OnMove(Vector2 dir) {
        moveDir = dir;
    }

    private void Update() {
        if (moveDir == Vector2.zero) return; // skip kalau tidak ada input

        Vector3 movement = new Vector3(moveDir.x, moveDir.y, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
