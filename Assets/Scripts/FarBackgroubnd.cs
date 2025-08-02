using System.Runtime.CompilerServices;
using UnityEngine;

public class FarBackgroubnd : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float scrollSpeed = 2f;

    private float imageWidth;

    Vector3 temp;
    void Start()
    {
        temp = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.size *= new Vector2(x: 3, y: 1);
        imageWidth = spriteRenderer.size.x;
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) >= imageWidth)
        {
            transform.position = temp;
        }
    }
}
