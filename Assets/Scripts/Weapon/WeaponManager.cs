using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private WeaponData weaponData;
    private int currentAmmo;
    [SerializeField]
    private Transform firePoint;
    private FloorWeapon nearWeapon = null;
    private ShootingBehaviour shootingBehaviour;

    [SerializeField]
    private GameObject floorWeaponPf;
    [SerializeField]
    private Sprite noWeaponSprite;

    private void Awake()
    {
        InputManager.OnLeftClickStart += Shoot;
        InputManager.OnUseStart += PickUpWeapon;
        InputManager.OnRightClickStart += ThrowWeapon;
    }

    private void Shoot()
    {
        if (weaponData == null) return;
        if (currentAmmo <= 0 && !weaponData.IsMeele) return;

        currentAmmo -= weaponData.AmmoPerShot;
        shootingBehaviour.Shoot(weaponData.BulletPf, firePoint, transform.rotation.eulerAngles);
    }

    public void PickUpWeapon()
    {
        if (nearWeapon == null) return;

        weaponData = nearWeapon.weaponData;
        currentAmmo = nearWeapon.currentAmmo;
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponData.PlayerSprite;
        gameObject.AddComponent(nearWeapon.shootingBehaviour);
        shootingBehaviour = (ShootingBehaviour) gameObject.GetComponent(nearWeapon.shootingBehaviour);

        firePoint.localPosition = shootingBehaviour.FirePointLocalPosition;

        Destroy(nearWeapon.gameObject);
    }

    public void ThrowWeapon()
    {
        if (weaponData == null) return;

        GameObject weapon = Instantiate(floorWeaponPf, firePoint.position, Quaternion.identity);
        weapon.GetComponent<FloorWeapon>().Throw(firePoint.right, currentAmmo, weaponData);

        GetComponent<SpriteRenderer>().sprite = noWeaponSprite;
        weaponData = null;
        currentAmmo = 0;
    }

    public void SetNearWeapon(FloorWeapon weapon)
    {
        nearWeapon = weapon;
    }

    public void RemoveNearWeapon()
    {
        nearWeapon = null;
    }
}
