using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships
{
	class Ocean
	{	
		// Add new random object for future pseudo-number generation.
		private Random random = new Random();

		// Create a 10x10 array of "Square" type
		private Square[,] Board = new Square[10, 10];

		// Define custom ocean constructor for filling the "Board". 
		// Adds instances of Square type in each iteration.
		public Ocean()
		{
			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
				{
					Board[x, y] = new Square();
				}
			}
		}
		// Draw ocean in console with different square types in board array taken from the Square class.
		public void DebugOcean()
		{
			Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
			for (int x = 0; x < 10; x++)
			{
				if (x < 9)
				{
					Console.Write(" " + (x + 1) + "|");
				}
				else
				{
					Console.Write((x + 1) + "|");
				}
				for (int y = 0; y < 10; y++)
				{
				// Take x, y index from board and draw square type for that index.
					Console.Write(Board[x, y].Draw() + "|");
				}
				Console.WriteLine("");
			}

		}

		public bool DebugPutRandomlyShip(Square.Mark type)
		{
			bool vertical = false;
			int starty, endy, startx, endx, initx, inity, initsize;
			if (random.Next(2) == 1)
			{
				vertical = true;
			};
			// Set random int values for x, y coordinates.
			int x = random.Next(10);
			int y = random.Next(10);

			initx = x;
			inity = y;

			int size = Square.GetOccupiedSquares(type);
			initsize = size;

			if (vertical && initx + initsize > 9) return false;
			if (!vertical && inity + initsize > 9) return false;

			// Check edge cases for horizontal x = row, y = col
			if (!vertical)
			{
				starty = inity;
				endy = starty + initsize;
				startx = initx;
				endx = startx;

				if (initx > 0) startx -= 1;
				if (initx < 9) endx = initx + 1;
				if (inity > 0) starty -= 1;
				if (endy < 9) endy += 1;


				for (int cx = startx; cx <= endx; cx++)
				{
					for (int cy = starty; cy <= endy; cy++)
					{
						if (!Board[cx, cy].IsAvailable()) return false;
					}
				}
			}
			else
			// Check edge cases for vertical x = row, y = col
			{
				startx = initx;
				endx = initx + size;
				starty = inity;
				endy = starty;

				if (inity > 0) starty -= 1;
				if (inity < 9) endy += 1;
				if (initx > 0) startx = initx - 1;
				if (initx + size < 9) endx += 1;

				for (int cx = startx; cx <= endx; cx++)
				{
					for (int cy = starty; cy <= endy; cy++)
					{
						if (!Board[cx, cy].IsAvailable()) return false;
					}
				}
			}
			if (vertical)
			{
				for (int cx = initx; cx < initx + size; cx++)
				{
					Board[cx, inity].SetMark(type);
				}
			}
			else
			{
				for (int cy = inity; cy < inity + size; cy++)
				{
					Board[initx, cy].SetMark(type);
				}
			}
			return true;
		}
		public bool CheckHit(int posx, int posy, Ocean playerOcean)
		{
			// convert posx/posy na int32

			if (playerOcean.Board[posx, posy].isShip())
			{
				return true;
			}
			return false;
		}

		public void MarkHit(int posx, int posy, Ocean playerOcean)
		{
			if (!playerOcean.Board[posx, posy].Back.Equals(Square.Mark.HIT))
			{
				if (CheckHit(posx, posy, playerOcean)){ playerOcean.Board[posx, posy].SetMark(Square.Mark.HIT); }
				else { playerOcean.Board[posx, posy].SetMark(Square.Mark.MISSED); }		
			}
			playerOcean.Board[posx, posy].setVisible();
		}

		//public void SetToSunk(Ocean playerOcean)
		//// Check all squares around X, if only X, miss and ocean present then sink
		//{
		//	for (int x = 0; x < 10; x++)
		//	{
		//		for (int y = 0; y < 10; y++)
		//		{
		//			// Check square outside board edges
		//			if (playerOcean.Board[x, y].Back.Equals(Square.Mark.HIT)) {
		//				if ((x < 10 && playerOcean.Board[x + 1, y].isMiscSymbol()) &&
		//					(x > 0 && playerOcean.Board[x - 1, y].isMiscSymbol()) &&
		//					(y < 10 && playerOcean.Board[x, y + 1].isMiscSymbol()) &&
		//					(y > 0 && playerOcean.Board[x, y - 1].isMiscSymbol()))
		//				{
		//					playerOcean.Board[x, y].SetMark(Square.Mark.SUNK);
		//				}
		//				// Check edge cases
		//				else if ()
		//			}
		//		}
		//	}
			
		//}
	}
}

