using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffle : Shooter {

    public override void Fire()
    {
        base.Fire();

        if(canFire)
        {

        }
    }

    public void Update()
    {
        if(GameManagerTPS.instance.inputController.reload)
        {
            Reload();
        }
    }
}
