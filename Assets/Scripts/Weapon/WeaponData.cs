using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public enum WeaponShootBehaviour
    {
        gun9mm,
        shotgunHomemade,
        meeleMachete
    }

    public enum AmmoType
    {
        NoAmmo,
        ShotgunAmmo,
        GunAmmo
    }

    [SerializeField]
    private string weaponName;
    [SerializeField]
    private float damage;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    private int ammoPerShot;
    [SerializeField]
    private WeaponShootBehaviour shootBehaviour;
    [SerializeField]
    private AmmoType weaponAmmoType;
    [SerializeField]
    private Sprite playerSprite;
    [SerializeField]
    private GameObject bulletPf;
    [SerializeField]
    private Sprite floorSprite;
    [SerializeField]
    private Vector2 colliderOffset;
    [SerializeField]
    private Vector2 colliderSize;
    [SerializeField]
    private bool isMeele;


    public string WeaponName { get { return weaponName; } }
    public float Damage { get { return damage; } }
    public int MaxAmmo { get { return maxAmmo; } }
    public int AmmoPerShot { get { return ammoPerShot; } }
    public WeaponShootBehaviour ShootBehaviour { get { return shootBehaviour; } }
    public AmmoType WeaponAmmoType { get { return weaponAmmoType; } }
    public Sprite PlayerSprite { get { return playerSprite; } }
    public GameObject BulletPf { get { return bulletPf; } }
    public Sprite FloorSprite { get { return floorSprite; } }
    public Vector2 ColliderOffset { get { return colliderOffset; } }
    public Vector2 ColliderSize { get { return colliderSize; } }
    public bool IsMeele { get { return isMeele; } }
}
