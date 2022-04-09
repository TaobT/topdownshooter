using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingBehaviour : MonoBehaviour
{
    public abstract Vector3 FirePointLocalPosition { get; }
    public abstract float NextShootTime { get; }
    public abstract bool IsAuto { get; }

    private float timer;

    public bool alreadyShoot; //For SemiAutomatic weapons
    public bool canShoot = true;
    private bool isPullingTrigger;
    public GameObject BulletPf { get; private set; }
    public Transform FirePoint { get; private set; }
    public Transform GunnerTransform { get; private set; }

    public void LoadShootingData(GameObject bulletPf, Transform firePoint, Transform gunnerTransform)
    {
        this.BulletPf = bulletPf;
        this.FirePoint = firePoint;
        this.GunnerTransform = gunnerTransform;
    }

    private void CooldownNextShoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            canShoot = true;
        }
    }

    private void Update()
    {
        if (isPullingTrigger && canShoot && (!alreadyShoot || IsAuto))
        {
            Shooting();
        }
        else if(!canShoot)
        {
            CooldownNextShoot();
        }
    }

    public void StartShooting()
    {
        isPullingTrigger = true;
    }

    public void StopShooting()
    {
        isPullingTrigger = false;
        if (!IsAuto) RestartShoot();
    }

    public virtual void Shooting()
    {
        timer = NextShootTime;
        canShoot = false;
        alreadyShoot = true;
    }

    private void RestartShoot() => alreadyShoot = false;
}
