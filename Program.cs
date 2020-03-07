using System;

namespace battle_ships {
    class Program
    {
        static void Main()
        {
            var player1 = new Ocean();
            var player2 = new Ocean();
            var newGame = new Game(player1, player2);
            newGame.MainMenu();

        }


    }
}
