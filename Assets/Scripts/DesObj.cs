using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DesObj : MonoBehaviour
{

    public BaLeanSC BaLeanSC;
    public BaLeanSC2 BaLeanSC2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Choice2") == 2)
        {
            BaLeanSC2 = FindObjectOfType<BaLeanSC2>();
        }
        else if(PlayerPrefs.GetInt("Choice1") == 2)
        {
            BaLeanSC = FindObjectOfType<BaLeanSC>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag.Contains("CompcolHit") || col.collider.tag.Contains("Ground"))
        {
            if (PlayerPrefs.GetInt("Choice2") == 2)
            {
                Destroy(BaLeanSC2.component);
            }
            else if (PlayerPrefs.GetInt("Choice1") == 2)
            {
                Destroy(BaLeanSC.component);
            }
            
            
        }

    }
}
