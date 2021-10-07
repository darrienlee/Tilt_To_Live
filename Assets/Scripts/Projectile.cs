using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    private Vector2 moveDirection;
    //public GameObject collide;

    private new Rigidbody2D rigidbody;
    private Vector2 screenBounds;
    private bool firstEnemy = true;
    private int comboKillScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * projectileSpeed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        // destroy object if off screen
        if ((transform.position.x < -screenBounds.x * 2) || (transform.position.x > screenBounds.x * 2) || (transform.position.y < -screenBounds.y * 2) || (transform.position.y > screenBounds.y * 2))
        // left side, right side, below, above
        {
            ScoreScript.scoreValue += comboKillScore;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag.Equals("Enemy"))
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if(firstEnemy == false) // if it is not first enemy, then start adding combo kill points
            {
                ScoreScript.scoreValue += 10;
                comboKillScore += 5;
            }
            else // otherwise just add 10 points and set first enemy to false
            {
                firstEnemy = false;
                ScoreScript.scoreValue += 10;
            }
            Destroy(collision.gameObject); // destroy what collided with me "enemy"
            //Destroy(this.gameObject); // destroy me
        }
    }
}
