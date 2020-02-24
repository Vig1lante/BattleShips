using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    class Ocean {
    	private Random random = new Random();
	private Square[,] Board = new Square[10,10];
	public Ocean(){
		for(int x = 0; x<10; x++){
			for(int y = 0; y<10; y++){
				Board[x,y] = new Square();
			}
		}
	}
	public void DebugOcean(){
		
		Console.WriteLine("  |A|B|C|D|E|F|G|H|I|J|");
		for(int y = 0; y < 10; y++){
			if(y<9){
				Console.Write(" "+(y+1)+"|");
			} else {
				Console.Write((y+1)+"|");
			}
			for (int x = 0; x < 10; x++){
				Console.Write(Board[x,y].Draw()+"|");
			}
			Console.WriteLine("");
		}
	}
	public bool DebugPutRandomlyShip(Square.Mark type){
		bool horizontal = false;
		int starty, endy, startx, endx, initx, inity, initsize;
		if(random.Next(2)==1){
		  horizontal = true;
		};
		int x = random.Next(10);
		int y = random.Next(10);
		initx = x;
		inity = y;
		int size = Square.GetOccupiedSquares(type);
		initsize = size;
		
		if(horizontal && initx+initsize>9) return false;
		if(!horizontal && inity+initsize>9) return false;
		
		if(horizontal){
			//rysujemy na "wysokosci" x wzdluz y (po kazdym y)
			starty = endy = inity;
			startx = endx = initx;
			if(initx>0) startx = initx - 1;
			if(initx+size<9) endx = initx + size + 1;
			if(inity>0) starty = inity-1;
			if(inity<9) endy = inity+1;
			for(int cy = starty; cy < endy; cy++){
				for(int cx = startx; cx < endx; cx++){
					if(!Board[cx, cy].IsAvailable()) return false;			
				}
			}
		} else {
			//rysujemy na "wysokosci" y wzdluz x (po kazdym x)
			startx = endx = initx;
			starty = endy = inity;
			if(inity>0) starty = starty - 1;
			if(inity+size<9) endy = inity + size + 1;
			if(initx>0) startx = initx-1;
			if(initx<9) endx = initx+1;
			for(int cx = startx; cx<endx; cx++){
				for(int cy = starty; cy<endy; cy++){
					if(!Board[cx, cy].IsAvailable()) return false;
				}	
			}
		}
		if(horizontal){
			for(int cx = initx; cx<initsize+initx; cx++){
				Board[cx, inity].SetMark(type);
			}
		} else {
			for(int cy = inity; cy<initsize+inity; cy++){
				Board[initx, cy].SetMark(type);
			}
		}
		return true;
	}
    }
}
