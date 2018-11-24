using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushPlayerAI : EnemyAI
{
    public override void chooseObjective()
    {
        objective = player;
    }
}
