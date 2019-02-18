using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Item;

namespace DnDEngine.Character
{
    class Inventory
    {
        private List<Item.Item> items;

        public Inventory()
        {
            items = new List<Item.Item>();
        }

        public void AddItem(Item.Item item)
        {
            items.Add(item);
        }

        public Item.Item GetItem(string name)
        {
            return items.Find((Item.Item item) => item.Name == name);
        }
    }
}
