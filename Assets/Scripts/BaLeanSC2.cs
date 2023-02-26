using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BaLeanSC2 : MonoBehaviour
{

    public Collider LeftLeg;
    public Collider RightLeg;
    public Collider UpLeftLeg;
    public Collider UpRightLeg;
    public Collider Head;
    public Collider Body;
    public Collider LeftArm;
    public Collider RightArm;
    public Collider UpLeftArm;
    public Collider UpRightArm;
    public Collider RightFeet;
    public Collider LeftFeet;





    public GameObject Player2;
    public GameObject Comp1;
    public GameObject Comp2;
    public GameObject Comp3;
    GameObject[] comp = new GameObject[3];
    public bool isThrowing = false;
    public GameObject HandForThrow;
    Rigidbody rb;
    Vector3 lol;
    public GameObject component;
    public movement2 movement;

    public DesObj desobj;

    public float tx;
    public float ty;


    public float startedThrow;
    float waittime = 3f;
    public bool canThrow;
    bool canDo;
    public Animator Ani;

    public bool isInverted = false;
    float invertedTime = 5f;
    float invertCoolDown = 5f;
    bool idk = true;
    // Start is called before the first frame update
    void Start()
    {
        comp[0] = Comp1;
        comp[1] = Comp2;
        comp[2] = Comp3;


    }

    // Update is called once per frame
    void Update()
    {



        if (PlayerPrefs.GetInt("Choice1") == 2)
        {
            Player2.tag = "CompcolHit";


            LeftLeg.tag = "CompcolHit";
            RightLeg.tag = "CompcolHit";
            UpLeftLeg.tag = "CompcolHit";
            UpRightLeg.tag = "CompcolHit";
            Head.tag = "CompcolHit";
            Body.tag = "CompcolHit";
            LeftArm.tag = "CompcolHit";
            RightArm.tag = "CompcolHit";
            UpLeftArm.tag = "CompcolHit";
            UpRightArm.tag = "CompcolHit";
            RightFeet.tag = "CompcolHit";
            LeftFeet.tag = "CompcolHit";
        }






        if (PlayerPrefs.GetInt("Choice2") == 2)
        {


            lol = new Vector3(HandForThrow.transform.position.x, HandForThrow.transform.position.y, HandForThrow.transform.position.z + 1f);

            //components
            if (Input.GetKeyDown(KeyCode.O) && canThrow == true && Ani.GetBool("isCrouching") == false && movement.isGrounded())
            {
                canThrow = false;
                startedThrow = Time.time;

                Ani.SetBool("isThrow", true);
                canThrow = false;
                StartCoroutine(Throw());

            }


            if (Time.time - startedThrow > waittime)
            {
                canThrow = true;
            }

            if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && Ani.GetCurrentAnimatorStateInfo(0).IsName("Throw Object"))
            {
                Ani.SetBool("isThrow", false);
                Ani.SetBool("canUnCrouch", true);

            }


            //INVERTED MOVEMENT
            if (Input.GetKeyDown(KeyCode.T) && movement.isGrounded() && idk == false)
            {
                isInverted = true;


            }


        }

    }

    IEnumerator Throw()
    {

        int rand = Random.Range(0, 3);
        int rand2 = Random.Range(-30, 31);
        int rand3 = Random.Range(-30, 31);
        int rand4 = Random.Range(-30, 31);
        yield return new WaitForSeconds(0.48f);
        if (canThrow == false)
        {

            component = Instantiate(comp[rand], lol, Quaternion.Euler(0, 0, 0));

            rb = component.GetComponent<Rigidbody>();
            rb.AddForce(-tx, ty, 0);
            rb.AddTorque(rand2, rand3, rand4);
            desobj = component.GetComponent<DesObj>();
        }


    }


}
