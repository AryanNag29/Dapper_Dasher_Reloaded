using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Scarfy_Script : MonoBehaviour
{   
    //SearializeField
    [SerializeField] private Rigidbody2D ScarfyRigigBody;
    [SerializeField] private BoxCollider2D ScarfyBoxCollider;

    //variables
    public bool isOnGround;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public float jumpVelocity = 7.0f;

    //functions of main scarfy

    //this is the raycast method to do ground check
    public bool isGrounded()
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
    public void OnDrawGizmos()
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
        Debug.Log(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            ScarfyRigigBody.linearVelocity = Vector2.up * jumpVelocity;    //scarfy goes up in y axix when pressing space key
        }
    }
}


