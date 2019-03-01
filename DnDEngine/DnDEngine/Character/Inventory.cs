using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Item;

namespace DnDEngine.Character
{
    /// <summary>
    /// Acts as a list of items to be carried by a character.
    /// It has a list of tuples of Items and their quantities.
    /// </summary>
    public class Inventory
    {
        private List<(Item.Item Item, int Quantity)> items;

        public Inventory()
        {
            items = new List<(Item.Item Item, int Quantity)>();
        }

        /// <summary>
        /// Adds an item, provided it is not already in the inventory.
        /// If it is already there, increase the quantity.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="quantity">The quantity of said item to add.</param>
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

        /// <summary>
        /// Gets an item with a given name.
        /// </summary>
        /// <param name="name">The name of the item to get.</param>
        /// <returns>A tuple with the item object and its quantity.</returns>
        public (Item.Item Item, int Quantity) GetItem(string name)
        {
            return items.Find(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }

        /// <summary>
        /// Gets the index of an item with a given name.
        /// </summary>
        /// <param name="name">The name of the item to get.</param>
        /// <returns>The index of the item in the list.</returns>
        public int GetItemIndex(string name)
        {
            return items.FindIndex(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }

        /// <summary>
        /// Checks if an item with a given name is in the list.
        /// </summary>
        /// <param name="name">The name of the item to search for.</param>
        /// <returns>True if the item is in the list, false otherwise.</returns>
        public bool ItemInInventory(string name)
        {
            return items.Exists(((Item.Item Item, int Quantity) tuple) => tuple.Item.Name == name);
        }
    }
}
