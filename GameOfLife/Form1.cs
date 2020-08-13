using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        //Most variables will go below here that are used throughout the program

        // The universe array
        bool[,] universe = new bool[20, 20];
        bool[,] scratchPad = new bool[20, 20];

        bool isToroidal = true;

        // Drawing colors
        Color gridColor = Color.DarkBlue;
        Color cellColor = Color.OrangeRed;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        #region Next Generation
        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int count;

                    if (isToroidal == false)
                    {
                        count = CountNeighborsFinite(x, y);
                    }
                    else if (true)
                    {
                        count = CountNeighborsToroidal(x, y);
                    }


                    //Apply rules
                    if (universe[x, y]) //Read the universe
                    {
                        if (count == 2 || count == 3){scratchPad[x, y] = true;}
                        else{scratchPad[x, y] = false;}
                    }
                    else
                    {
                        if (count == 3){scratchPad[x, y] = true;}
                        else{scratchPad[x, y] = false;}
                    }
                }
                graphicsPanel1.Invalidate();
            }
            //Copy scratchpad to universe
            bool[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        #endregion

        #region Finite
        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0) { continue; }
                    if (xCheck < 0) { continue; }
                    if (yCheck < 0) { continue; }
                    if (xCheck >= xLen) { continue; }
                    if (yCheck >= yLen) { continue; }
                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            graphicsPanel1.Invalidate();

            return count;
        }

        #endregion

        #region Torodial
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0) continue;
                    if (xCheck < 0) xCheck += xLen - 1;
                    if (yCheck < 0) yCheck += yLen - 1;
                    if (xCheck >= xLen) xCheck = 0;
                    if (yCheck >= yLen) yCheck = 0;
                    if (universe[xCheck, yCheck] == true) count++;
                }
            }

            return count;
        }

        #endregion

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        #region GraphicsPanel1_Paint
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        #endregion

        #region GraphicsPanel1_MouseClick
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        #endregion

        #region exit,new
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }

        #endregion

        #region Play,Pause,Next
        private void toolStripButton1_Play(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void toolStripButton2_Pause(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void toolStripButton3_Next(object sender, EventArgs e)
        {
            NextGeneration();
        }

        #endregion

        private void fromSeedToolStripMenuItem_ClickRandomSeed(object sender, EventArgs e)
        {
            //Initial Random Universe – One requirement of the assignment will be to 
            //generate a random universe of cells. Start this by iterating through the 
            //universe array using two nested for loops.As we visit each cell generate 
            //a random number between 0 and 2 inclusive.If the random number's 
            //value is 0 then make that cell alive, otherwise make it dead. After 
            //this is completed the initial universe should be composed of 
            //roughly 1/3 living cells and 2/3 dead cells. Later on you can play around 
            //with the actual percentage of living to dead cells and see how that affects
            //the game.
        }


        private void finiteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                     CountNeighborsFinite(x, y);
                }
            }
        }

        private void torToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    CountNeighborsToroidal(x, y);
                }
            }
        }

        #region Color Dialog boxes
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if(DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();

        }
        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        #endregion

        private void gridX10ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor x 10 = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }
    }
}
