using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Scarfy_Script : MonoBehaviour
{   
    //SearializeField
    [SerializeField] private Rigidbody2D ScarfyRigigBody;
    [SerializeField] private BoxCollider2D ScarfyBoxCollider;
    [SerializeField] private Animator ScarfyAnimator;
    [SerializeField] private SpriteRenderer ScarfyRanderer;

    //variables
    private bool isOnGround;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public float jumpVelocity = 1f;
    private float downVelocity = 20.0f;
    private float normalGravity = 1f;

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
        Gizmos.DrawWireCube(transform.position - transform.up*castDistance, boxSize);
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
        ScarfyRigigBody = GetComponent<Rigidbody2D>();
        ScarfyAnimator = GetComponent<Animator>();
        ScarfyRanderer = GetComponent<SpriteRenderer>();
        Debug.Log(transform);
    }

    // Update is called once per frame
    void Update()
    {

        //scarfy jump
        if (UnityEngine.Input.GetKey(KeyCode.Space) && isGrounded() || UnityEngine.Input.GetKey(KeyCode.Mouse0) && isGrounded())
        {
            ScarfyRigigBody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);    //scarfy goes up in y axix when pressing space key
        }

        //scarfy dash
        if (UnityEngine.Input.GetKey(KeyCode.V) && !isGrounded() || UnityEngine.Input.GetKey(KeyCode.Mouse1) && !isGrounded())
        {
            ScarfyRigigBody.gravityScale = downVelocity;
        }
        else
        {
            ScarfyRigigBody.gravityScale = normalGravity;
        }

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


