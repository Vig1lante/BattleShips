using System;

namespace battle_ships {
    class Program
    {
        static void Main(string[] args)
        {

            var TestOcean = new Ocean();

            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.CARRIER));
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.BATTLESHIP)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.SUBMARINE)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.CRUISER)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.DESTROYER)) ;

            TestOcean.DebugOcean();
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
                TestOcean.MarkHit(posX, posY, TestOcean);
                TestOcean.DebugOcean();

            }

        }
    }
}
