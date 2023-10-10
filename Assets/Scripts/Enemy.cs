using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spi;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x > transform.position.x)
        {
            //move left
            transform.position = new Vector2(transform.position.x + (0.5f * Time.deltaTime), transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + (-0.5f * Time.deltaTime), transform.position.y);
        }
        
        //distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform .position;

       // transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
