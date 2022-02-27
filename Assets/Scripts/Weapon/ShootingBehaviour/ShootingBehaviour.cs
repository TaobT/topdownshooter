using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingBehaviour : MonoBehaviour
{
    public abstract Vector3 FirePointLocalPosition { get; }

    public abstract void Shoot(GameObject bulletPf, Transform firePoint, Vector3 bulletDir);
}
