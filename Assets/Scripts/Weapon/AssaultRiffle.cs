using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffle : Shooter {

    //[SerializeField] Transform crosshair;


    public override void Fire()
    {
        base.Fire();

        if(canFire)
        {
            gunSound.Play(0);
        }
    }

    public void Update()
    {
        if(GameManagerTPS.instance.inputController.reload)
        {
            Reload();
        }
        muzzle.LookAt(crosshair);
        
        //transform.LookAt(crosshair);
    }
}
