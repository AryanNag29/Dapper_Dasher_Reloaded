using UnityEngine;

public class Nebula_Script : MonoBehaviour
{
    //searializeFields
    [SerializeField] private BoxCollider2D nebulaBoxCollider;
    public Scarfy_Script scarfy;

    //variables
    private int nebulaMovement = 10; 
    private float deadZone = -12.1f;

    
    //functions


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //access the scarfy script
        scarfy = GameObject.FindWithTag("Player").GetComponent<Scarfy_Script>();
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

        if (!scarfy.isScarfyAlive)
        {
            Destroy(gameObject);
        }



    }
}
