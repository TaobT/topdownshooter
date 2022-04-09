using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private WeaponData weaponData;

    private int currentWeaponAmmo;

    private int shotgunAmmo;
    private int maxShotgunAmmo = 10;
    private int gunAmmo;
    private int maxGunAmmo = 24;

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
        InputManager.OnLeftClickStart += StartShooting;
        InputManager.OnLeftClickCanceled += StopShooting;
        InputManager.OnUseStart += PickUpWeapon;
        InputManager.OnReloadStart += ReloadWeapon;
        InputManager.OnRightClickStart += ThrowWeapon;
    }

    public bool HasWeapon()
    {
        return weaponData != null;
    }

    private void StartShooting()
    {
        if (weaponData == null) return;
        if (currentWeaponAmmo <= 0 && !weaponData.IsMeele) return;

        if (!shootingBehaviour.canShoot) return;
        currentWeaponAmmo -= weaponData.AmmoPerShot;
        shootingBehaviour.StartShooting();
    }

    private void ReloadWeapon()
    {
        if (currentWeaponAmmo == weaponData.MaxAmmo) return;
        switch (weaponData.WeaponAmmoType)
        {
            case WeaponData.AmmoType.NoAmmo:
                break;
            case WeaponData.AmmoType.ShotgunAmmo:
                if (shotgunAmmo >= weaponData.MaxAmmo)
                {
                    currentWeaponAmmo = weaponData.MaxAmmo;
                    shotgunAmmo -= weaponData.MaxAmmo;
                }
                else
                {
                    currentWeaponAmmo = shotgunAmmo;
                    shotgunAmmo = 0;
                }
                break;
            case WeaponData.AmmoType.GunAmmo:
                if (gunAmmo >= weaponData.MaxAmmo)
                {
                    currentWeaponAmmo = weaponData.MaxAmmo;
                    gunAmmo -= weaponData.MaxAmmo;
                }
                else
                {
                    currentWeaponAmmo = gunAmmo;
                    gunAmmo = 0;
                }
                break;
        }
    }

    private void StopShooting()
    {
        if (!shootingBehaviour) return;
        shootingBehaviour.StopShooting();
    }

    public void PickingUpAmmo(WeaponData.AmmoType ammoType)
    {
        switch (ammoType)
        {
            case WeaponData.AmmoType.ShotgunAmmo:
                if (maxShotgunAmmo > shotgunAmmo) shotgunAmmo += 2;
                if (shotgunAmmo > maxShotgunAmmo) shotgunAmmo = maxShotgunAmmo;
                break;
            case WeaponData.AmmoType.GunAmmo:
                if (maxGunAmmo > gunAmmo) gunAmmo += 6;
                if (gunAmmo > maxGunAmmo) gunAmmo = maxGunAmmo;
                break;
            default:
                Debug.LogError("Wth! That type of ammo doesn't even exists!");
                break;
        }
    }

    #region PickingAndThrowingWeapon
    public void PickUpWeapon()
    {
        if (nearWeapon == null) return;
        if (weaponData != null) return;
        
        PickUp.weaponsTransform.Remove(nearWeapon.transform);

        weaponData = nearWeapon.weaponData;
        currentWeaponAmmo = nearWeapon.currentAmmo;
        gameObject.GetComponent<SpriteRenderer>().sprite = weaponData.PlayerSprite;
        gameObject.AddComponent(nearWeapon.shootingBehaviour);
        shootingBehaviour = (ShootingBehaviour) gameObject.GetComponent(nearWeapon.shootingBehaviour);

        firePoint.localPosition = shootingBehaviour.FirePointLocalPosition;
        shootingBehaviour.LoadShootingData(weaponData.BulletPf, firePoint, transform);

        Destroy(nearWeapon.gameObject);
    }

    public void ThrowWeapon()
    {
        if (weaponData == null) return;

        GameObject weapon = Instantiate(floorWeaponPf, firePoint.position, Quaternion.identity);
        weapon.GetComponent<FloorWeapon>().Throw(firePoint.right, currentWeaponAmmo, weaponData);

        GetComponent<SpriteRenderer>().sprite = noWeaponSprite;
        weaponData = null;
        currentWeaponAmmo = 0;
    }

    public void SetNearWeapon(FloorWeapon weapon)
    {
        Debug.Log(weapon.name);
        nearWeapon = weapon;
    }

    public void RemoveNearWeapon()
    {
        nearWeapon = null;
    }
    #endregion
}
