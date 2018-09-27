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
                return Exits[direction];
            }
            return this;
        }

    }
}