using UnityEngine;

public class Weapon : Item
{
    public int damage;
    private CharacterCombat characterCombat;
    private GameObject player;

    private void Start()
    {
       characterCombat = player.GetComponent<CharacterCombat>();
    }
}
