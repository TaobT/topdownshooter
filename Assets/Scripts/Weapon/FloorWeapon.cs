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
    private BoxCollider2D pickupCollider;
    private bool used = false;
    [SerializeField]
    private BoxCollider2D hitboxCollider;
    private SpriteRenderer spriteRenderer;

    public FloorWeapon(WeaponData data, int ammo, Type shootingBehaviour)
    {
        weaponData = data;
        currentAmmo = ammo;
        this.shootingBehaviour = shootingBehaviour;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pickupCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        shootingBehaviour = SBList.GetShootingBehaviour(weaponData.ShotBehaviour);
        gameObject.AddComponent(shootingBehaviour);
        spriteRenderer.sprite = weaponData.FloorSprite;

        pickupCollider.offset = weaponData.ColliderOffset;
        pickupCollider.size = weaponData.ColliderSize;

        hitboxCollider.offset = weaponData.ColliderOffset;
        hitboxCollider.size = weaponData.ColliderSize;

        if (used) return; 
        currentAmmo = weaponData.MaxAmmo;
    }

    public void Throw(Vector3 dir, int ammo, WeaponData weapon)
    {
        currentAmmo = ammo;
        weaponData = weapon;
        rb.AddForce(dir * 25, ForceMode2D.Impulse);
        rb.AddTorque(5, ForceMode2D.Impulse);
        used = true;
        spriteRenderer.sortingOrder = 1;
    }
}
