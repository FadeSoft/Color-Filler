using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public Camera cam;
    public Color pings;
 
    void Update()
    {
        cam.backgroundColor = Color.Lerp(Color.yellow, pings, Mathf.PingPong(Time.time,1.3f));
        //Men�deki arkaplan renk ge�i�leri i�in yazd���m kod. Animasyonlada yapard�m ama yeni kodlar denemek istedim.
    }
}
