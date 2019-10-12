using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fill : MonoBehaviour
{
    Image imagen;
    shoot cooldown;
    float cooldownrafaga = 30;
    bool descontar;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GetComponent<Image>();
        cooldown = GameObject.Find("Torreta").GetComponent<shoot>();
    }

    // Update is called once per frame
    void Update()
    {
       if(cooldown.Cooldownrafaga == 30)
        {
            imagen.fillAmount =0;
            descontar = false;
        }
        else
        {
            if (descontar == false)
            {
                imagen.fillAmount = 1;
                descontar = true;
            }

           
            
            {
                if (descontar == true)
                {
                    imagen.fillAmount -= 1 / cooldownrafaga * Time.deltaTime;
                    
                }
            }

        }
    }
}
