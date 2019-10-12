using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    [SerializeField]int deathcounter;
    int points = 100;
    linea line;
    gamemanager gamemanag;
    public int Deathcounter { get => deathcounter; set => deathcounter = value; }

    // Start is called before the first frame update
    void Start()
    {
        line = transform.parent.GetComponent<linea>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gamemanag = GameObject.Find("background").GetComponent<gamemanager>();
            gamemanag.Puntuar(points);
            gamemanag.CountEnemies();
            
            line.Count();

            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "PlayerLine")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
