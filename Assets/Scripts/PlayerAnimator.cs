using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private int spriteDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Change the animation based on the input
        if (playerController.InputVector != Vector2.zero)
        {
            animator.Play("PlayerWalkAnimation");

            // Update the sprite direction based on direction of movement
            if (playerController.InputVector.x > 0)
            {
                spriteDirection = 1;
            }
            else
            {
                spriteDirection = -1;
            }
        }
        else
        {
            animator.Play("PlayerIdleAnimation");
        }

        Vector3 tempScale = transform.localScale;
        tempScale.x = spriteDirection;
        transform.localScale = tempScale;
    }
}
