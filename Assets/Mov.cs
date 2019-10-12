using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Mov : MonoBehaviour
{
    Rigidbody2D rb;
    float direction;
    float speed=10
        ;
    Vector3 posactual;
    bool canMove;
   
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Torreta").GetComponent<playerdeath>().Stoptime == true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (canMove == true)
        {
            direction = Input.acceleration.x * speed;


            rb.velocity = new Vector2(direction, 0);


            if (transform.position.x > 8)
            {
                rb.velocity = new Vector2(0, 0);
                posactual = new Vector3(8, -4.25f, 0);
                transform.position = posactual;





            }
            if (transform.position.x < -8)
            {
                rb.velocity = new Vector2(0, 0);
                posactual = new Vector3(-8, -4.25f, 0);
                transform.position = posactual;




            }
        }

    }
}
