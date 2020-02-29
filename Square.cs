using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships{
	class Square {
		private Square.Mark Front;
		public Square.Mark Back;

		public enum Mark { CARRIER, BATTLESHIP, CRUISER, SUBMARINE, DESTROYER, WATER, MISSED, HIT, NOT_SET, SUNK }
		// Accept the value of back square for front square.
		public void setVisible() {
			this.Front = this.Back;
		}

		// Set the square type for ship type field.
		public void SetMark(Square.Mark value) {
			this.Back = value;
		}

		// Check whether the field for back square is not occupied.	
		public bool IsAvailable() {
			return this.Back == Mark.NOT_SET;
		}

		public bool isShip()
		{
			if (this.Back == Mark.BATTLESHIP ||
				this.Back == Mark.CARRIER ||
				this.Back == Mark.CRUISER ||
				this.Back == Mark.DESTROYER ||
				this.Back == Mark.SUBMARINE) {
				return true;
			}
			return false;
		}

		public bool isMiscSymbol()
		{
			if (this.Back == Mark.MISSED ||
				this.Back == Mark.NOT_SET ||
				this.Back == Mark.HIT ||
				this.Back == Mark.SUNK)
			{
				return true;
			}
			return false;
		}

		/*
		public bool IsVisible(){
			return this.Visible;
		}*/

		// Create a custom constructor for square class.
		public Square(){
			this.Front = Mark.WATER;
			this.Back = Mark.NOT_SET;
		}
		// Define method for enum ship type that returns ship-specific char.
		public char Draw() {
			switch (this.Back) {
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
			}
			return ' ';
		}
		// Define method for the amount of squares occupied by ship type
		// Return adequate int value.
		public static int GetOccupiedSquares(Square.Mark type) {
			switch (type) {
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
			}
			return -1;
		}
		
	}
}