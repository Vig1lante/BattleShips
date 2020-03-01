using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships{
	class Square {
		private Square.Mark Front;
		public Square.Mark Back;

		public enum Mark { CARRIER, BATTLESHIP, CRUISER, SUBMARINE, DESTROYER, WATER, MISSED, HIT, NOT_SET, SUNK }
		// Accept the value of back square for front square.
		public void SetVisible() => Front = Back;

		// Set the square type for ship type field.
		public void SetMark(Square.Mark value) => Back = value;
		

		// Check whether the field for back square is not occupied.	
		public bool IsAvailable() {
			return Back == Mark.NOT_SET;
		}

		public bool IsShip()
		{
			if (Back == Mark.BATTLESHIP ||
				Back == Mark.CARRIER ||
				Back == Mark.CRUISER ||
				Back == Mark.DESTROYER ||
				Back == Mark.SUBMARINE) {
				return true;
			}
			return false;
		}


		public static int ShipSizeSum()
		{
			int totalSum = 0;
			foreach(Mark item in Enum.GetValues(typeof(Mark)))
			{
				if (item == Mark.BATTLESHIP ||
					item == Mark.CARRIER ||
					item == Mark.CRUISER ||
					item == Mark.DESTROYER ||
					item == Mark.SUBMARINE) {
					totalSum += (int)item;
				}
			}
			return totalSum;
		}
		public bool IsMiscSymbol()
		{
			if (Back == Mark.MISSED ||
				Back == Mark.NOT_SET ||
				Back == Mark.HIT ||
				Back == Mark.SUNK)
			{
				return true;
			}

			_ = Back == Mark.HIT;
			_ = Back.Equals(Mark.HIT);
			return false;
		}
		public Square(){
			this.Front = Mark.WATER;
			this.Back = Mark.NOT_SET;
		}
		// Define method for enum ship type that returns ship-specific char.
		public char Draw() {
			switch (Back)
			{
				case Mark.CARRIER:
					return 'C';
				case Mark.BATTLESHIP:
					return 'b';
				case Mark.CRUISER:
					return 'c';
				case Mark.SUBMARINE:
					return 's';
				case Mark.DESTROYER:
					return 'd';
				case Mark.WATER:
					return '~';
				case Mark.HIT:
					return 'X';
				case Mark.MISSED:
					return 'o';
				case Mark.SUNK:
					return '#';
				case Mark.NOT_SET:
					break;
			}
			return ' ';
		}
		// Define method for the amount of squares occupied by ship type
		// Return adequate int value.
		public static int GetOccupiedSquares(Square.Mark type) {
			switch (type)
			{
				case Mark.CARRIER:
					return 5;
				case Mark.BATTLESHIP:
					return 4;
				case Mark.CRUISER:
					return 3;
				case Mark.SUBMARINE:
					return 3;
				case Mark.DESTROYER:
					return 2;
				case Mark.WATER:
					break;
				case Mark.MISSED:
					break;
				case Mark.HIT:
					break;
				case Mark.NOT_SET:
					break;
				case Mark.SUNK:
					break;
			}
			return -1;
		}

	}
}