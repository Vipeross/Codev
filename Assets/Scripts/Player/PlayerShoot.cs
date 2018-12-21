using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField] Shooter assaultRiffle;

    private void Update()
    {
        if(GameManagerTPS.instance.inputController.fire1)
        {
            assaultRiffle.Fire();
        }
    }
}
