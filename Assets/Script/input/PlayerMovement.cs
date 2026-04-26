using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 5f;
    private Vector2 moveDir;

    public void OnMove(Vector2 dir) {
        moveDir = dir;
    }

    private void Update() {
        Vector3 movement = new Vector3(moveDir.x, 0f, moveDir.y);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}