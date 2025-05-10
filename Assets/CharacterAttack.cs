using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
public class CharacterAttack : MonoBehaviour
{
    public Animator animator; // make accessible
    public Rigidbody2D rb;
    public Weapon startingWeapon;
    public Weapon currentWeapon;
    public bool IsAttacking
    {
        get
        {
            return animator != null && animator.GetBool("IsAttacking");
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        if (startingWeapon != null)
            EquipWeapon(startingWeapon);
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            if (rb != null) rb.linearVelocity = Vector2.zero;
            currentWeapon.Attack();
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (currentWeapon != null) currentWeapon.Unequip();
        currentWeapon = weapon;
        if (currentWeapon != null) currentWeapon.Equip(this);
    }

    public void JabDamageEvent()
    {
        if (currentWeapon is UnarmedWeapon unarmed)
        {
            unarmed.JabDamage();
        }
    }

    public void CrossDamageEvent()
    {
        if (currentWeapon is UnarmedWeapon unarmed)
        {
            unarmed.CrossDamage();
        }
    }

    public void EndJabEvent()
    {
        if (currentWeapon is UnarmedWeapon unarmed)
        {
            unarmed.EndJab();
        }
    }

    public void EndCrossEvent()
    {
        if (currentWeapon is UnarmedWeapon unarmed)
        {
            unarmed.EndCross();
        }
    }

}
