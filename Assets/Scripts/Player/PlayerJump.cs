using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update

    bool isGrounded;

    public float intensity;

    private Rigidbody rigidbody;
    private CapsuleCollider collider;
    private Animator animator;
    private float distanceToGround;

    void Start()
    {
        isGrounded = false;

        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();

        distanceToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded != Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.01f))
            changeJumpAnimation();

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.01f);

        if (GameManagerTPS.instance.inputController.jump && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * intensity, ForceMode.Impulse);
        }
    }
   
    private void changeJumpAnimation ()
    {
        animator.SetBool("IsGrounded", !isGrounded);
    }
}
