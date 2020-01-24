using UnityEngine;

public class mock : MonoBehaviour
{
    /**
     * So, in order to remove the Mock, we need a few other things.
     * - We need players data so we can instantiate inventory correctly passing the Inventory ID.
     * With it we can get PlayerId and InventoryId
     * I think we can have Player Data table in an SQL Database and Items table in a Mongo Database
     * - We need a UI HUD so we can see the visual representation of our Inventory and interact with it.
     * - We need that the Interaction uses the Inventory to Pick Up Items.
     */

    void Start()
    {
        CharacterInventory inventory;
        
        inventory = gameObject.GetComponent<CharacterInventory>();

        inventory.UseStoredItem(0);
    }
}
