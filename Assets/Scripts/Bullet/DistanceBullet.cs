using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBullet : Bullet
{
    private void Start()
    {
        speed = 15.0f;
        timeToLive = 1.0f;
        damageOnPlayer = 5;
        damageOnBase = 5;
    }
}
