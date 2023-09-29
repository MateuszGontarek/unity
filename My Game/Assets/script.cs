using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject bullet;
    [SerializeField] GameObject gunObject;
    [SerializeField] public float upForce = 100;
    [SerializeField] public float speed = 1500;
    [SerializeField] public float runSpeed = 2500;
    [SerializeField] public float bulletSpeed = 20;

    public KeyCode Key_code = KeyCode.F;
    public bool isGrounded = false;
    public bool key = false;
    private Transform trans;

    void Update()
    {
        rb.velocity = new Vector2(
             Input.GetAxis("Horizontal") *
            (Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed), 
            rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
        }

        if (Input.GetKeyDown(Key_code))
        {
            trans = gunObject.transform;
            Instantiate(bullet, trans.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        switch(collision.gameObject.tag) {
            case "Przeszkoda":
                if (!key) return;
                Destroy(collision.gameObject);
                break;
            case "Key":
                Destroy(collision.gameObject);
                key = true;
                break;
        }

    }
}
