using UnityEngine;

public class Nebula_Script : MonoBehaviour
{
    [SerializeField] private BoxCollider2D nebulaBoxCollider;
    public int nebulaMovement = 5;
    private float deadZone = -12.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * nebulaMovement * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
