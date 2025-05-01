using System.Runtime.ExceptionServices;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public Transform character; // Reference to the character's transform
    public Camera mainCamera;   // Reference to the main camera

    private SpriteRenderer characterSpriteRenderer;

    private void Start()
    {
        // Get the character's SpriteRenderer to check if it is flipped
        characterSpriteRenderer = character.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Ensure the Z position stays at 0

        // Calculate direction from the cursor to the character
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adjust the angle based on the character's flip state
        if (characterSpriteRenderer.flipX)
        {
            // If the character is flipped, reverse the angle
            angle += 180f;
        }

        // Set the rotation to face the mouse
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
