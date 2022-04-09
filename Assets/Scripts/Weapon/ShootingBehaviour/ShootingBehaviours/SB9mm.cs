using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB9mm : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(1.325f, 0.036f);

    public override float NextShootTime => 0.2f;

    public override bool IsAuto => false;

    public override void Shooting()
    {
        Instantiate(BulletPf, FirePoint.position, Quaternion.Euler(GunnerTransform.rotation.eulerAngles));
        base.Shooting();
    }
}
