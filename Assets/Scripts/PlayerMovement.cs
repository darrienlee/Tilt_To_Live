using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    //private Quaternion newRotation;

    //public Rigidbody2D Rb { get => rb; set => rb = value; }


    // Update is called once per frame
    void Update()
    {
        // Processing inputs
        ProcessInputs();
    }

    void FixedUpdate()
    {
        // Physics calculations
        Move();
    }

    void ProcessInputs()
    {
        int moveX = (int)Input.GetAxisRaw("Horizontal");
        int moveY = (int)Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        RotatePlayer(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //rb.AddForce = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            //Destroy(collision.gameObject); // destroy what collided with me
            Destroy(this.gameObject); // destroy me
        }
    }*/

    void RotatePlayer(int x, int y)
    {
        // left = -1, right = 1

        switch (x)
        {
            case 1:
                if (y == 0) // right
                    transform.localRotation = Quaternion.Euler(0, 0, 270);
                    //newRotation.z = 270;
                else if (y == 1) // up right
                    transform.localRotation = Quaternion.Euler(0, 0, 315);
                    //newRotation.z = 315;
                else if (y == -1) // down right
                    transform.localRotation = Quaternion.Euler(0, 0, 225);
                    //newRotation.z = 225;
                break;
            case -1:
                if (y == 0) // left
                    transform.localRotation = Quaternion.Euler(0, 0, 90);
                    //newRotation.z = 90;
                else if (y == 1) // up left
                    transform.localRotation = Quaternion.Euler(0, 0, 45);
                    //newRotation.z = 45;
                else if (y == -1) // down left
                    transform.localRotation = Quaternion.Euler(0, 0, 135);
                    //newRotation.z = 135;
                break;
            case 0:
                if (y == 1) // up
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    //newRotation.z = 0;
                else if (y == -1) // down
                    transform.localRotation = Quaternion.Euler(0, 0, 180);
                    //newRotation.z = 180;
                break;
        }

        /*
        if (x < 0 && y == 0) // left
            newRotation.z = 270;
            //transform.Rotate(Vector3.forward * -90);
        else if (x > 0 && y == 0) // right
            newRotation.z = 90;
            //transform.Rotate(Vector3.forward * -90);
        else if (y > 0 && x == 0) // up
            newRotation.z = 0;
            //transform.Rotate(Vector3.forward * -90);
        else if (y < 0 && x == 0) // down
            newRotation.z = 180;
            //transform.Rotate(Vector3.forward * -90);
        */

        //transform.localRotation = newRotation;
    }
}
