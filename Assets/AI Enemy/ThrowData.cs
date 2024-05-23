using UnityEngine;

public class ShootData
{
    public Vector3 ShootVelocity { get; internal set; }
    public float Angle { get; internal set; }
    public float DeltaXZ { get; internal set; }
    public float DeltaY { get; internal set; }
}