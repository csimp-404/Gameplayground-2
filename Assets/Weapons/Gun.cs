using UnityEngine;

public class Gun : Weapon
{
    public override void Attack()
    {
        Debug.Log("Bang!");
        // Instantiate bullet/projectile, add spread, reduce ammo, etc.
    }
}

