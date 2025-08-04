using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

    //variables
    public float jumpCap = -0.16f;
    private bool isOnGround;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    [SerializeField] private float jump = 20f;
    private float velocity;
    private float gravityScale = 1f;
    private float downVelocity = 20.0f;
    private float normalGravity = 1f;
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



    //not very useful
    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //it gets components
        ScarfyAnimator = GetComponent<Animator>();
        ScarfyRanderer = GetComponent<SpriteRenderer>();
        
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
        if (UnityEngine.Input.GetKey(KeyCode.Space) && isGrounded() || UnityEngine.Input.GetKey(KeyCode.Mouse0) && isGrounded())
        {
            velocity = jump;    //scarfy goes up in y axix when pressing space key
            
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime); // second time here

        //scarfy dash
        /*if (UnityEngine.Input.GetKey(KeyCode.V) && !isGrounded() || UnityEngine.Input.GetKey(KeyCode.Mouse1) && !isGrounded())
        {
            ScarfyRigigBody.gravityScale = downVelocity;
        }
        else
        {
            ScarfyRigigBody.gravityScale = normalGravity;
        }*/

        //when scarfy is not on ground animation will pause 
        if (!isGrounded())
        {
            ScarfyAnimator.speed = 0;
        }
        else
        {
            ScarfyAnimator.speed = 1;
        }



    }
}


