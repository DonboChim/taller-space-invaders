using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linea : MonoBehaviour
{
    [SerializeField]GameObject[] ovnis;
    [SerializeField]float velocidad;
    [SerializeField] GameObject spawn;
    Vector3 direccionx;
    Vector3 direcciony;
    Vector3 position;
    int deathcounter;
    bool canCount =false;
    bool canMove = true;
    [SerializeField]Rigidbody2D Linea;
    gamemanager gamemanag;

    // Start is called before the first frame update
    void Start()
    {
        deathcounter = 0;
        gamemanag = GameObject.Find("background").GetComponent<gamemanager>();
        direccionx = new Vector3(1, 0, 0);
        direcciony = new Vector3(0, -0.5f, 0);
         
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
            velocidad = gamemanag.Beatenenemies * 0.05f;
            transform.position += direccionx * velocidad * Time.deltaTime;

            if (deathcounter == 11)
            {

                Rigidbody2D lineaclon = Instantiate(Linea, spawn.transform.position, spawn.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pared")
        {

            direccionx.x *= -1;
            transform.position += direcciony;

        }
    }
    public void Count()
    {
        deathcounter++;
        
    }
}
