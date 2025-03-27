using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    //--components--
    private Animator anim;
    public GameObject attackPoint;
    private GameObject player;
    public float radius;
    public LayerMask enemies;
    private Rigidbody2D rb;
    private CharacterStats stats;

    private bool isAttacking;
    private int clickCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        
    }
}