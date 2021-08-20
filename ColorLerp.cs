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
        //Menüdeki arkaplan renk geçiþleri için yazdýðým kod. Animasyonlada yapardým ama yeni kodlar denemek istedim.
    }
}
