using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class LootComponent : MonoBehaviour, IInteractable
{
    // REMOVER
    private Item item = new Item(1, "Basic apple", "A MAAAAAAAAAAAAAAAAAATHER F@CKEN APPLE", ItemType.Consumable, new Dictionary<string, int> { { "heal", 4 } });
    // REMOVER

    public string Title { get => item.title; }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void Interact(GameObject interactor)
    {
        IInventory inventory = interactor.GetComponent<IInventory>();
        if (inventory != null && item != null)
        {
            inventory.AddItem(item);
        }
        
        Destroy(gameObject);
    }
}
