using System;
using System.Drawing;
using System.Collections;

public class gameEngine
{
    //data fields
    private ArrayList taken;
    private ArrayList free;

    //function members
    public gameEngine()
	{
        Console.WriteLine("Starting Game Engine");
        taken = new ArrayList();

        //initialize the list of free spots
        free = new ArrayList();
        for( short i = 0; i < 9; i++ )
        {
            free.Add(i);
        }
    }

    public void add( short spot )
    {
        //add the move to the board
        Console.WriteLine("you clicked on spot number " + spot.ToString() );
        
        //is the move legal ?
        if( isLegal(spot) )
        {
            //mark the spot as taken
            this.taken.Add(spot);
            this.free.Remove(spot);
        }
    }

    public bool isLegal(short spot)
    {
        //detect is a spot that was just clicked was a legal move,
        foreach (short i in free)
        {
            if (i == spot)
            {
                return true;
            }
        }
        return false;
    }

    public bool isOver()
    {
        //checks if the game is over
        Console.WriteLine("items in free: {0}", free.Count);
        if( free.Count == 0 )
        {
            return true;
        }
        return false;
    }

    public void restart()
    {
        //restart the gameEngine
        Console.WriteLine("Restarting game engine");
        taken.Clear();
        free.Clear();
        for( short i = 0; i < 9; i++ )
        {
            free.Add(i);
        }
    }

    public short Move()
    {
        Random r = new Random();
        short spot = (short)free[r.Next(free.Count)];
        this.free.Remove(spot);
        this.taken.Remove(spot);
        Console.WriteLine("selected spot No.{0}", spot);
        return spot;
    }

}
