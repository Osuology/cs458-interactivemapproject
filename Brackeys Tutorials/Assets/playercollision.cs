using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollision : MonoBehaviour
{   //https://www.youtube.com/watch?v=gAB64vfbrhI&list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6&index=6
    //update to collisionInfo.gameObject.tag the old video is depreciated
    public playermovement movement;
    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        //Debug.Log("we hit obstacle");
        if (collisionInfo.gameObject.tag == "obstacle")
        {
            Debug.Log("we hit obstacle");
            movement.enabled = false;
        }
    }
}
