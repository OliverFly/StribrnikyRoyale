using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.Animations.Rigging;

public class movement : MonoBehaviour
{

    [SerializeField]
    
    public float speed = 5f;
    public GameObject Player1;
    private GroundCheck GC_script;
    public GameObject Capsule;
    public Rigidbody rb;
    public float JumpForce = 18f;
    public Animator Ani;
    public GameObject Pmodel;
    public float horizontalMove = 0f;
    public Transform GroundCheck;
    public LayerMask Ground;
    public RuntimeAnimatorController Fist;
    public RuntimeAnimatorController Sword;

    //punch
    public float NextFireTime = 0f;
    public float CoolDownTime = 2f;
    public int noOfClicks = 0;
    public float lastClickedTime = 0;
    float MaxComboDelay = 0.5f;
    public bool Punching = false;
    public float PunchedTime;

    //punchUp
    public bool PunchingUp = false;


    //jump
    public float verticalMove = 0f;
    public float startedJump = 0f;
    public bool JumpWaiting = false;


    //jumpfo
    public float startedJumpFo = 0f;
    public bool isJumpFo_sc;   

    //jumpba
    public float startedJumpBa = 0f;
    public bool isJumpBa_sc;

    //crouch
    public float startedUnCrouch;
    public bool ableToWalk = true;
    public bool isCrouching_sc; //kvuli pohybu v crouch


    //model
    public BoxCollider modelbody;

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

    //chars

    public bool balean;
    public BaLeanSC BaLeanSC;
    public int PIndex;
    public bool topg;

    public bool medrick;
    //zkouska
    public bool zk = false;


    //UI

    public Slider slider;
    private void Awake()
    {


        //DODELAT LOW PUNCH/KICK
        // DODELAT SWORD UPHIT A LOW HIT
        
        GC_script = Capsule.GetComponent<GroundCheck>();
        
        //PIndex = PlayerPrefs.GetInt("Choice1");
        
        
        PIndex = 2;
        if (PIndex == 4)
        { 
            topg = true;
            
        }

        if (PIndex == 3)
        { 
            medrick = true;
            Ani.runtimeAnimatorController = Fist;
        }

        if (PIndex == 2)
        {
            balean = true;
            Ani.runtimeAnimatorController = Sword;
        }

        Ani = Pmodel.GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Ani.SetBool("canUnCrouch", true);
        Ani.SetBool("canWalk", true);


        slider.value = 100;
    }

    // Update is called once per frame

