using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Item;

namespace DnDEngine.Character
{
    class Inventory
    {
        private List<(Item.Item Item, int Quantity)> items;

        public Inventory()
        {
            items = new List<(Item.Item Item, int Quantity)>();
        }

        public void AddItem(Item.Item item, int quantity)
        {
            // If the item is already in the inventory, then don't add it again.
            // Just increase the quantity of the existing item in the list.
            if (ItemInInventory(item.Name))
            {
                int index = GetItemIndex(item.Name);
                items[index] = (items[index].Item, items[index].Quantity + quantity);
            }
            else
            {
                items.Add((item, quantity));
            }
        }

        public (Item.Item Item, int Quantity) GetItem(string name)
        {
            return items.Find(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }

        public int GetItemIndex(string name)
        {
            return items.FindIndex(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }

        public bool ItemInInventory(string name)
        {
            return items.Exists(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }
    }
}
