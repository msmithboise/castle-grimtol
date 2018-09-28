using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public bool PlayingGame { get; set; } = true;

        public bool alive { get; set; } = true;
        public Game(Room currentroom, Player currentplayer)
        {

            CurrentRoom = currentroom;
            CurrentPlayer = currentplayer;


        }




        public void GetUserInput()
        {
            var userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "go north":
                    Go("north");
                    break;

                case "go south":
                    Go("south");
                    break;

                case "east":
                    Go("east");
                    break;

                case "west":
                    Go("west");
                    break;

                case "help":
                    Help();
                    break;

                case "look":
                    Look();
                    break;

                case "take":
                    // you don't pass data types in arguments, only parameters.  TakeItem requires an arguement.
                    TakeItem("key");
                    break;

                case "quit":
                    Quit();
                    break;








            }
        }




        public void Go(string direction)
        {
            CurrentRoom = CurrentRoom.ChangeRooms(direction);
        }

        public void Help()
        {

            Console.Clear();
            System.Console.WriteLine("HELP MENU");
            System.Console.WriteLine("----------");

            System.Console.WriteLine("Go");
            System.Console.WriteLine("Look");
            System.Console.WriteLine("Take");
            System.Console.WriteLine("Use");
            System.Console.WriteLine("Inventory");
            System.Console.WriteLine("----------");

        }

        public void Inventory()
        {

        }

        public void Look()
        {
            System.Console.WriteLine($"{CurrentRoom.Description}");
        }

        public void Quit()
        {

            System.Console.WriteLine("Are you sure you want to quit?  (Y/N)");
            string response = Console.ReadLine();
            if (response.ToUpper() != "N")
            {
                PlayingGame = false;
            }
            else
            {
                System.Console.WriteLine("Hang in there!  You got this!");
            }
        }

        public void Reset()
        {

        }

        public void Setup()
        {
            var startingRoom = new Room("startroom", "This is where it all begins");
            var keyRoom = new Room("keyroom", "You see a glisten on the floor.");
            var swordRoom = new Room("swordroom", "A sword catches your eye");
            var lockRoom = new Room("lockroom", "A rusty lock.");
            var finalRoom = new Room("finalroom", "The end is in sight.");

            var roomKey = new Item("roomkey", "a shiny key");
            var sword = new Item("sword", "a beautiful sword.");

            startingRoom.Exits.Add("east", keyRoom);
            keyRoom.Exits.Add("west", startingRoom);
            keyRoom.Exits.Add("east", lockRoom);
            lockRoom.Exits.Add("west", keyRoom);
            lockRoom.Exits.Add("east", swordRoom);
            swordRoom.Exits.Add("west", lockRoom);
            swordRoom.Exits.Add("east", finalRoom);
            finalRoom.Exits.Add("west", swordRoom);

            keyRoom.Items.Add(roomKey);
            swordRoom.Items.Add(sword);

            CurrentRoom = startingRoom;

        }

        public void StartGame()
        {


            System.Console.WriteLine("You find yourself in a room you've never seen before.  What do you do next?");
            GetUserInput();

        }

        public void TakeItem(string itemName)
        {
            Item foundItem = CurrentRoom.RemoveItem(itemName);
            //add found item to player inventory

            CurrentPlayer.Inventory.Add(foundItem);

        }

        public void UseItem(string itemName)
        {

        }


        public Game()
        {
            Setup();

        }


    }
}