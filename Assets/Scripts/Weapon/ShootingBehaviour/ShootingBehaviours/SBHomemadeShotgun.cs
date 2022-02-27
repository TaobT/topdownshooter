using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBHomemadeShotgun : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(2.75f, 0);

    public override void Shoot(GameObject bulletPf, Transform firePoint, Vector3 bulletDir)
    {
        for (int i = 0; i < 5; i++)
        {
            float offset = Random.Range(-8f, 8f);
            Instantiate(bulletPf, firePoint.position, Quaternion.Euler(new Vector3(bulletDir.x, bulletDir.y, bulletDir.z + offset)));
        }
    }
}
