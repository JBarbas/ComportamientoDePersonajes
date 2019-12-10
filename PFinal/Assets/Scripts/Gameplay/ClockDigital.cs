using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ClockDigital : MonoBehaviour
{
    public Text textClock;
    public float hour = 0.0f, min = 0.0f, sec = 0.0f;
    public string hora, minuto, segundo;

public void Update()
    {
        {
            //Utilizo la hora del sistema para sumar a sec
            sec += Time.deltaTime;
            //Voy definiendo si hay paso de minuto y paso de hora siguiente
            if (sec >= 59.0)
            {

                min = min + 1;
                sec = 0;
                if (min >= 59.0)
                {
                    hour=hour+1;
                    min= 0;
                    sec = 0;
                }
            }
            //Aqui añado un 0 de decoracion delante de cada valor
            if (hour < 9)
                hora = "0" + hour.ToString("f0");
            else
            {
                hora = hour.ToString("f0");
            }

            if (min < 9)
                minuto = "0" + min.ToString("f0");
            else
            {
                minuto = min.ToString("f0");
            }

            if (sec < 9)
                segundo = "0" + sec.ToString("f0");
            else
            {
                segundo = sec.ToString("f0");
            }

            //defino la hora en el campo texto a cada vuelta
            textClock.text = hora + ":" + minuto + ":" + segundo;

        }
    }
    
}
