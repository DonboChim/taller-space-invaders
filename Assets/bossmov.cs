using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmov : MonoBehaviour
{   float velocidad =5;
    bool canMove=true;
    Vector3 direccionx;
    // Start is called before the first frame update
    void Start()
    {
        direccionx = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            
            transform.position += direccionx * velocidad * Time.deltaTime;
        }
    }
}
