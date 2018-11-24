using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushCloserAI : EnemyAI
{
    private float distanceToPlayer;
    private float distanceToBasement;

    public override void chooseObjective()
    {
        distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
        distanceToBasement = Vector3.Distance(gameObject.transform.position, basement.transform.position);

        objective = distanceToPlayer > distanceToBasement ? basement : player;
    }
}
