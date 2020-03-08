using System;

namespace battle_ships {
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var player1 = new Ocean();
            var player2 = new Ocean();
            var newGame = new Game(player1, player2);
            newGame.MainMenu();

        }


    }
}