    public void Punch()
    {
        
        PunchedTime = Time.time;
        noOfClicks++;
        if(noOfClicks == 1)
        {
            slider.value -= 25;
            Ani.SetBool("hit1", true);

        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
        if (noOfClicks == 2 && Ani.GetCurrentAnimatorStateInfo(0).IsName("Punching") && Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8)
        {
            slider.value -= 25;
            Ani.SetBool("hit1", false);
            Ani.SetBool("hit2", true);
           

        }

        if (noOfClicks >= 2 && Ani.GetCurrentAnimatorStateInfo(0).IsName("Punching2") && Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
           
            Ani.SetBool("hit2", false);
            Ani.SetBool("hit1", false);
            lastClickedTime = Time.time;
            noOfClicks = 0;
            ableToWalk = true;
            Punching = false;

        }

       
    }


    public void PunchUp()
    {
        Ani.SetBool("hitup", true);
        slider.value -= 25;
    }
    

    void Update()
    {

        //stamina
        if(slider.value <= 100)
        {
            slider.value += 0.5f;
        }

        //punchCheck
        if(noOfClicks >= 1 && Ani.GetCurrentAnimatorStateInfo(0).IsName("Punching") && Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            
            Ani.SetBool("hit1", false);
            if(noOfClicks < 2)
            {
                Punching = false;
                ableToWalk = true;
            }
            
            lastClickedTime = Time.time;
            noOfClicks = 0;
            
            
            

        }
        if (Ani.GetCurrentAnimatorStateInfo(0).IsName("Punching2") && Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Ani.SetBool("hit2", false);
            noOfClicks = 0;
            lastClickedTime = Time.time;
            ableToWalk = true;
            Punching = false;

        }

        if (Time.time - PunchedTime > 1.2f && !isCrouching_sc)
        {
            ableToWalk = true;
            Ani.SetBool("hit1", false);
            Punching = false;
           
        }

        if(Time.time - PunchedTime > 1.2f && !isCrouching_sc && noOfClicks < 2)
        {
            noOfClicks = 0;
        }

       


        //punchUPCheck
        if (Ani.GetCurrentAnimatorStateInfo(0).IsName("PunchUp") && Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
        {
            Ani.SetBool("hitup", false);
            PunchingUp = false;
            ableToWalk = true;
            Ani.SetBool("canUnCrouch", true);
        }
        
        //punch
        if (Time.time - lastClickedTime > MaxComboDelay && isGrounded() && Ani.GetBool("isThrow") == false && isJumpBa_sc == false && isJumpFo_sc == false && horizontalMove == 0 && PunchingUp == false && JumpWaiting == false && !Ani.GetBool("isCrouching"))
        {
            if (Input.GetKeyDown(KeyCode.Y) && !Input.GetKeyDown(KeyCode.W) && !JumpWaiting)
            { 
                ableToWalk = false;
                Punching = true;

                Punch();
                
            }

        }

        //punchUP
        if (Time.time - lastClickedTime > MaxComboDelay && isGrounded() && Ani.GetBool("isThrow") == false && isJumpBa_sc == false && isJumpFo_sc == false && horizontalMove == 0 && !PunchingUp && !Ani.GetBool("isCrouching"))
        {
            if (Input.GetKeyDown(KeyCode.Y) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && JumpWaiting)
            {
                PunchingUp = true;
              

            }
            else
            {

            }
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        


        if (horizontalMove == 0 && verticalMove == 0)
        {
            Ani.SetBool("isChill", true);
            
        }
        else
        {
            Ani.SetBool("isChill", false);
            
        }

        if (Ani.GetBool("isThrow") == false && ableToWalk == true)
        {


            //leva

            if (Input.GetKey(KeyCode.A) || isJumpBa_sc == true)
            {
                if (isJumpFo_sc == false)
                {
                    transform.Translate(-Vector3.right * speed * Time.deltaTime);
                    if (isJumpBa_sc == false)
                    {
                        Ani.SetBool("isWalkingBa", true);
                    }
                }

            }
            else
            {
                Ani.SetBool("isWalkingBa", false);

            }

            //prava
            if (Input.GetKey(KeyCode.D) || isJumpFo_sc == true)
            {
                if (isJumpBa_sc == false)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    if (isJumpFo_sc == false)
                    {
                        Ani.SetBool("isWalkingFo", true);
                    }
                }

            }
            else
            {
                Ani.SetBool("isWalkingFo", false);
            }



            //Jump
            if (Input.GetKeyDown(KeyCode.W) && horizontalMove == 0)
            {
                JumpWaiting = true;
                StartCoroutine(JumpWait());
                
                
            }



            if (balean == true)
            {
                if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f && Ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
                {

                    Ani.SetBool("isJumping", false);
                }
                if (Time.time - startedJump >= 1.47f)
                {
                    Ani.SetBool("isJumping", false);

                }

            }
            else
            {
                if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && Ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
                {

                    Ani.SetBool("isJumping", false);

                }

                if (Time.time - startedJump >= 1.37f)
                {
                    Ani.SetBool("isJumping", false);

                }
            }




            //jump dopredu
            if (horizontalMove == 1 && isGrounded() == true && Input.GetKeyDown(KeyCode.W) && !Ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
            {

                isJumpFo_sc = true;
                JumpFo();
                Ani.SetBool("isJumping", false);
            }



            if (Time.time - startedJumpFo >= 1.6f)
            {
                Ani.SetBool("isJumpFo", false);
                isJumpFo_sc = false;

            }

            if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f && Ani.GetCurrentAnimatorStateInfo(0).IsName("JumpFo"))
            {
                Ani.SetBool("isJumpFo", false);
                isJumpFo_sc = false;

            }


            //jump dozadu
            if (horizontalMove == -1 && isGrounded() == true && Input.GetKeyDown(KeyCode.W) && !Ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
            {

                isJumpBa_sc = true;
                JumpBa();
                Ani.SetBool("isJumping", false);
            }



            if (Time.time - startedJumpBa >= 1.5f)
            {
                Ani.SetBool("isJumpBa", false);
                isJumpBa_sc = false;

            }

            if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && Ani.GetCurrentAnimatorStateInfo(0).IsName("JumpBa"))
            {
                Ani.SetBool("isJumpBa", false);
                isJumpBa_sc = false;

            }









            //crouch
            if (Input.GetKeyDown(KeyCode.S) && isGrounded() == true && Ani.GetBool("isThrow") == false && !Punching && !PunchingUp && ableToWalk && !Ani.GetBool("hit1") && !Ani.GetBool("hit2") && !JumpWaiting)
            {
                isCrouching_sc = true;
                Crouch();


            }
        }

        if (Input.GetKeyUp(KeyCode.S) && isGrounded() == true && Ani.GetBool("isThrow") == false && !Punching && !PunchingUp && !Ani.GetBool("hit1") && !Ani.GetBool("hit2"))
        {
            Ani.SetBool("canUnCrouch", true);
            UnCrouch();
            StartCoroutine(CrouchWait());
            

        }

        if(Ani.GetBool("isCrouching"))
        {
            ableToWalk = false;
        }

        if (Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && Ani.GetCurrentAnimatorStateInfo(0).IsName("CrouchToStanding"))
        {
            Ani.SetBool("canUnCrouch", true);
            Ani.SetBool("canWalk", true);
            
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------




    }
    private void FixedUpdate()
    {
        
    }

    public void Jump()
    {

        startedJump = Time.time;
        
        
        
        
        rb.AddForce(0, JumpForce, 0);      
    }
    
    public void JumpFo()
    {
        slider.value -= 10;
        rb.AddForce(50, JumpForce, 0);
        startedJumpFo = Time.time;
        Ani.SetBool("isJumpFo", true);
        Ani.SetBool("isJumping", false);
        
    }


    public void JumpBa()
    {
        slider.value -= 10;
        rb.AddForce(-50, JumpForce, 0);
        startedJumpBa = Time.time;
        Ani.SetBool("isJumpBa", true);
        Ani.SetBool("isJumping", false);

    }


    public bool isGrounded()
    {
        return Physics.CheckBox(GroundCheck.position, new Vector3(0.1f, 0.1f, 0.1f), Quaternion.identity, Ground);
    }

    public void Crouch()
    {
        ableToWalk = false;
        Ani.SetBool("isCrouching", true);
        Ani.SetBool("canWalk", false);
    }

    public void UnCrouch()
    {
        startedUnCrouch = Time.time;
        Ani.SetBool("isCrouching", false);
        Ani.SetBool("canUnCrouch" , false);
       
    }

    IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(0.15f);
        if (isGrounded() == true && !isJumpBa_sc && !isJumpFo_sc && ableToWalk == true && PunchingUp == false)
        {
            Ani.SetBool("isJumping", true);
            Jump();
        }
        else if (PunchingUp == true)
        {


            PunchUp();


        }
        JumpWaiting = false;
    }

    IEnumerator CrouchWait()
    {
        yield return new WaitForSeconds(0.2f);
        ableToWalk = true;
        isCrouching_sc = false;  //POKUD SE DRZI POHYB V CROUCH TAK ABLETOWALK = FALSE COZ JE SPATNE
    }

}
