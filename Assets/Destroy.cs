using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    SpriteRenderer sprite;
    int counter;
    
    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
   
    private void Update()
    {
        if (counter == 1)
        {
            sprite.color = new Color(1,0,0);
        }
        if(counter >= 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BulletE")
        {
            counter++;
        }
    }


}
