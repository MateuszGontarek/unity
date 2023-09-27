using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(bulletSpeed * new Vector2(10, 5));
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        this.gameObject.SetActive(false);
    }
}
