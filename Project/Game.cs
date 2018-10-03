using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public bool PlayingGame { get; set; } = true;

        public bool WinGame { get; set; } = false;

        public bool alive { get; set; } = true;
        public bool hasKey { get; set; }

        public Game()
        {
            System.Console.Write("Name? ");
            CurrentPlayer = new Player(Console.ReadLine());
            StartGame();
        }




        public void GetUserInput()
        {
            var userInput = Console.ReadLine();
            string[] inputArr = userInput.Split(' ');
            string command = inputArr[0];
            string option = "";
            if (inputArr.Length > 1)
            {
                option = inputArr[1];
            }


            switch (command.ToLower())
            {
                case "go":
                    if (option.Length > 0)
                    {
                        Go(option);
                    }
                    else
                    {
                        System.Console.WriteLine("please provide a direction");
                    }
                    break;
                case "help":
                    Help();
                    break;

                case "look":
                    Look();
                    break;

                case "take":
                    // you don't pass data types in arguments, only parameters.  TakeItem requires an arguement.
                    if (option.Length > 0)
                    {
                        TakeItem(option);
                    }
                    else
                    {
                        System.Console.WriteLine("please provide an item name to take");
                    }
                    break;

                case "use":
                    // you don't pass data types in arguments, only parameters.  TakeItem requires an arguement.
                    if (option.Length > 0)
                    {
                        UseItem(option);
                    }
                    else
                    {
                        System.Console.WriteLine("please provide an item name to use");
                    }
                    break;

                case "quit":
                    Quit();
                    break;

                case "repeat":
                    Repeat();
                    break;

                case "inventory":
                    Inventory();
                    break;

                default:
                    System.Console.WriteLine("Unrecognized command");
                    break;





            }
        }




        public void Go(string direction)
        {
            if (CurrentRoom.Name == "lockroom" && direction == "east" && !hasKey)
            {
                System.Console.WriteLine("THAT DOOR IS LOCKED YOU NEED THE KEY!");
                return;
            }
            CurrentRoom = CurrentRoom.ChangeRooms(direction);
            System.Console.WriteLine($"{CurrentRoom.Description}");
        }

        public void Help()
        {

            Console.Clear();
            System.Console.WriteLine("HELP MENU");
            System.Console.WriteLine("----------");

            System.Console.WriteLine("'Go North'");
            System.Console.WriteLine("'Go South'");
            System.Console.WriteLine("'Go East'");
            System.Console.WriteLine("'Go West'");

            System.Console.WriteLine("'Look' - To read the description again.");
            System.Console.WriteLine("'Take' - To take an item, that is if there is one...");
            System.Console.WriteLine("'Use' - To use an item found.");
            System.Console.WriteLine("'Inventory' - To see a list of aquired items");
            System.Console.WriteLine("'Quit' - to quit the game.");
            System.Console.WriteLine("'Repeat' - to hear room description again.");
            System.Console.WriteLine("'Back' - exit help menu");

            var userInput = Console.ReadLine();

            if (userInput == "back")
            {
                Console.Clear();
                System.Console.WriteLine($"{CurrentRoom.Description}");
            }







        }

        public void Inventory()
        {
            System.Console.WriteLine("YOUR INVENTORY: ");
            if (CurrentPlayer.Inventory.Count == 0)
            {
                System.Console.WriteLine("Nothing here");
            }
            foreach (var item in CurrentPlayer.Inventory)
            {
                System.Console.WriteLine($"{item.Name} - {item.Description}");
            }
        }

        public void Look()
        {
            Console.Clear();
            System.Console.WriteLine($"{CurrentRoom.Explore}");
        }

        public void Quit()
        {

            System.Console.WriteLine("Are you sure you want to quit?  (Y/N)");
            string response = Console.ReadLine();
            if (response.ToUpper() != "N")
            {
                PlayingGame = false;
                Console.Clear();
            }
            else
            {
                System.Console.WriteLine("Hang in there!  You got this!");
            }
        }

        public void Repeat()
        {
            System.Console.WriteLine($"{CurrentRoom.Description}");
        }

        public void isAlive()
        {
            if (alive == false)
            {
                System.Console.WriteLine("Game Over");
            }
        }

        public void Reset()
        {

        }

        public void Setup()
        {
            var startingRoom = new Room("startroom", "You awake to find yourself laying on the floor of a mysterious white room.  Although it's a place you've never been to before you immediately recognize it as a room you've dreamt about since you were young.  Not only do you recognize the room, but you remember that someway your 'dream' version of yourself was able to escape.  Although you only vaguely remember the details.", "You close your eyes to see a blurry siloutte of yourself squinting at a compass you found on the ground.  It reads 'N S e W'.  Small letters have always been hard for you to see.");


            var partyRoom = new Room("partyroom", "Stepping in to the next room you now see yourself as a child at your own birthday party.  You see your friends surrounding you with presents.  You watch yourself unwrap them and you laugh as you try to blow out the trick candles.  You laugh to yourself.. I remember those!  You notice that you are once again surrounded by 4 doors.  Odd, concidering your childhood house only had two...", "There's a clock with both the hour hand and minute hand stuck on 12.. but if I thought my party was at 4?.");

            var swordRoom = new Room("swordroom", "A sword catches your eye", "a sword");
            var lockRoom = new Room("lockroom", "A rusty lock.", "I need to unlock this.");
            var deathRoom = new Room("deathroom", "You have been caught in an infinite loop of time.  You feel yourself rapidly aging, in a blink of an eye you have become a million years old, and so have your organs...", "You made the wrong call.");

            var book = new Item("book", "A book written in a mysterious language.");
            var sword = new Item("sword", "a beautiful sword.");


            deathRoom.Exits.Add("east", startingRoom);
            startingRoom.Exits.Add("west", deathRoom);
            startingRoom.Exits.Add("east", partyRoom);
            partyRoom.Exits.Add("west", startingRoom);
            partyRoom.Exits.Add("north", lockRoom);
            lockRoom.Exits.Add("west", partyRoom);
            lockRoom.Exits.Add("east", swordRoom);
            swordRoom.Exits.Add("west", lockRoom);



            partyRoom.Items.Add(book);
            swordRoom.Items.Add(sword);

            CurrentRoom = startingRoom;
            System.Console.WriteLine($"{CurrentRoom.Description}");

        }

        public void StartGame()
        {
            Setup();

            while (PlayingGame)
            {
                GetUserInput();
                if (CurrentRoom.Name == "deathroom")
                {
                    System.Console.WriteLine("You die!");
                    PlayingGame = false;
                }

            }

        }

        public void TakeItem(string itemName)
        {
            Item foundItem = CurrentRoom.RemoveItem(itemName);
            //add found item to player inventory
            if (foundItem != null)
            {
                CurrentPlayer.Inventory.Add(foundItem);
                System.Console.WriteLine("You have taken the " + itemName);
                if (itemName == "sword")
                {
                    System.Console.WriteLine("You are now the king! YOU WIN!");
                    PlayingGame = false;
                }
            }
            else
            {
                System.Console.WriteLine("No such item");
            }
        }

        public void UseItem(string itemName)
        {
            if (itemName == "book" && CurrentRoom.Name == "lockroom")
            {
                System.Console.WriteLine("Somehow you can read the mysterious book and after a few moments a loud click and the door in front of you unlocks!");
                hasKey = true;
            }
        }


    }
}