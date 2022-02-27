using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB9mm : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(2.75f,0);

    public override void Shoot(GameObject bulletPf, Transform firePoint, Vector3 bulletDir)
    {
        Instantiate(bulletPf, firePoint.position, Quaternion.Euler(bulletDir));
    }
}
