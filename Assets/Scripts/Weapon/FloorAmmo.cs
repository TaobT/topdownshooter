using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorAmmo : MonoBehaviour
{
    [SerializeField]
    private WeaponData.AmmoType ammoType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<WeaponManager>().PickingUpAmmo(ammoType);
            Destroy(gameObject);
        }
    }
}
