using System;
using System.Drawing;

public class gameEngine
{
    //data fields
    private int[] board = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    //function members
    public gameEngine()
	{
       
    }

    public void whatIs()
    {
        Console.WriteLine("This is a game engine");
    }

    public void add( short spot )
    {
        Console.WriteLine("you clicked on spot number " + spot.ToString() );
        //add the move to the board
        this.board[spot] = 1;
        foreach( int i in board )
        {
            Console.Write(i.ToString());
        }
        Console.WriteLine();
    }

    public bool isLegal( short spot )
    {
        //detect is a spot that was just clicked was a legal move
        if( this.board[spot] )
        {
            Console.WriteLine("That was a not a legal move");
            return false;
        }
        Console.WriteLine("That was a legal move");
        return true;
        
    }
}
