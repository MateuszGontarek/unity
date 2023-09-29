using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 2.0f;

    void Start()
    {
        rb.AddForce(bulletSpeed * new Vector2(5, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObsticlesBullet")) {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}
