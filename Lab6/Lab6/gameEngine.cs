using System;
using System.Drawing;
using System.Collections;

public class gameEngine
{
    //data fields
    protected ArrayList taken; //contains taken spaces
    protected ArrayList free;  //contains free spaces
    protected short opmoves;   //contains oponents moves encoded as a binary number, 9 bit
    protected short mymoves;   //contains the engine's moves as a binary number, 9 bit

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

        opmoves = 0;
    }

    public void addOpMove( short spot )
    {
        //add the move to the board
        Console.WriteLine("you clicked on spot number " + spot.ToString() );
        
        //is the move legal ?
        if( isLegal(spot) )
        {
            
            //mark the spot as taken
            this.taken.Add(spot);
            this.free.Remove(spot);

            //modify the opmoves
            opmoves = (short)(opmoves | (1 << spot));
            Console.WriteLine("opmoves: " + opmoves.ToString());
            bool b = isWin();
            Console.WriteLine("Is win: " + b.ToString());
        }
    }

    public void addMyMove( short spot )
    {
        //mark the spot as taken
        this.taken.Add(spot);
        this.free.Remove(spot);

        //modify mymoves
        mymoves = (short)(mymoves | (1 << spot));
        Console.WriteLine("mymoves: " + mymoves.ToString());
        bool b = isWin();
        Console.WriteLine("Is win: " + b.ToString());
        return;
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
        opmoves = 0;
        mymoves = 0;
    }

    public bool isWin()
    {
        //checks if the latest move was a win
        //check opmoves first
        bool win = false;
        if ((opmoves & 73) == 73)
        {
            //this is the first collumn
            Console.WriteLine("first collumn is a win");
            win = true;
        }
        else if ((opmoves & 146) == 146)
        {
            Console.WriteLine("second collumn is a win");
            win = true;
        }
        else if((opmoves & 292) == 292)
        {
            Console.WriteLine("thrid collumn is a win");
            win = true;
        }
        else if((opmoves & 7) == 7 )
        {
            Console.WriteLine("First row is a win");
            win = true;
        }
        else if((opmoves & 56) == 56 )
        {
            Console.WriteLine("second row is a win");
            win = true; ;
        }
        else if((opmoves & 448) == 448 )
        {
            Console.WriteLine("third row is a win");
            win = true;
        }
        else if((opmoves & 273) == 273 )
        {
            Console.WriteLine("backslash is a win");
            win = true;
        }
        else if((opmoves & 84) == 84 )
        {
            Console.WriteLine("frontslash is a win");
            win = true;
        }
        //then my moves
        else if ((mymoves & 73) == 73)
        {
            //this is the first collumn
            Console.WriteLine("first collumn is a win");
            win = true;
        }
        else if ((mymoves & 146) == 146)
        {
            Console.WriteLine("second collumn is a win");
            win = true;
        }
        else if ((mymoves & 292) == 292)
        {
            Console.WriteLine("thrid collumn is a win");
            win = true;
        }
        else if ((mymoves & 7) == 7)
        {
            Console.WriteLine("First row is a win");
            win = true;
        }
        else if ((mymoves & 56) == 56)
        {
            Console.WriteLine("second row is a win");
            win = true; ;
        }
        else if ((mymoves & 448) == 448)
        {
            Console.WriteLine("third row is a win");
            win = true;
        }
        else if ((mymoves & 273) == 273)
        {
            Console.WriteLine("backslash is a win");
            win = true;
        }
        else if ((mymoves & 84) == 84)
        {
            Console.WriteLine("frontslash is a win");
            win = true;
        }
        return win;
    }

    public bool isWin(short s)
    {
        //checks if the latest move was a win
        bool win = false;
        if ((s & 73) == 73)
        {
            //this is the first collumn
            Console.WriteLine("first collumn is a win");
            win = true;
        }
        else if ((s & 146) == 146)
        {
            Console.WriteLine("second collumn is a win");
            win = true;
        }
        else if ((s & 292) == 292)
        {
            Console.WriteLine("thrid collumn is a win");
            win = true;
        }
        else if ((s & 7) == 7)
        {
            Console.WriteLine("First row is a win");
            win = true;
        }
        else if ((s & 56) == 56)
        {
            Console.WriteLine("second row is a win");
            win = true; ;
        }
        else if ((s & 448) == 448)
        {
            Console.WriteLine("third row is a win");
            win = true;
        }
        else if ((s & 273) == 273)
        {
            Console.WriteLine("backslash is a win");
            win = true;
        }
        else if ((s & 84) == 84)
        {
            Console.WriteLine("frontslash is a win");
            win = true;
        }
        return win;
    }

    public ArrayList getWinMoves()
    {
        ArrayList moves = new ArrayList();
        short current;

        foreach( short s in free )
        {
            //look through the free spaces and find the winning moves
            current = (short)(opmoves | (1 << s));
            if( isWin( current ) )
            {
                moves.Add(s);
            }
        }

        return moves;
    }

    public ArrayList getMyWinMoves()
    {
        ArrayList moves = new ArrayList();
        short current;

        foreach (short s in free)
        {
            //look through the free spaces and find the winning moves
            current = (short)(mymoves | (1 << s));
            if (isWin(current))
            {
                moves.Add(s);
            }
        }

        return moves;
    }

    virtual public short Move()
    {
        return 0;
    }

}

public class gEd0 : gameEngine
{
    //most basic move logic
    //makes moves randomly but tries to stop winning moves
    public gEd0()
    {
        Console.WriteLine("Creating game engine on 0 difficulty");
    }

    override public short Move()
    {
        //look for winning moves
        Console.Write("Winning Moves: ");
        ArrayList a = getWinMoves();
        ArrayList b = getMyWinMoves();
        int alen = a.Count;
        int blen = b.Count;
        short spot = 0;
        //is the oponent in the position of making any winning moves?
        if (alen == 0)
        {
            //no winning moves detected, pick a random spot that is free
            Console.WriteLine("No winning move detected, picking a random spot");
            Random r = new Random();
            spot = (short)free[r.Next(free.Count)];
            addMyMove(spot);
            Console.WriteLine("selected spot No.{0}", spot);
        }
        //the opoenet can make winning moves
        else if (alen != 0)
        {
            spot = (short)a[0];
            addMyMove(spot);
            Console.WriteLine("Found spot<{0}>. moving to block", spot);
        }
        //the game engine is in a position to make a winning move
        else if (blen != 0)
        {
            spot = (short)a[0];
            addMyMove(spot);
            Console.WriteLine("I can win with spot<{0}>. moving to win", spot);
        }
        return spot;
    }
}
