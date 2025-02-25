using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    public float turretRotateSpeed = 150;

    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDirection = 
            (Vector3)inputPointerPosition - transform.position;
        var desireAngle = 
             Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = 
            turretRotateSpeed * Time.deltaTime;
        transform.rotation = 
            Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desireAngle - 90), rotationStep);
    }
}
