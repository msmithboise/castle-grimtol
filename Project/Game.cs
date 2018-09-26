using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {

        }

        public void Go(string direction)
        {

        }

        public void Help()
        {

        }

        public void Inventory()
        {

        }

        public void Look()
        {

        }

        public void Quit()
        {

        }

        public void Reset()
        {

        }

        public void Setup()
        {
            var keyRoom = new Room("keyroom", "You see a glisten on the floor.");
            var swordRoom = new Room("swordroom", "A sword catches your eye");
            var lockRoom = new Room("lockroom", "A rusty lock.");
            var finalRoom = new Room("finalroom", "The end is in sight.");

            var roomKey = new Item("roomkey", "a shiny key");
            var sword = new Item("sword", "a beautiful sword.");

            keyRoom.Exits.Add("east", swordRoom);
            swordRoom.Exits.Add("east", lockRoom);
            swordRoom.Exits.Add("west", keyRoom);
            lockRoom.Exits.Add("east", finalRoom);
            lockRoom.Exits.Add("west", swordRoom);



        }

        public void StartGame()
        {
            System.Console.WriteLine("You find yourself in a room you've never seen before.  What do you do next?");
        }

        public void TakeItem(string itemName)
        {

        }

        public void UseItem(string itemName)
        {

        }


        public Game(Room currentroom, Player currentplayer)
        {
            CurrentRoom = currentroom;
            CurrentPlayer = currentplayer;

        }


    }
}