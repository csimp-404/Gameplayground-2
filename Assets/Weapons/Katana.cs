using UnityEngine;

public class Katana : Weapon
{
    public float comboTimeWindow = 0.5f;
    private int comboCount = 0;
    private float lastSwingTime;
    private Animator anim;
    private CharacterAttack playerAttack;

    public override void Equip(CharacterAttack player)
    {
        anim = player.GetComponent<Animator>();
        playerAttack = player;
        comboCount = 0;
    }

    public override void Attack()
    {
        if (Time.time - lastSwingTime > comboTimeWindow)
        {
            comboCount = 0; // reset combo if waited too long
        }

        comboCount++;
        lastSwingTime = Time.time;

        if (comboCount == 1)
        {
            anim.SetTrigger("KatanaAttack1");
        }
        else if (comboCount == 2)
        {
            anim.SetTrigger("KatanaAttack2");
        }
        else
        {
            anim.SetTrigger("KatanaAttack3");
            comboCount = 0;
        }
    }

    // Callbacks from Animation Events to deal damage can live here

}

