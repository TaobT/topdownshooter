using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBHomemadeShotgun : ShootingBehaviour
{
    public override Vector3 FirePointLocalPosition => new Vector3(1.325f, 0.036f);

    public override float NextShootTime => 10f;

    public override bool IsAuto => false;

    public override void Shooting()
    {
        for (int i = 0; i < 5; i++)
        {
            float offset = Random.Range(-8f, 8f);
            Instantiate(BulletPf, FirePoint.position, Quaternion.Euler(new Vector3(GunnerTransform.rotation.eulerAngles.x, GunnerTransform.rotation.eulerAngles.y, GunnerTransform.rotation.eulerAngles.z + offset)));
        }

        base.Shooting();
    }
}
