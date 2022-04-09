using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void Awake()
    {
        Invoke("RemoveBullet", 5);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        RemoveBullet();
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
