using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Inventory
{

    /// <summary>
    /// Инвентарь существа
    /// </summary>
    public class CreatureInventory : MonoBehaviour
    {

        [SerializeField] private List<InventoryCell> _inventory = new List<InventoryCell>();
        public List<InventoryCell> Inventory { get=> _inventory; }
    }
}
