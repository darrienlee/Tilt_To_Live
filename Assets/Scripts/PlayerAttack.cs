using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform firePosition;
    public GameObject projectile;
    public float CDTime; // = 1.0f; // cooldown timer on shoot
    private float nextFireTime = 0f;
    //private bool offCD; // = true;

    /*void Awake()
    {
        offCD = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if(Time.time > nextFireTime && offCD == false)
        {
            offCD = true;
        }*/

        if (Time.time > nextFireTime) // && offCD == false) // if (offCD == true)
        {
            // get input from player
            if ((int)Input.GetAxisRaw("Jump") == 1) //Input.GetMouseButtonDown("Jump"))
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                nextFireTime = Time.time + CDTime;
                //offCD = false;
            }
        }
        /*else if(offCD == false)
        {
            nextFireTime = Time.time + CDTime;
        }*/
    }
}
