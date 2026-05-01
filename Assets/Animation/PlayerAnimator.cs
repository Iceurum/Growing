using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private Animator animator;
    private Vector2 lastDir;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OnMove(Vector2 dir) {
        if (dir != Vector2.zero) {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", dir.x);
            animator.SetFloat("MoveY", dir.y);
            lastDir = dir;
        } else {
            animator.SetBool("IsMoving", false);
        }
    }
}
