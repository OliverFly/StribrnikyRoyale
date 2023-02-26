using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck2 : MonoBehaviour
{


    public bool isGrounded2;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded2 = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded2 = false;
        }
    }
}
