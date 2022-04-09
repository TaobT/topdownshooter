using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBMachete : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(1.25f,0);

    public override float NextShootTime => 1.5f;

    public override bool IsAuto => false;

    public override void Shooting()
    {
        Debug.Log("Machete Attack!");
        Instantiate(BulletPf, FirePoint.position, Quaternion.Euler(GunnerTransform.rotation.eulerAngles), FirePoint);
        base.Shooting();
    }
}
