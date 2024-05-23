using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolStatic : AIBehaviour
{
    public float patrolDelay = 4;

    [SerializeField]
    private Vector2 randomDir = Vector2.zero;
    [SerializeField]
    private float currentPatrolDelay;

    private void Awake()
    {
        randomDir = Random.insideUnitCircle;
    }

    public override void PerformAction(PlayerController player, AIDetector detector)
    {
        float angle = Vector2.Angle(player.aimTurret.transform.right, randomDir);
        if (currentPatrolDelay <= 0 && (angle < 2))
        {
            randomDir = Random.insideUnitCircle;
            currentPatrolDelay = patrolDelay;
        }
        else
        {
            if (currentPatrolDelay > 0)
                currentPatrolDelay -= patrolDelay;
            else
                player.HandleTurretMovement((Vector2)player.aimTurret.transform.position + randomDir);
        }
    }
}
