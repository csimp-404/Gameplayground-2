using UnityEngine;

public class DynamicLayering : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Adjust the sorting order based on the Y position
        // For 2D, we typically use the Y position to determine the order of rendering
        spriteRenderer.sortingOrder = Mathf.FloorToInt(-transform.position.y * 100);  // Multiply by 100 for smoother sorting
    }
}
