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

    void Start()
    {
        isGrounded = true;
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerTPS.instance.inputController.jump && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * intensity, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        
        animator.SetBool("IsGrounded", isGrounded);
    }

    public bool IsGrounded()
    {
        //return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z), collider.radius * 0.9f);
        return isGrounded;
    }

    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        animator.SetBool("IsGrounded", isGrounded);
        

    }


}
