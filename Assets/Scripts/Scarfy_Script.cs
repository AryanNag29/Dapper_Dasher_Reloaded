using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Scarfy_Script : MonoBehaviour
{
    //SearializeField
    [Header("SearializeField")]
    [SerializeField] private BoxCollider2D ScarfyBoxCollider;
    [SerializeField] private Animator ScarfyAnimator;
    [SerializeField] private SpriteRenderer ScarfyRanderer;
    [SerializeField] private GameObject scarfyObject;


    //variables
    public bool isScarfyAlive = true;
    public LogicManager logic;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;
    private float jump = 10f;
    private float velocity;
    private float gravityScale = 1f;
    private float flooreHeight = 0.00001f;
    


    //functions of main scarfy

    //this is the raycast method to do ground check
    private bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {

            logic.gameOver();
            isScarfyAlive = false;
            
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //access the logic script
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicManager>();

        //it gets components
        ScarfyAnimator = GetComponent<Animator>();
        ScarfyRanderer = GetComponent<SpriteRenderer>();
        scarfyObject = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        //add gravity for the scarfy and also multiplay gravity two time because gravity is not a constant value it change and gravity is 9.8m/s*2
        velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime; // one time here 

        //turn off gravity when is grounded is true
        if (isGrounded() == true && velocity < 0)
        {
            velocity = 0;
            //fix the late realise of the ground check snap back it up 
            Vector2 surface = Physics2D.ClosestPoint(transform.position, ScarfyBoxCollider) + Vector2.up * flooreHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);

        }

        //scarfy jump
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded() && isScarfyAlive)
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            velocity = jump;    //scarfy goes up in y axix when pressing space key
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            if (jumpTime > 0)
            {
                velocity = jump;
                jumpTime -= Time.deltaTime;
                transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
            }
            else
            {
                isJumping = false;
            }
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime); // second time here

        if (!isGrounded())
        {
            ScarfyAnimator.speed = 0;
        }
        else
        {
            ScarfyAnimator.speed = 1;
        }
        if (!isScarfyAlive)
        {
            Destroy(gameObject);
        }

    }
    
}



