using System;
using System.Collections.Generic;
using System.Text;


namespace battle_ships
{
    class Computer
    {
        private Ocean ocean;
        private Random getNum = new Random();
        public Computer(Ocean ocean) => this.ocean = ocean;

        // GLOWNA metoda zwraca koordy do ataku
        public int[] CompAttack()
        {
            int[] calculatedCoords = GetCompCoords();
            int x = calculatedCoords[0];
            int y = calculatedCoords[1];
            ocean.MarkHit(x, y);
            return calculatedCoords;
        }
        private int[] GetCompCoords()
        {
            int boardSize = ocean.Board.GetLength(0);

            int[] rawCoords = null;
            // tu by sprawdzalo czy nie trafilismy w # lub sink lub juz miss
            do {
                rawCoords = new int[] { getNum.Next(boardSize), getNum.Next(boardSize) };
            } while (CoordsAreBad(rawCoords));

            return rawCoords;
        }

        private bool CoordsAreBad(int[] rawCoords)
        {
            var cordsSquare = ocean.Board[rawCoords[0], rawCoords[1]].Back;
            if (Square.Mark.MISSED.Equals(cordsSquare) ||
                Square.Mark.HIT.Equals(cordsSquare) || 
                Square.Mark.SUNK.Equals(cordsSquare) 
                )
            {
                return true;
            }
            return false;
        }
    }
}
