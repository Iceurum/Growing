using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Settings")]
    public float speed = 5f;

    private Vector2 moveDir;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(Vector2 dir) {
        moveDir = dir;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
}