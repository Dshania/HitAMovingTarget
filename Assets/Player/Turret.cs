using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarrels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    public bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private void Awake()
    {
        tankColliders = GetComponentsInChildren<Collider2D>();
    }
    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public ShootData ShootData (Vector3 TargetPosition, Vector3 StartPosition)
    {
        Vector3 displacment = new Vector3 (TargetPosition.x, StartPosition.y, TargetPosition.z) - StartPosition;
        float deltaY = TargetPosition.y - StartPosition.y;
        float deltaXZ= displacment.magnitude;
        float angle = Mathf.PI / 2F - (0.5F * (Mathf.PI / 2 - (deltaY / deltaXZ)));
        Vector3 intialVelocity = Mathf.Cos(angle) * displacment.normalized + Mathf.Sin(angle) * Vector3.forward;

        return new ShootData
        {
            ShootVelocity = intialVelocity,
            Angle = angle,
            DeltaXZ = deltaXZ,
            DeltaY = deltaY
        };
    }
    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = barrel.position;
                //

                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize();

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }

}
