using System;

namespace battle_ships {
    class Program
    {
        static void Main()
        {

            int posX;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("WELCOME TO THE BATTLESHIP GAME!");
            Console.WriteLine("ENJOY YOUR STAY AND MAY THE BEST ONE WIN!\n\n");
            var testOcean = new Ocean();

            while (!testOcean.DebugPutRandomlyShip(Square.Mark.CARRIER)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.BATTLESHIP)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.SUBMARINE)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.CRUISER)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.DESTROYER)) ;

            testOcean.DebugOcean();
            bool flag = true;
            while (flag)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                //Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Type in your coords -- !! LETTER FIRST, THEN NUMBER (EG. 'A2') !!");

                string sampleCoords = Console.ReadLine();
                if (sampleCoords == "q" || sampleCoords == "quit")
                {
                    flag = false;
                    Console.WriteLine("See you next time!");
                    continue;
                }
                //var numbers = sampleCoords.Split(',');
                //int[] myInts = Array.ConvertAll(numbers, int.Parse);
                char y = Convert.ToChar(sampleCoords[0]);
                if (sampleCoords.Length == 3)
                {
                    posX = Int32.Parse(sampleCoords[1].ToString() + sampleCoords[2].ToString()) - 1;
                }
                else { posX = Int32.Parse(sampleCoords[1].ToString()) - 1; }
                int posY = char.ToUpper(y) - 65;
                testOcean.MarkHit(posX, posY, testOcean);
                new SunkManager(testOcean).SunkHammer();
                testOcean.DebugOcean();
                if (testOcean.ForWin(testOcean) == true)
                {
                    Console.WriteLine("You win! GZ!");
                    flag = false;
                }
                Console.ResetColor();
            }
        }
          
    }
}
