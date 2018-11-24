using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacBullet : Bullet
{
    private void Start()
    {
        speed = 15.0f;
        timeToLive = 1.0f;
        damageOnPlayer = 50;
        damageOnBase = 40;
    }
}
