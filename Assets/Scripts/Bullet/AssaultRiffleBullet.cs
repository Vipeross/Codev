using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffleBullet : Bullet {

    private int damage = 50;

    private void Start()
    {
        speed = 50.0f;
        timeToLive = 5.0f;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.tag == "Enemy")
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}
