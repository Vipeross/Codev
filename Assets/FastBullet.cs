using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBullet : Bullet
{
    private void Start()
    {
        speed = 20.0f;
        timeToLive = 1.0f;
        damageOnPlayer = 15;
        damageOnBase = 15;
    }
}
