using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;
    Animator animator;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.isJumping = false;
            animator.SetBool("isJumping", player.isJumping);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.isJumping = true;
            animator.SetBool("isJumping", player.isJumping);
        }
    }
}
