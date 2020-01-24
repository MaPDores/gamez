using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class InventoryComponent : MonoBehaviour, IInventory
{
    // Add a default inventory if it's a Chest for example, using a range of items that
    // varies depending on the Difficulty or Rarity
    
    public List<Item> Items { get; private set; }


    public void Awake()
    {
        Init();
    }

    #region Item Handlers

    //Call the server to retrieve player's items and set hasInitialized to true
    public void Init()
    {
        Items = new List<Item>()
        {
            new Item(0, "Simple Peanut Butter", "A moTHerFUcKIN GUUUUUUUUUUUN", ItemType.Weapon, new Dictionary<string, int> {
                    { "damage", 3 },
                    //{ "fireDamage", 3 },
                }),
        };
    }

    public void AddItem(Item item)
    {
        // Database stuff
        Items.Add(item);
    }

    public void RemoveItem(string id)
    {
        // Database stuff
        int index = Items.FindIndex((x) => x.id == id);
        Items.RemoveAt(index);
    }

    #endregion
}
