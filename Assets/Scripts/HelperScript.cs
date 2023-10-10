using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        //Flip the sprite calling the method

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    public void PrintHello()
    {
        if (Input.GetKey("r"))
        {
            print("hello world");
        }
    }
    public void Collect(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }

    public bool GroundCheck(bool isGrounded)
    {
        //Raycasting
        Color hitColor = Color.white;
        float laserLength = 0.05f;
        //Makes 3 lines directly beneath the player to register the floor
        Vector3 rayOffset = new Vector3(0, -0.21f, 0);
        Vector3 rayOffset2 = new Vector3(-0.1f, -0.21f, 0);
        Vector3 rayOffset3 = new Vector3(0.1f, -0.21f, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserLength, groundLayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, laserLength, groundLayerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, laserLength, groundLayerMask);

        //If any of the lines are touching the ground then the player can jump.
        if ((hit.collider != null) || (hit2.collider != null) || (hit3.collider != null))
        {
            hitColor = Color.red;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, Vector2.down * laserLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset3, Vector2.down * laserLength, hitColor);
        return isGrounded;
    }

    public bool EdgeCheck(bool left)
    {
        //Raycasting
        Color hitColor = Color.white;
        float laserLength = 0.05f;
        //Makes 3 lines directly beneath the player to register the floor
        Vector3 rayOffsetLeft = new Vector3(-0.1f, -0.21f, 0);
        Vector3 rayOffsetRight = new Vector3(0.1f, -0.21f, 0);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + rayOffsetLeft, Vector2.down, laserLength, groundLayerMask);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + rayOffsetRight, Vector2.down, laserLength, groundLayerMask);

        if (hitLeft.collider == null)
        {
            left = false; 
        }
        if (hitRight.collider == null)
        {
            left = true;
        }
        return left;
    }
}
