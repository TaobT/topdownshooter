using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    public enum GunShotBehaviour
    {
        gun9mm,
        shotgunHomemade
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
    private GunShotBehaviour shotBehaviour;
    [SerializeField]
    private Sprite playerSprite;
    [SerializeField]
    private GameObject bulletPf;
    [SerializeField]
    private Sprite floorSprite;


    public string WeaponName { get { return weaponName; } }
    public float Damage { get { return damage; } }
    public int MaxAmmo { get { return maxAmmo; } }
    public int AmmoPerShot { get { return ammoPerShot; } }
    public GunShotBehaviour ShotBehaviour { get { return shotBehaviour; } }
    public Sprite PlayerSprite { get { return playerSprite; } }
    public GameObject BulletPf { get { return bulletPf; } }
    public Sprite FloorSprite { get { return floorSprite; } }
}
