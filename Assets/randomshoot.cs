using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomshoot : MonoBehaviour
{
    int random;
    bool canShoot;
    public GameObject spawn;
    public Rigidbody2D rbbala;
    [SerializeField] private int fuerza;
    float timer;
    
    

    
    public int Fuerza { get => fuerza; set => fuerza = value; }
    // Start is called before the first frame update
    void Start()
    {
        
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            Rvalue();

        }
    }
    void Shoot()
    {
        Rigidbody2D rbbalaclon = Instantiate(rbbala, spawn.transform.position, spawn.transform.rotation);
        rbbalaclon.AddForce(transform.up*-1 * Fuerza);
        
    }
    void Rvalue()
    {
        random = Random.Range(1, 15);
        timer = 0;
        if (random <= 1)
        {
            canShoot = true;

        }
    
        if (canShoot == true)
        {
            Shoot();
            canShoot = false;
        }
        
         
    }
}
