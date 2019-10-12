using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossinstancier : MonoBehaviour
{



    [SerializeField] AudioSource audioo;
    [SerializeField] Rigidbody2D boss;
    [SerializeField] GameObject spawn;
   
    [SerializeField]float timer;

    // Start is called before the first frame update
    void Start()
    {
        
       

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >=20)
        {
            audioo.Play();
            Rigidbody2D lineaclon = Instantiate(boss, spawn.transform.position, spawn.transform.rotation);
            timer = 0;

        }

    }
}
