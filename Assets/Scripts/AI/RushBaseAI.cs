using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushBaseAI : EnemyAI
{
	public override void chooseObjective ()
    {
        objective = basement;
    }
}
