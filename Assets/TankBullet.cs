using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : Bullet
{
    private void Start()
    {
        speed = 7.0f;
        timeToLive = 1.0f;
        damageOnPlayer = 30;
        damageOnBase = 50;
    }
}
