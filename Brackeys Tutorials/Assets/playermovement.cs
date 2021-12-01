using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{  
    // Start is called before the first frame update
    public Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,2000 * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0 , 0);
        }
        if(Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0 , 0);
        }
    }
}
