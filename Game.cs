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

        //method for player vs player ()
        //method for select player
        public Game(Ocean player1, Ocean player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public Ocean GetOppositePlayer(Player type)
        {
            switch(type)
            {
                case Player.PLAYER_ONE:
                    CurrentPlayer = Player.PLAYER_TWO;
                    return player2;

                case Player.PLAYER_TWO:
                    CurrentPlayer = Player.PLAYER_ONE;
                    return player1;
            }
            
            return null;
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
                        Console.WriteLine("WIP");
                        //PlayerComputer();
                        game = false;
                        break;
                    case "3":
                        break;
                    default:
                        Console.Write("Please re-enter your choice: ");
                        continue;
                }
                break;
            }
        }

        //public string PrintName(string name1, string name2)
        //{
        //    if (player1)
        //    {
        //        return name1;
        //    }
        //    return name2;
        //}

        public bool PlayerPlayer()
        {
            Ocean currentlyAttacked; int posX; var p1 = player1; var p2 = player2;
            CurrentPlayer = Player.PLAYER_ONE;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            Console.WriteLine("Player One, please enter your name: ");
            string p1Name = Console.ReadLine();

            Console.WriteLine("Player Two, please enter your name: ");
            string p2Name = Console.ReadLine();


            bool flag = true;
            while (flag)
            {

                currentlyAttacked = GetOppositePlayer(CurrentPlayer);
                Console.WriteLine("Current Ocean");
                currentlyAttacked.DebugOcean();
                Console.WriteLine("Type in your coords -- !! LETTER FIRST, THEN NUMBER (EG. 'A2') !!");
                Console.WriteLine("You can also write 'q' or 'quit' to exit the game");

                string sampleCoords = Console.ReadLine();
                if (sampleCoords == "q" || sampleCoords == "quit")
                {
                    flag = false;
                    Console.WriteLine("See you next time!");
                    continue;
                }
                char y = Convert.ToChar(sampleCoords[0]);
                if (sampleCoords.Length == 3)
                {

                    posX = Int32.Parse(sampleCoords[1].ToString() + sampleCoords[2].ToString()) - 1;
                }
                else { posX = Int32.Parse(sampleCoords[1].ToString()) - 1; }
                int posY = char.ToUpper(y) - 64 - 1;
                currentlyAttacked.MarkHit(posX, posY);
                if (currentlyAttacked.Board[posX, posY].Back.Equals(Square.Mark.HIT))
                {
                    currentlyAttacked.DebugOcean();
                    currentlyAttacked = GetOppositePlayer(CurrentPlayer);
                }
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

            //int PlayerComputer()
            //          {
            //              int posX;

            //              Console.BackgroundColor = ConsoleColor.Black;
            //              Console.ForegroundColor = ConsoleColor.DarkBlue;

            //              Console.WriteLine("WELCOME TO THE BATTLESHIP GAME!");
            //              Console.WriteLine("ENJOY YOUR STAY AND MAY THE BEST ONE WIN!\n\n");
            //              var playerOne = new Ocean();
            //              var playerTwo = new Ocean();
            //              var computer = new Computer(testOcean);

            //              Console.WriteLine("PLAYER OCEAN");
            //              testOcean.DebugOcean();
            //              Console.WriteLine("\n");
            //              Console.WriteLine("COMPUTER OCEAN");
            //              computerOcean.DebugOcean();

            //              bool flag = true;
            //              while (flag)
            //              {
            //                  Console.BackgroundColor = ConsoleColor.Black;
            //                  Console.ForegroundColor = ConsoleColor.DarkBlue;
            //                  //Console.ForegroundColor = ConsoleColor.DarkCyan;
            //                  Console.WriteLine("Type in your coords -- !! LETTER FIRST, THEN NUMBER (EG. 'A2') !!");

            //                  string sampleCoords = Console.ReadLine();
            //                  if (sampleCoords == "q" || sampleCoords == "quit")
            //                  {
            //                      flag = false;
            //                      Console.WriteLine("See you next time!");
            //                      continue;
            //                  }
            //                  //var numbers = sampleCoords.Split(',');
            //                  //int[] myInts = Array.ConvertAll(numbers, int.Parse);
            //                  char y = Convert.ToChar(sampleCoords[0]);
            //                  if (sampleCoords.Length == 3)
            //                  {

            //                      posX = Int32.Parse(sampleCoords[1].ToString() + sampleCoords[2].ToString()) - 1;
            //                  }
            //                  else { posX = Int32.Parse(sampleCoords[1].ToString()) - 1; }
            //                  int posY = char.ToUpper(y) - 64 - 1;
            //                  computerOcean.MarkHit(posX, posY);
            //                  computer.CompAttack();
            //                  new SunkManager(computerOcean).SunkHammer();
            //                  new SunkManager(testOcean).SunkHammer();
            //                  Console.WriteLine("PLAYER OCEAN");
            //                  testOcean.DebugOcean();
            //                  Console.WriteLine("\n");
            //                  Console.WriteLine("COMPUTER OCEAN");

            //                  computerOcean.DebugOcean();
            //                  if (testOcean.ForWin() == true)
            //                  {
            //                      Console.WriteLine("You win! GZ!");
            //                      flag = false;
            //                  }
            //                  Console.ResetColor();
            //                  Console.WriteLine("\n\nEND OF ROUND");
            //              }
            //            }
        

