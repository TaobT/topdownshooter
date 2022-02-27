using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void Awake()
    {
        Invoke("RemoveBullet", 5);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * 5000);
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
