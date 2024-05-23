using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : AIBehaviour
{
    public float feildOfVisionForShooting = 60;

    public override void PerformAction(PlayerController player, AIDetector detector)
    {
        if (TargetInFOV(player, detector))
        {
            player.HandleMoveBody(Vector2.zero);
            player.HandleShoot();
        }
            
        player.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(PlayerController player, AIDetector detector)
    {
       
        var direction = detector.Target.position - player.aimTurret.transform.position;
        if (Vector2.Angle(player.aimTurret.transform.right, direction) < feildOfVisionForShooting /2)
        {
    
            return true;
        }
        return false;
    }
}
