using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject bullet;
    [SerializeField] public float upForce = 100;
    [SerializeField] public float speed = 1500;
    [SerializeField] public float runSpeed = 2500;
    [SerializeField] public float bulletSpeed = 3000000000;

    public KeyCode Key_code = KeyCode.F;
    public bool isGrounded = false;
    public bool key = false;
    // Start is called before the first frame upate
    void Start()
    {
        
    }
    // Update is called once per frame
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
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        switch(collision.gameObject.tag) {
            case "Przeszkoda":
                if (!key) return;
                collision.gameObject.SetActive(false);
                break;
            case "Key":
                collision.gameObject.SetActive(false);
                key = true;
                break;
        }

    }
}
