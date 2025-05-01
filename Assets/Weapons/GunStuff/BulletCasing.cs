using UnityEngine;

public class ShellCasingScript : MonoBehaviour
{
    public float ejectForce = 2f;
    public float ejectTorque = 2f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * ejectForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-ejectTorque, ejectTorque), ForceMode2D.Impulse);
        Destroy(gameObject, 3f); // Destroy after 3 seconds
    }
}