using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public CharacterStats stats;
    public CharacterMovement characterMovement;
    public CharacterCombat characterCombat;
    public CharacterInventory characterInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        stats = GetComponent<CharacterStats>();
        characterMovement = GetComponent<CharacterMovement>();
        characterCombat = GetComponent<CharacterCombat>();
        characterInventory = GetComponent<CharacterInventory>();
        if (stats == null || characterMovement == null || characterCombat == null || characterInventory == null)
        {
            Debug.LogError($"{characterName} is missing required components!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
