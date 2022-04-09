using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private WeaponManager _weaponManager;

    public static List<Transform> weaponsTransform { private set; get; } = new List<Transform>();

    private FloorWeapon nearestWeapon;

    private Vector3 lastPlayerPos;

    private void Start()
    {
        lastPlayerPos = transform.position;
    }

    private void Update()
    {
        if (lastPlayerPos != transform.position)
        {
            lastPlayerPos = transform.position;
            if (weaponsTransform.Count > 0)
            {
                FindNearestWeapon();
            }
            else nearestWeapon = null;
        }
    }

    private void FindNearestWeapon()
    {
        float nearestDistance = float.MaxValue;
        if (nearestWeapon != null)  nearestWeapon.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        foreach (Transform weapon in weaponsTransform)
        {
            float distance = Vector3.Distance(transform.position, weapon.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestWeapon = weapon.GetComponent<FloorWeapon>();
            }
        }
        SendNearestWeaponToWeaponManager();
        
    }

    private void SendNearestWeaponToWeaponManager()
    {
        if (nearestWeapon != null && !_weaponManager.HasWeapon())
        {
            _weaponManager.SetNearWeapon(nearestWeapon);
            nearestWeapon.transform.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (!collision.gameObject.GetComponent<FloorWeapon>()) return;

        weaponsTransform.Add(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<FloorWeapon>()) return;

        weaponsTransform.Remove(collision.transform);
    }

    
}
