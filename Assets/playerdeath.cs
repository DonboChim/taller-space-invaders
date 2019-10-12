using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdeath : MonoBehaviour
{
    [SerializeField] AudioSource audioo;
    [SerializeField]float timer;
    bool timerenabled;
    gamemanager gamemanag;
    bool stoptime;
    [SerializeField]ParticleSystem explosion;

    public bool Stoptime { get => stoptime; set => stoptime = value; }

    // Start is called before the first frame update
    void Start()
    {
        stoptime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerenabled == true)
        {
            timer += Time.deltaTime;
           
        }
        if (timer >= 3)
        {
            transform.Find("Sprite").gameObject.SetActive(true);
            transform.GetComponent<BoxCollider2D>().enabled = true;
            timer = 0;
            stoptime = false;
            timerenabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletE")
        {
            audioo.Play();
            explosion.Play();
            stoptime = true;
            timerenabled = true;
            transform.Find("Sprite").gameObject.SetActive(false);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            gamemanag = GameObject.Find("background").GetComponent<gamemanager>();
            gamemanag.LifesCounter();

        }
    }
   
}
