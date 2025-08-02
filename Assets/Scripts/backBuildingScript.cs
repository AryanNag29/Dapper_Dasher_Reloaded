using UnityEngine;

public class backBuildingScript : MonoBehaviour
{
    //instances
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float scrollSpeed = 1.5f;

    //variables
    private float imageWidth;
    Vector3 temp;


    void Start()
    {
        //store current transform position of background to temp
        temp = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //increase size of background by 3 times
        spriteRenderer.size *= new Vector2(x: 3, y: 1);
        imageWidth = spriteRenderer.size.x;
        //make it tiled
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //make it scroll with some speed 
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        //reset the scroll when it reach it limit
        if (Mathf.Abs(transform.position.x) >= imageWidth)
        {
            transform.position = temp;
        }
    }
}

