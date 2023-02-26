using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedrickMenuAnimations : MonoBehaviour
{

    bool cancheck = true;
    float aniTime;
    public Animator Ani;
    public float waitTime = 40;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && Ani.GetCurrentAnimatorStateInfo(0).IsName("MedricktauntMenu"))
        {
            Ani.SetBool("taunt", false);
        }


        if (Time.time - aniTime > waitTime)
        {
            What();
        }

    }


    public void What()
    {
        aniTime = Time.time;
        Ani.SetBool("taunt", true);

    }
}
