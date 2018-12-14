using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Horizontal", GameManagerTPS.instance.inputController.horizontal);
        animator.SetFloat("Vertical", GameManagerTPS.instance.inputController.vertical);
        animator.SetBool("IsRunning", GameManagerTPS.instance.inputController.isRunning);
	}
}
