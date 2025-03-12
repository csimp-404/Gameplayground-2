using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CharacterInventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        //Debug.Log($"{gameObject.name} picked up {newItem.itemName}");
    }
}