using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform player;
    // Update is called once per frame
    public Vector3 offset;
    void Update()
    {
      //  Debug.Log(player.position);
        transform.position = player.position + offset;
    }
}
