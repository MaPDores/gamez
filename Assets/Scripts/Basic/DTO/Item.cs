using static System.Guid;
using System.Collections.Generic;
using Newtonsoft.Json;

public enum ItemType { Weapon, Head, Torso, Legs, Boots, Consumable, Default }
public class Item
{
    #region Data

    // The ID in the Database, to only have sync items
    public string id;


    // The index of the prefab in the list of Instantiatables
    public int prefabId;

    // The type of the item, it defines what happens when you use the item and where should it go
    public ItemType type;


    // The title of the item, player could define that on item creation
    public string title;


    // The description of the item, player could define that on item creation
    public string description;


    // Apply Status feature is a little complicated... because have different behaviors, depending on Item type
    // But the dictionary doesn't know that, it just know it's effects.
    // 
    // Status to apply:
    //  - If it's a Weapon: Apply to Bullet/Blade (bullet/blade can cause Fire Damage when touches the enemy)
    //  - If it's a consumable: Apply to Consumer (if poison, apply poison hurt, if damage, hit the amount, etc)
    //  - If it's an Armor: Apply to Effects (it's the most confusing, but you apply the status in opposite to
    // status being applied on the Armored User, like if using armor, all "Apply" calls above passes through a
    // list of Debuffs to Counter it's stats, like a status fight or something kkk. Example: 
    //       - Helmet has FireProtection = 3
    //       - Torso has FireProtection = 4
    //       - Player receive a Shot with FireDamage = 8*
    //       - Shot call Player's Apply script*
    //       - FireDamage - Helmet:FireProtection = 5
    //       - FireDamage - Torso:FireProtection = 1
    //       - Player takes 1 FireDamage
    public Dictionary<string, int> status;

    #endregion

    // Constructor used to Create New Items
    public Item(int prefabId, string title, string description, ItemType type, Dictionary<string, int> status)
    {
        id = NewGuid().ToString("B").ToUpper();
        this.prefabId = prefabId;
        this.title = title;
        this.description = description;
        this.type = type;
        this.status = status;
    }

    #region Json Handlers
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static Item FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Item>(json);
    }
    #endregion
}
