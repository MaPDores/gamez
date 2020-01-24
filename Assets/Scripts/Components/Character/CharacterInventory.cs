using UnityEngine;

[RequireComponent(typeof(EquipmentComponent))]
public class CharacterInventory : InventoryComponent
{
    private EquipmentComponent equipment;

    public void Start()
    {
        equipment = gameObject.GetComponent<EquipmentComponent>();
    }

    public void UseStoredItem(int index)
    {
        Item item = Items[index];
        if (item == null)
        {   return;  }

        switch (item.type)
        {
            case ItemType.Weapon:
            case ItemType.Head:
            case ItemType.Torso:
            case ItemType.Legs:
            case ItemType.Boots:
                equipment.Equip(item);
                break;
            case ItemType.Consumable:
                // Apply/Consume
                break;
        }
    }

}
