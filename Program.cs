using System;

namespace battle_ships {
    class Program
    {
        static void Main(string[] args)
        {
            var testOcean = new Ocean();

            while (!testOcean.DebugPutRandomlyShip(Square.Mark.CARRIER));
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.BATTLESHIP)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.SUBMARINE)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.CRUISER)) ;
            while (!testOcean.DebugPutRandomlyShip(Square.Mark.DESTROYER)) ;

            testOcean.DebugOcean();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Type in your coords");
                string sampleCoords = Console.ReadLine();
                if (sampleCoords == "q")
                {
                    break;
                }

                var numbers = sampleCoords.Split(',');
                int[] myInts = Array.ConvertAll(numbers, int.Parse);
                int posX = myInts[0], posY = myInts[1];
                testOcean.MarkHit(posX, posY, testOcean);
                new SunkManager(testOcean).SunkHammer();
                testOcean.DebugOcean();
                if (testOcean.ForWin(testOcean) == true)
                {
                    Console.WriteLine("You win! GZ!");
                    flag = false;
                }
                
            }

        }
    }
}
