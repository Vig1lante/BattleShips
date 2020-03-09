using System;
using System.Collections.Generic;
using System.Text;
//test game
namespace battle_ships
{
    class Game
    {
        public enum Player { PLAYER_ONE, PLAYER_TWO, COMPUTER };
        private Player CurrentPlayer;
        private Ocean player1;
        private Ocean player2;
        private string coords;

        public Game(Ocean player1, Ocean player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public Ocean GetOppositePlayer(Player type, string playerone, string playertwo)
        {
            switch (type)
            {
                case Player.PLAYER_ONE:
                    CurrentPlayer = Player.PLAYER_TWO;
                    Console.WriteLine($"\nThe current player's turn: {playertwo}");
                    return player2;
                case Player.PLAYER_TWO:
                    CurrentPlayer = Player.PLAYER_ONE;
                    Console.WriteLine($"\nThe current player's turn: {playerone}");
                    return player1;
            }

            return null;
        }
        private Ocean GetOppositeComputer(Player type, string player)
        {
            switch (type)
            {
                case Player.PLAYER_ONE:
                    CurrentPlayer = Player.COMPUTER;
                    Console.WriteLine($"\nThe current player's turn: COMPUTER");
                    return player2;
                case Player.COMPUTER:
                    CurrentPlayer = Player.PLAYER_ONE;
                    Console.WriteLine($"\nThe current player's turn: {player}");
                    return player1;
            }

            return null;
        }

 
        private int[] GetCoords(string sampleCoords)
        {
            int finalX;
            int[] coordSet;

            if (sampleCoords == "q" || sampleCoords == "quit")
            {
                Console.WriteLine("See you next time!");
            }
            if (checkCoords(sampleCoords))
            {
                char coordy = Convert.ToChar(sampleCoords[0]);
                if (sampleCoords.Length == 3)
                {

                    finalX = Int32.Parse(sampleCoords[1].ToString() + sampleCoords[2].ToString()) - 1;
                }
                else { finalX = Int32.Parse(sampleCoords[1].ToString()) - 1; }
                int finalY = char.ToUpper(coordy) - 64 - 1;
                coordSet = new int[2] { finalX, finalY };
                return coordSet;
            }
            return null;
        }

        private string FinalCoords(string coords)
        {
            bool check = true;
            
            if (!checkCoords(coords))
            {
                while (check)
                {
                    string cords = Console.ReadLine();
                    if (checkCoords(cords)) { return cords; }
                }
            }
            return coords;
        }

        private bool CheckIfAToZ(string coords)
        {
            string validLetters = "abcdefghij";
            var formatFirstLetter = coords[0].ToString().ToLower();
            char firstLetter = char.Parse(formatFirstLetter);

            foreach (char c in validLetters)
            {
                if (firstLetter == c)
                {
                    return true;
                }
            }
            return false;
        }
        private bool checkCoords(string coords)
        {
            bool checkfirstindex = Char.IsLetter(coords, 0);
            bool checksecondindex = Char.IsNumber(coords, 1);
            if (!checkfirstindex)
            {
                Console.WriteLine("Not a letter!");
                return false;
            }
            if (coords.Length == 2)
            {
                if (!checksecondindex) { Console.WriteLine("Sorry, not a number for your second digit"); return false; }
                if (!CheckIfAToZ(coords)) { Console.WriteLine("Letter out of range!"); return false; }
            }
            else if (coords.Length == 3)
            {
                bool checkthirdindex = Char.IsNumber(coords, 2);
                if (!checksecondindex && !checkthirdindex) { Console.WriteLine("Sorry, not a number for your third digit"); return false; }
                int xySum = int.Parse(coords[1].ToString()) + int.Parse(coords[2].ToString());
                if (xySum > 10) { Console.WriteLine("Number out of board range!"); return false; }
            }
            else if (coords.Length > 3)
            {
                Console.WriteLine("Your coordinates are screwed, check their length!");
                return false;
            }
                return true;
        }

        public void MainMenu()
        {
            Console.WriteLine("WELCOME TO THE BATTLESHIP GAME!");
            Console.WriteLine("ENJOY YOUR STAY AND MAY THE BEST ONE WIN!\n\n");
            Console.WriteLine("Main Menu\n1.Player vs Player\n2.Player vs Computer\n3.Quit");
            Console.Write("Enter option: ");
            bool game = true;
            while (game)
            {
                string decision = Console.ReadLine();
                switch (decision)
                {
                    case "1":
                        Console.WriteLine("PVP HERE");
                        game = false;
                        PlayerPlayer();
                        break;
                    case "2":
                        Console.WriteLine("Work in progress!");
                        PlayerComputer();
                        continue;
                    case "3":
                        break;
                    default:
                        Console.Write("Please re-enter your choice: ");
                        continue;
                }
                break;
            }
        }
        public bool PlayerPlayer()
        {
            Ocean currentlyAttacked; int x; int y; var p1 = player1; var p2 = player2;
            CurrentPlayer = Player.PLAYER_ONE;
            Console.WriteLine("Player One, please enter your name: ");
            string p1Name = Console.ReadLine();
            Console.WriteLine("Player Two, please enter your name: ");
            string p2Name = Console.ReadLine();

            bool flag = true;
            while (flag)
            {

                currentlyAttacked = GetOppositePlayer(CurrentPlayer, p1Name, p2Name);
                Console.WriteLine("Current Ocean");
                currentlyAttacked.DebugOcean();
                Console.WriteLine("Type in your coords -- !! LETTER FIRST, THEN NUMBER (EG. 'A2') !!");
                Console.WriteLine("You can also write 'q' or 'quit' to exit the game");
                string coords = Console.ReadLine();
                var finalXY = FinalCoords(coords);
                x = GetCoords(finalXY)[0];
                y = GetCoords(finalXY)[1];
                currentlyAttacked.MarkHit(x, y);
                if (currentlyAttacked.Board[x, y].Back.Equals(Square.Mark.HIT))
                {
                    currentlyAttacked.DebugOcean();
                    currentlyAttacked = GetOppositePlayer(CurrentPlayer, p1Name, p2Name);
                }
                new SunkManager(p1).SunkHammer();
                new SunkManager(p2).SunkHammer();
                if (currentlyAttacked.ForWin() == true)
                {
                    Console.WriteLine("You win! GZ!");
                    return true;
                }
                currentlyAttacked.DebugOcean();
                Console.WriteLine("\n\nEND OF ROUND");
            }
            return false;
        }
        public bool PlayerComputer()
        {
            Ocean currentlyAttacked; int x; int y; var p1 = player1; var p2 = player2;
            var computer = new Computer(player2);
            CurrentPlayer = Player.COMPUTER;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine("Player One, please enter your name: ");
            string p1Name = Console.ReadLine();

            bool flag = true;
            while (flag)
            {

                currentlyAttacked = GetOppositeComputer(CurrentPlayer, p1Name);
                Console.WriteLine("Current Ocean");
                currentlyAttacked.DebugOcean();
                Console.WriteLine("Type in your coords -- !! LETTER FIRST, THEN NUMBER (EG. 'A2') !!");
                Console.WriteLine("You can also write 'q' or 'quit' to exit the game");

                if (currentlyAttacked == player1)
                {

                    string coords = Console.ReadLine();
                    var finalXY = FinalCoords(coords);
                    x = GetCoords(finalXY)[0];
                    y = GetCoords(finalXY)[1];
                    currentlyAttacked.MarkHit(x, y);
                    if (currentlyAttacked.Board[x, y].Back.Equals(Square.Mark.HIT))
                    {
                        currentlyAttacked.DebugOcean();
                        currentlyAttacked = GetOppositeComputer(CurrentPlayer, p1Name);
                    }
                }
                if (currentlyAttacked == player2){ computer.CompAttack(); }
                new SunkManager(p1).SunkHammer();
                new SunkManager(p2).SunkHammer();
                if (currentlyAttacked.ForWin() == true)
                {
                    Console.WriteLine("You win! GZ!");
                    flag = false;
                }
                currentlyAttacked.DebugOcean();

                Console.WriteLine("\n\nEND OF ROUND");
            }
            return false;
        }

    }
}