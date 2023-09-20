using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] public float upForce = 100;
    [SerializeField] public float speed = 1500;
    [SerializeField] public float runSpeed = 2500;

    public bool isGrounded = false;
    // Start is called before the first frame update
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            return;
        }
    }
}
