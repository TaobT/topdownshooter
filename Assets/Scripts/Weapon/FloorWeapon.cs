using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : MonoBehaviour
{
    public WeaponData weaponData;
    public int currentAmmo;
    public Type shootingBehaviour;
    private Rigidbody2D rb;

    public FloorWeapon(WeaponData data, int ammo, Type shootingBehaviour)
    {
        weaponData = data;
        currentAmmo = ammo;
        this.shootingBehaviour = shootingBehaviour;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        shootingBehaviour = SBList.GetShootingBehaviour(weaponData.ShotBehaviour);
        gameObject.AddComponent(shootingBehaviour);
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponData.FloorSprite;
        currentAmmo = weaponData.MaxAmmo;
    }

    public void Throw(Vector3 dir)
    {
        rb.AddForce(dir * 25, ForceMode2D.Impulse);
        rb.AddTorque(5, ForceMode2D.Impulse);
    }
}
