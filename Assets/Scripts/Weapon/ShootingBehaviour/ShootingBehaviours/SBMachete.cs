using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBMachete : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(1.25f,0);

    public override void Shoot(GameObject bulletPf, Transform firePoint, Vector3 bulletDir)
    {
        Instantiate(bulletPf, firePoint.position, Quaternion.Euler(bulletDir), firePoint);
    }
}
