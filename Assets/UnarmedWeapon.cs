using UnityEngine;

using System.Collections;

public class UnarmedWeapon : Weapon
{
    public float jabDamage = 20f;
    public float crossDamage = 40f;
    public Transform attackPoint;
    public float radius = 1f;
    public LayerMask enemies;

    private int comboStep = 0;
    private int clickCount = 0;

    private Animator anim;
    private CharacterAttack playerAttack;

    public override void Equip(CharacterAttack player)
    {
        anim = player.GetComponent<Animator>();
        playerAttack = player;
        comboStep = 0;
        clickCount = 0;
    }

    public override void Attack()
    {
        if (comboStep == 0 && !anim.GetBool("IsAttacking"))
        {
            comboStep = 1;
            anim.SetBool("IsAttacking", true);
            anim.SetTrigger("Jab");
            clickCount = 1;
        }
        else if (comboStep == 1 && anim.GetBool("IsAttacking"))
        {
            clickCount++;
        }
    }

    // Called by animation events
    public void JabDamage()
    {
        DealDamage(jabDamage);
    }

    public void CrossDamage()
    {
        DealDamage(crossDamage);
    }

    public void EndJab()
    {
        if (clickCount >= 2)
        {
            anim.SetTrigger("Cross");
        }
        else
        {
            anim.SetBool("IsAttacking", false);
            comboStep = 0;
            clickCount = 0;
        }
    }

    public void EndCross()
    {
        anim.SetBool("IsAttacking", false);
        comboStep = 0;
        clickCount = 0;
    }

    private void DealDamage(float dmg)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<EnemyCombat>(out var enemy))
            {
                enemy.TakeDamage(dmg);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
