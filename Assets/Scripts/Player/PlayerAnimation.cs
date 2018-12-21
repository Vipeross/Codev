using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;
    [SerializeField] WeaponReloader weaponReloader;

    private PlayerAim m_playerAim;
    private PlayerAim PlayerAim
    {
        get
        {
            if(m_playerAim == null)
            {
                m_playerAim = GetComponent<Player>().playerAim;
            }
            return m_playerAim;
        }
    }

	// Use this for initialization
	void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("Horizontal", GameManagerTPS.instance.inputController.horizontal);
        animator.SetFloat("Vertical", GameManagerTPS.instance.inputController.vertical);
        animator.SetBool("IsRunning", GameManagerTPS.instance.inputController.isRunning);

        animator.SetFloat("AimAngle", PlayerAim.GetAngle());
        animator.SetBool("IsReloading", weaponReloader.IsReloading());
	}
}
