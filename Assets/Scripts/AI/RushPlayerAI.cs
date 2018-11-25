using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushPlayerAI : EnemyAI
{
    public override void chooseObjective()
    {
        objective = player;
    }
}
