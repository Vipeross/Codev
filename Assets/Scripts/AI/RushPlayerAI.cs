using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushPlayerAI : EnemyAI
{
    public override void chooseObjective()
    {
        UnityEngine.AI.NavMeshPath nav = new UnityEngine.AI.NavMeshPath();
        Debug.Log("agent.CalculatePath(player.transform.position, nav) : " + agent.CalculatePath(player.transform.position, nav));

        // S'il n'a pas le chemin pour aller au joueur, il va focus la base quoi qu'il arrive
        if (agent.CalculatePath(player.transform.position, nav))
            objective = player;
        else
            objective = basement;
    }
}
