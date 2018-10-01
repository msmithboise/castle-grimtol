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

                case "go east":
                    Go("east");
                    break;

                case "go west":
                    Go("west");
                    break;



                case "blue":



                    System.Console.WriteLine("You walk over to the lonely girl in the corner, she looks so sad as if she has been made fun of by the rest of the kids at your party.  You hold out your hand.  She's amazed that you would chose hers first, over your crush, your best friend, even your mother.  She hands you a book with mysterious writing within it.  You don't know what it is for, but you know that somehow, someway it could help you escape this strange dream.  She holds it out to you waiting for you to TAKE it.  ");
                    break;


                case "white":
                    System.Console.WriteLine("Although the watergun was a fun toy to play with as a kid, I don't see how this will be helpful in the future.");
                    break;

                case "red":
                    System.Console.WriteLine("Yeah I remember those rollerskates.  They were so much fun!  Though I don't think they can help me escape this strange dream.");
                    break;

                case "green":
                    System.Console.WriteLine("That was a fun game.  But I don't think it will help me escape this place.");
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

                case "repeat":
                    Repeat();
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

            if (CurrentRoom == deathRoom)
            {
                alive = false;

            }


            var book = new Item("book", "A book written in a mysterious language.");
            var sword = new Item("sword", "a beautiful sword.");


            deathRoom.Exits.Add("east", startingRoom);
            startingRoom.Exits.Add("west", deathRoom);
            partyRoom.Exits.Add("west", startingRoom);
            partyRoom.Exits.Add("north", lockRoom);
            lockRoom.Exits.Add("west", partyRoom);
            lockRoom.Exits.Add("east", swordRoom);
            swordRoom.Exits.Add("west", lockRoom);



            partyRoom.Items.Add(book);
            swordRoom.Items.Add(sword);

            CurrentRoom = startingRoom;

        }

        public void StartGame()
        {
            System.Console.WriteLine($"{CurrentRoom.Description}");
            Setup();

            while (PlayingGame)
            {


                GetUserInput();


            }

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