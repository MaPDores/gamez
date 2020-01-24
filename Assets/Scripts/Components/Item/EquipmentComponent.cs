using UnityEngine;

public class EquipmentComponent : MonoBehaviour
{
    #region Weapon
    
    private GameObject weapon;

    private Item weaponItem;
    
    [SerializeField]
    private Instantiatable weaponPrefabList;
    [SerializeField]
    private Transform weaponAnchor;
    
    #endregion

    public void Equip(Item equipment)
    {
        switch(equipment.type)
        {
            case ItemType.Weapon:
                SetWeapon(equipment);
                break;

            case ItemType.Head:
                SetHead(equipment);
                break;

            case ItemType.Torso:
                SetTorso(equipment);
                break;

            case ItemType.Legs:
                SetLegs(equipment);
                break;

            case ItemType.Boots:
                SetBoots(equipment);
                break;
        }
    }


    private void SetWeapon(Item equipment)
    {
        if (weapon != null)
        {
            Destroy(weapon);
        }
        
        // PlayerStats.Free(weapon.status);
        
        weaponItem = equipment;

        // PlayerStats.Apply(equipment.status);
        // PlayerStats.Recalculate(this?);

        GameObject prefab = weaponPrefabList.GetPrefab(equipment.prefabId);
        if (prefab != null)
        {
            weapon = Instantiate(prefab, weaponAnchor.position, weaponAnchor.rotation, weaponAnchor);
        }
    }

    private void SetHead(Item equipment) { }
        
    private void SetTorso(Item equipment) { }

    private void SetLegs(Item equipment) { }

    private void SetBoots(Item equipment) { }
}
