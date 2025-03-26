using System.Collections;
using UnityEngine;


public class Animasyon : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 5.0f;
    [SerializeField] private float jumpInterval = 3.0f;
    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private Animator animator;

    private float jumpTimer;
    private bool isJumping = false;
    private bool isGrounded = true;

    private void Start()
    {
        jumpTimer = jumpInterval;
        if (animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGrounded && !isJumping)
        {
            jumpTimer -= Time.deltaTime;

            if (jumpTimer <= 0f)
            {
                Jump();
                jumpTimer = jumpInterval; // Reset the timer
            }
        }

        if (isGrounded && !isJumping && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump_Idle"))
        {
            animator.Play("Idle"); // Play idle animation if not jumping
        }
    }

    private void Jump()
    {
        isJumping = true;
        isGrounded = false;

        animator.Play("Jump_Start");

        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        // Calculate jump motion
        float startY = transform.position.y;
        float targetY = startY + jumpHeight;

        float elapsedTime = 0f;

        while (elapsedTime < jumpTime)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, targetY, elapsedTime / jumpTime), transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // simulate falling down
        elapsedTime = 0f;

        while (elapsedTime < jumpTime)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(targetY, startY, elapsedTime / jumpTime), transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Final landing position
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);


        isGrounded = true;
        isJumping = false;
        animator.Play("Jump_Idle");


        animator.Play("Jump_Land");
    }
}
