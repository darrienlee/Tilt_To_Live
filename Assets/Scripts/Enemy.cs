using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb; // reference to rigidbody aka the physical body of the unit
    private Transform player; // player reference
    private Vector2 moveDirection;

    
    /*void Start() {
        //rb = this.GetComponent<Rigidbody2D>(); // we can drag and drop this attribute through unity
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screen.width, screen.height, Camera.main.transform.position.z));
    }*/
     

    // Update is called once per frame
    void Update()
    {
        // Processing inputs
        player = GameObject.FindWithTag("Player").transform;
        if (player != null)
        {
            moveDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y).normalized; // transform.position = this unit's position
        }
        else
        {
            moveDirection = new Vector2(0, 0);
        }
    }

    void FixedUpdate()
    {
        // Physics calculations
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        // rb.MovePosition((Vector2)transform.postion + (moveDirection * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        //if (collision.gameObject.GetComponent<Player>() != null)
        {
            //Destroy(this.gameObject); // destroy me
            // do damage to player
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1.0f);
                /*if (healthComponent.currentHealth <= 0)
                {
                    Destroy(collision.gameObject);
                    // play death animation and game over screen

                }*/
            }
        }
    }

}
