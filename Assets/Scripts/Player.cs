using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    HelperScript helper;
    public bool isGrounded = false;
    SpriteRenderer spi;
    Rigidbody2D rb;
    Animator anim;
    float speed = 5f;
    public bool coolDown = false;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Methods in the script

        if (!dead)
        {
            AnimationReset();
            Movement();
        }

        //Methods in other scripts

        helper.PrintHello();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            dead = true;
        }
    }

    private void AnimationReset()
    {
        anim.SetBool("moving", false);
        anim.SetBool("attack1", false);

        if (isGrounded == true)
        {
            anim.SetBool("jumping", false);
        }
    }

    private void Movement()
    {
        //Attacking:

        if (Input.GetKey("q") == true)
        {
            anim.SetTrigger("attack1");
            anim.speed = 5;
        }

        if ((Input.GetKeyDown("w") == true) && (helper.GroundCheck(isGrounded) == true))
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
        }


        if (helper.GroundCheck(isGrounded) == true)
        {
            anim.SetBool("jumping", false);
        }
        else
        {
            anim.SetBool("jumping", true);
        }

        //Left and right movement:
        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            anim.SetBool("moving", true);
            helper.FlipObject(true);

        }
        if (Input.GetKey("d") == true)
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("moving", true);
            helper.FlipObject(false);
        }

        //Run:

        if (Input.GetKey("e") == true)
        {
            if (coolDown == false)
            {
                speed = 1;
                anim.speed = 2;
            }
        }
        else
        {
            speed = 2;
            anim.speed = 1;
        }
    }
}




/* if (Input.GetKey("w") == true)
        {
            if (isGrounded == true)
            {
                rb.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
                anim.SetBool("jumping", true);
                isGrounded = false;
            }
        }*/