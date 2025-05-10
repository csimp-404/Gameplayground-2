using UnityEngine;

public abstract class Weapon : Item
{
    public float damage;
    public abstract void Attack();
    public virtual void Equip(CharacterAttack player) { }
    public virtual void Unequip() { }
}
