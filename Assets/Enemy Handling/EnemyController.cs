using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stoppingDistance = 0.1f;

    private Vector3 lastPosition;
    private Animator animator;

    void Start()
    {
        lastPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            float distance = direction.magnitude;

            //Debug.Log("Current Distance: " + distance + " | Stopping Distance: " + stoppingDistance);

            if (distance > stoppingDistance)
            {
                // Move towards player if outside stopping distance
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Optional flip sprite
                if (direction.x != 0)
                {
                    transform.localScale = new Vector3(Mathf.Sign(direction.x), transform.localScale.y, transform.localScale.z);
                }
            }

            // Update animator speed parameter regardless, so the animation stops moving too
            float currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
            if (animator != null)
            {
                animator.SetFloat("Speed", currentSpeed);
            }

            lastPosition = transform.position;
        }
    }
}
