using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DesObj2 : MonoBehaviour
{

    public BaLeanSC2 BaLeanSC;

    // Start is called before the first frame update
    void Start()
    {
        BaLeanSC = FindObjectOfType<BaLeanSC2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag.Contains("colHit") || col.collider.tag.Contains("Ground"))
        {
            Destroy(BaLeanSC.component);

        }

    }
}
