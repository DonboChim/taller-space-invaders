using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class fade : MonoBehaviour
{
     TextMeshProUGUI text;
    float posA;
    float posB;
    Vector3 currentPosition;
    [SerializeField]Color colorA;
    [SerializeField]Color colorB;
    float time;
    float duration=1.2f;
    bool state;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (state)
        {
            text.color = Color.Lerp(colorA, colorB, time / duration);
            
        }
        else
        {
            text.color = Color.Lerp(colorB, colorA, time / duration);
        }

        
        time += Time.deltaTime;
        if (time >= duration)
        {
            time = 0;
            state = !state;
        }
    }
}
