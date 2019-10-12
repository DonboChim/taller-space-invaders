using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    [SerializeField]AudioSource audioo;
    Rigidbody2D torretafuerza;
    Rigidbody2D rb;
    GameObject bullet;
    [SerializeField]string bullettype;

    // Start is called before the first frame update
    void Start()
    {
        
        torretafuerza = GameObject.Find("Torreta").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bullettype == "normal" )
        {
            audioo.Play();
            Destroy(gameObject);

        }
        if (bullettype == "enemyB")
        {
            
            Destroy(gameObject);

        }

    }


}
