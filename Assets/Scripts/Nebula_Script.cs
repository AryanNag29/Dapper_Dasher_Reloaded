using UnityEngine;

public class Nebula_Script : MonoBehaviour
{
    //searializeFields
    [SerializeField] private BoxCollider2D nebulaBoxCollider;

    //variables
    private int nebulaMovement = 10; 
    private float deadZone = -12.1f;

    
    //functions


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //more the nebula to the left
        transform.position = transform.position + Vector3.left * nebulaMovement * Time.deltaTime;

        //destroy gameObject after it reach dead zone
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }


    }
}
