using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private WeaponManager _weaponManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (!collision.gameObject.GetComponent<FloorWeapon>()) return;

        _weaponManager.SetNearWeapon(collision.gameObject.GetComponent<FloorWeapon>());
        collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.254901961f, 0.254901961f, 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<FloorWeapon>()) return;
        _weaponManager.RemoveNearWeapon();
        collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
