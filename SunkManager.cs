using System;
using System.Collections.Generic;

namespace battle_ships
{
    class SunkManager
    {
        private Ocean ocean;

        public SunkManager(Ocean ocean)
        {
            this.ocean = ocean;
        }

		public void SunkHammer()
        {
			int row = ocean.Board.GetLength(0); 
			int col = ocean.Board.GetLength(1);

			for (int x = 0; x < row; x++)
			{
				for (int y = 0; y < col; y++)
				{
					if (ocean.Board[x, y].Back.Equals(Square.Mark.HIT))
					{
						// hitCalc
						var coordsToSink = SinkingNeeded(x, y);
						if (coordsToSink!=null)
						{
							SinkCoords(coordsToSink);
						}

					}
					
				}
			}
        }

		private void SinkCoords(List<int[]> coordsToSink)
		{
			foreach(int[] coords in coordsToSink){
				ocean.Board[coords[0], coords[1]].SetMark(Square.Mark.SUNK);
				ocean.Board[coords[0], coords[1]].SetVisible();
			}
		}
		private List<int[]> SinkingNeeded(int x, int y)
		{
			List<int[]> coordsList= new List<int[]>();
			if ((x != 0 && ocean.Board[x - 1, y].Back == Square.Mark.HIT) || // onlly first point of a ship should be considered
				 (y != 0 && ocean.Board[x, y - 1].Back == Square.Mark.HIT)){
				return null;
			}
			while (SurroundedByMisc(x, y))
			{
				int[] currentCords = new int[] { x, y };
				coordsList.Add(currentCords);
				int[] coords = GetNeigbourHitCords(x, y);
				if (coords == null)
				{
					//break;
					return coordsList;
				}
				x = coords[0];
				y = coords[1];
			} 
			return null;
		}
		private int[] GetNeigbourHitCords(int x, int y)
		{
			if (x < 9 && ocean.Board[x + 1, y].Back == Square.Mark.HIT)
			{
				return new int[] { x + 1, y };
			} else if (y < 9 && ocean.Board[x, y + 1].Back == Square.Mark.HIT)
			{
				return new int[] { x, y +1};
			}
			// get x and y of next point(ONLY the point that goes further, don't look back
			return null;
		}
		private bool SurroundedByMisc(int x, int y)
		{
			if ((x < 9 && ocean.Board[x + 1, y].IsMiscSymbol()) &&
				   (x == 0 || ocean.Board[x - 1, y].IsMiscSymbol()) &&
				   (y < 9 && ocean.Board[x, y + 1].IsMiscSymbol()) &&
				   (y == 0 || ocean.Board[x, y - 1].IsMiscSymbol()))
			{
				return true;
			}
			return false;
		}
	}
}