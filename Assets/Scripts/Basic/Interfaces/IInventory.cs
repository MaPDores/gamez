using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IInventory
    {
        List<Item> Items { get; }

        void Init();

        void AddItem(Item item);

        void RemoveItem(string id); 
    }
}
