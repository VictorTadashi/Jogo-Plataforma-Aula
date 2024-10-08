using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private Animator animator; 

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        this.rb.velocity = new Vector2(horizontal * 8f, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        }
        Flip();

        /*
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Apertou espa�o");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicou com o bot�o direito");
        }
        */
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0)
        {

            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}


