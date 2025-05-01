using UnityEngine;

public class BalancedCharacter : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        characterName = "Balanced";
        stats.maxHealth = 100;
        stats.attackPower = 20;
        stats.defense = 10;
        stats.moveSpeed = 0.6f;
        //stats.knockback.x = 1f;
        //stats.knockback.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
