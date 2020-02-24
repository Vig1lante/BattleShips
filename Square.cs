using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ships {
    class Square {
    	private Square.Mark Front;
	private Square.Mark Back;
	public enum Mark {CARRIER, BATTLESHIP, CRUISER,  SUBMARINE, DESTROYER, WATER, MISSED, HIT, NOT_SET, SUNK}
	public void setVisible(){
		this.Front = this.Back;
	}
	public void SetMark(Square.Mark value){
		this.Back = value;
	}
	public bool IsAvailable(){
		return this.Back == Mark.NOT_SET;
	}
	/*
	public bool IsVisible(){
		return this.Visible;
	}*/
	public Square(){
		this.Front = Mark.WATER;
		this.Back = Mark.NOT_SET;
	}
	public char Draw(){
		switch(this.Back){
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
	public static int GetOccupiedSquares(Square.Mark type){
		switch(type){
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
