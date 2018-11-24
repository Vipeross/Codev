using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    // Use this for initialization
    private float movementSpeed = 3.0f;
    private Animator anim;
    private bool isWalking;
    private bool isSprinting;
    private bool isStrafing;
    

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        var z = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump"))
        {
            anim.SetTrigger("JumpTrigger");
        }

        isWalking = z != 0;
        isSprinting = Input.GetButton("Sprint") && isWalking;
        isStrafing = x != 0;

        if(isSprinting)
        {
            movementSpeed = 6.0f;
        }
        else if(isStrafing)
        {
            movementSpeed = 2.0f;
        }
        else
        {
            movementSpeed = 3.0f;
        }
        anim.SetBool("IsWalking", isWalking);
        anim.SetBool("IsSprinting", isSprinting);
        anim.SetFloat("VerticalMovement", z);
        anim.SetFloat("HorizontalMovement", x);
        anim.SetBool("IsStrafing", isStrafing);
        
 
        transform.Translate(0, 0, z * movementSpeed * Time.deltaTime);

        
        transform.Translate(x * Time.deltaTime * 3.0f, 0, 0);
    }
}
