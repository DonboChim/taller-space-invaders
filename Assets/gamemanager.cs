using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    [SerializeField]Text scoretext;
    [SerializeField] Text lifestext;
    [SerializeField] Text beatenenemiestext;
    [SerializeField]int puntuacion;
    AudioSource audioo;
    int vidas=3;
    [SerializeField]int beatenenemies;

    public int Beatenenemies { get => beatenenemies; set => beatenenemies = value; }

    // Start is called before the first frame update
    void Start()
    {
        audioo = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (vidas == 0)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        beatenenemiestext.text = beatenenemies.ToString("F0");
        scoretext.text = puntuacion.ToString("F1");
        lifestext.text = vidas.ToString("F0");
    }
   public  void Puntuar(int puntos)
    {
        puntuacion += puntos;
    }
    public void LifesCounter()
    {
        vidas--;
    }
    public void CountEnemies()
    {
        beatenenemies++;
    }
}
