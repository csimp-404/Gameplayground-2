using UnityEngine;

public class Toggle : MonoBehaviour
{
    private GameObject player;
    private GameObject hands;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponentInParent<GameObject>();
        hands = GetComponent<GameObject>();
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //if (
        }
    }
}
