using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class Scrolling_Background_Script : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float scrollSpeed = 2f;

    private float imageWidth;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        imageWidth = spriteRenderer.size.x;
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size *= new Vector2(x: 3, y: 1);

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) >= imageWidth)
        {
            transform.position = Vector3.zero;
        }
    }
}
