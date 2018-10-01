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

                case "go east":
                    Go("east");
                    break;

                case "go west":
                    Go("west");
                    break;

                case "start":
                    Go("start");
                    break;

                case "blue":
                    System.Console.WriteLine("You walk over to the lonely girl in the corner, she looks so sad as if she has been made fun of by the rest of the kids at your party.  You hold out your hand.  She's amazed that you would chose hers first, over your crush, your best friend, even your mother.  She hands you a book with mysterious writing within it.  You don't know what it is for, but you know that somehow, someway it could help you escape this strange dream.  ");
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
            var startingRoom = new Room("startroom", "You awake to find yourself laying on the floor of a mysterious white room.  Although it's a place you've never been to before you immediately recognize it as a room you've dreamt about since you were young.  Not only do you recognize the room, but you remember that someway your 'dream' version of yourself was able to escape.  Although you only vaguely remember the details.  You close your eyes to see a blurry siloutte of yourself squinting at a compass you found on the ground.  It reads 'N S e W'.  Small letters have always been hard for you to see.");


            var partyRoom = new Room("keyroom", "Stepping in to the next room you now see yourself as a child at your own birthday party.  You see your mother holding a GREEN gift in her hand.  Your friends surround you with presents.  Your best friend out of them all holds a RED gift in his hand, begging you to open his first.  However your childhood crush suddenly yells 'No, open mine!'  You are tempted by the WHITE gift held in thier hand.  You try to think back to what gift was chosen when you remember, a young shy girl sitting in the corner, seperated from everyone held a BLUE present within her hands.  You say to yourself 'I remember this.  I this is the year I was given a GAME, a pair of ROLLER skates, a WATERGUN and a BOOK.  <i>You remember your favorite gift was the book, but you can't remember's who gift it was...</i>");



            var swordRoom = new Room("swordroom", "A sword catches your eye");
            var lockRoom = new Room("lockroom", "A rusty lock.");
            var finalRoom = new Room("finalroom", "The end is in sight.");

            var book = new Item("book", "A book written in a mysterious language.");
            var sword = new Item("sword", "a beautiful sword.");

            startingRoom.Exits.Add("start", partyRoom);
            partyRoom.Exits.Add("west", startingRoom);
            partyRoom.Exits.Add("blue", lockRoom);
            lockRoom.Exits.Add("west", partyRoom);
            lockRoom.Exits.Add("east", swordRoom);
            swordRoom.Exits.Add("west", lockRoom);
            swordRoom.Exits.Add("east", finalRoom);
            finalRoom.Exits.Add("west", swordRoom);

            partyRoom.Items.Add(book);
            swordRoom.Items.Add(sword);

            CurrentRoom = startingRoom;

        }

        public void StartGame()
        {
            Setup();
            System.Console.WriteLine("Welcome to Château Dejavu!  Enter 'start' to begin!.");
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