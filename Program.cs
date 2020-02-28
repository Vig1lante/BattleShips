using System;

namespace battle_ships {
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.Write("Podaj swoje imie? ");
            string Play = Console.ReadLine();
            Console.WriteLine("Witaj " +  Play + " To tablica dla Ciebie!");
     
            
		
		    var TestOcean = new Ocean();
            while(!TestOcean.DebugPutRandomlyShip(Square.Mark.CARRIER));
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.BATTLESHIP)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.SUBMARINE)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.CRUISER)) ;
            while (!TestOcean.DebugPutRandomlyShip(Square.Mark.DESTROYER)) ;



            TestOcean.DebugOcean();

            TestOcean.ForWin(TestOcean);

        }
          
    }
}
