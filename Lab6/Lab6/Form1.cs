using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //dimensions
        private const float clientSize = 100;
        private const float lineLength = 80;
        private const float block = lineLength / 3;
        private const float offset = 10;
        private const float delta = 5;

        private enum CellSelection { N, O, X };
        private CellSelection[,] grid = new CellSelection[3, 3];

        private float scale;

        //game engine
        gEd0 gE = new gEd0();
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);
            //draw board
            g.DrawLine(Pens.Black, block, 0, block, lineLength);
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, lineLength);
            g.DrawLine(Pens.Black, 0, block, lineLength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, lineLength, 2 * block);
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    if (grid[i, j] == CellSelection.O) DrawO(i, j, g);
                    else if (grid[i, j] == CellSelection.X) DrawX(i, j,
                    g);
        }

        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientSize,
            ClientRectangle.Height / clientSize);
            if (scale == 0f) return;
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }
        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta,
            (i * block) + block - delta, (j * block) + block - delta);
            g.DrawLine(Pens.Black, (i * block) + block - delta,
            j * block + delta, (i * block) + delta, (j * block) + block - delta);
        }
        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * block + delta, j * block + delta,
            block - 2 * delta, block - 2 * delta);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //disable the computer moves first menu option
            compStarts.Enabled = false;

            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, p);
            if (p[0].X < 0 || p[0].Y < 0) return;
            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);
            if (i > 2 || j > 2) return;

            //only allow setting empty cells
            short spot = (short)(i + 3 * j);
            if( e.Button == MouseButtons.Left )
            {
                //is the move legal?
                bool isLegal = gE.isLegal((short)(i + 3 * j));
                if (isLegal)
                {
                    //add the spot to the board
                    gE.addOpMove(spot);
                    grid[i, j] = CellSelection.X;
                    //is it a winning move?
                    if( gE.isWin() )
                    {
                        Invalidate();
                        MessageBox.Show("Congradulations, you win!");
                        return;
                    }
                    //is the game over after this move?
                    else if (gE.isOver())
                    {
                        Invalidate();
                        MessageBox.Show("Game Over");
                        return;
                    }
                }
                else
                {
                    //not a legal move
                    MessageBox.Show("That move is not legal!");
                    return;
                }
            }
            Invalidate();
            //now its the computer's turn
            CompMove();
        }

        private void CompMove()
        {
            //Game engine makes its move
            short compMove = gE.Move();
            //unpack the move
            int i = compMove % 3;
            int j = (compMove - i) / 3;
            grid[i, j] = CellSelection.O;
            Invalidate();
            //is it a winning move?
            if (gE.isWin())
            {
                MessageBox.Show("Whoops, you lost. Good game.");
            }
            //is the game over?
            else if (gE.isOver())
            {
                MessageBox.Show("Game Over");
            }
            return;
        }

        private void compStarts_Click(object sender, EventArgs e)
        {
            //computer makes a move first
            CompMove();

            //disable the button afterwards
            compStarts.Enabled = false;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            //start a new game
            //clear the board
            for( short i = 0; i < 3; i++ )
            {
                for( short j = 0; j < 3; j++ )
                {
                    grid[i, j] = CellSelection.N;
                }
            }

            //restart the game engine
            gE.restart();

            //enable the computer moves first menu opt
            compStarts.Enabled = true;

            //invalidate
            Invalidate();
        }
    }
}
