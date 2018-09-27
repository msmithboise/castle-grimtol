using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }



        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Room ChangeRooms(string direction)
        {
            if (Exits.ContainsKey(direction))
            {
                // returning a variable on an object (dictionaries are objects)requires brackets.
                return Exits[direction];
            }
            return this;
        }

        public Item RemoveItem(string itemName)
        {
            // get index then call RemoveAt
            Item foundItem = Items.Find(itm => itm.Name == itemName);
            if (foundItem != null)
            {
                //remove from items
                Items.Remove(foundItem);
                return foundItem;
            }
            return null;

        }


    }
}