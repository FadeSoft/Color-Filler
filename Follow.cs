using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
   
    void Update()
    {
        transform.position=Vector3.Lerp(transform.position+offset ,new Vector3(Player.transform.position.x,11, Player.transform.position.z-11f), 2f);
    
    }
}
