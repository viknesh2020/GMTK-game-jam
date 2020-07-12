using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningColor : MonoBehaviour
{


   public Color colorStart ;
   public Color colorEnd ;
   public float duration = 1.0f;
    Renderer rend;

    
    public Transform player;
    public Image image;


    void Start()
    {/*
        rend = GetComponent<Renderer>();*/
    }

    void Update()
    {/*
        var difference = player.position - transform.position;
        if (difference.y < 2)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
        else
            rend.material.color = Color.Lerp(colorEnd,colorStart, Time.time/duration);*/
        var difference = player.position - transform.position;
        if (difference.y < 2)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            image.color = Color.Lerp(colorStart, colorEnd, lerp);
        }
        else
           image.color = colorStart;

    }

}
