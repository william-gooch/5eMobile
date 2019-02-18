using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Item
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }

        public Item(string name, string description, string notes)
        {
            Name = name;
            Description = description;
            Notes = notes;
        }
    }
}
