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
       
        UnityEngine.AI.NavMeshPath nav = new UnityEngine.AI.NavMeshPath();

        Debug.Log("agent.CalculatePath(player.transform.position, nav) : " + agent.CalculatePath(player.transform.position, nav));

        // S'il n'a pas le chemin pour aller au joueur, il va focus la base quoi qu'il arrive
        if (distanceToPlayer < distanceToBasement && agent.CalculatePath(player.transform.position, nav))
            objective = player;
        else
            objective = basement;

    }
}
