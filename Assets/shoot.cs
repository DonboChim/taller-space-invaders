using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class shoot : MonoBehaviour
{
    [SerializeField] AudioSource audioo;
    public GameObject spawn;
    public Rigidbody2D rbbala;
    public Rigidbody2D rbbala2;
    [SerializeField] private int fuerza;
    [SerializeField] private int fuerzabala2;
    
    private int touchcounter;
    bool RafagaActiva;
    bool countcooldownrafaga;
    bool countcooldownswipe;
    [SerializeField]float duracionrafaga;
    bool counttime;
   
    [SerializeField] float cooldownrafaga;
    [SerializeField] float cooldownswipe;

    public int Fuerza { get => fuerza; set => fuerza = value; }
    public float Cooldownrafaga { get => cooldownrafaga; set => cooldownrafaga = value; }
    public float Cooldownswipe { get => cooldownswipe; set => cooldownswipe = value; }

    private Vector2 touch;
    private Vector2 release;
    float rango=15;
    bool canshoot;
    bool canMove;



    // Use this for initialization
    void Start()
    {
        canshoot = true;
        canMove = true;
        Cooldownrafaga = 30;
        Cooldownswipe = 60;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Torreta").GetComponent<playerdeath>().Stoptime==true)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        if (canMove== true)
        {
            if (counttime == true)
            {
                duracionrafaga += Time.deltaTime;

            }
            if (countcooldownrafaga == true)
            {
                Cooldownrafaga -= Time.deltaTime;
            }

            if (countcooldownswipe == true)
            {
                Cooldownswipe -= Time.deltaTime;
            }
            if (duracionrafaga <= 3 && counttime == true && canshoot == true)
            {
                canshoot = false;
                StartCoroutine("Rafaga");

            }
            if (duracionrafaga > 3)
            {
                canshoot = true;
                counttime = false;
                duracionrafaga = 0;
                StopCoroutine("Rafaga");


            }


            if (Cooldownrafaga <= 0)
            {
                Cooldownrafaga = 30;
                countcooldownrafaga = false;

            }
            if (Cooldownswipe <= 0)
            {
                Cooldownswipe = 60;
                countcooldownswipe = false;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount == 1)
            {

                Shoot();


            }
            if (Input.GetTouch(0).phase == TouchPhase.Began && Input.touchCount == 3 && Cooldownrafaga == 30)
            {
                counttime = true;
                countcooldownrafaga = true;

            }

            if (Input.touchCount == 1 && Cooldownswipe == 60)
            {

                foreach (Touch touches in Input.touches)
                {
                    if (touches.phase == TouchPhase.Began)
                    {
                        touch = touches.position;
                    }
                    if (touches.phase == TouchPhase.Ended)
                    {
                        release = touches.position;
                        SwipeArriba();
                    }
                }

            }
        }
    }
    void SwipeArriba()
    {
        float valorvertical = Mathf.Abs(touch.y - release.y);
        float valorhorizontal = Mathf.Abs(touch.x - release.x);


        if (touch.y - release.y < 0 && valorvertical> rango && valorvertical>valorhorizontal )
        {
            audioo.Play();
            Rigidbody2D rbbalaclon = Instantiate(rbbala2, spawn.transform.position, spawn.transform.rotation);
            rbbalaclon.AddForce(transform.right * fuerzabala2);
            countcooldownswipe = true;
        }
        
            touch = release;

    }

    IEnumerator Rafaga()
    {
        while (canshoot == false)
        {

            Rigidbody2D rbbalaclon = Instantiate(rbbala, spawn.transform.position, spawn.transform.rotation);
            rbbalaclon.AddForce(transform.right * Fuerza);
            yield return new WaitForSeconds(0.1f);

        }
 
    }
    private void Shoot()
    {
        Rigidbody2D rbbalaclon = Instantiate(rbbala, spawn.transform.position, spawn.transform.rotation);
        rbbalaclon.AddForce(transform.right * Fuerza);
        
    }
  
    

   
    
}
