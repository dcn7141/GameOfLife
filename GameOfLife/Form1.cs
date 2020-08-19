using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        //Most variables will go below here that are used throughout the program

        // The universe array
        bool[,] universe = new bool[20,20];
        bool[,] scratchPad = new bool[20,20];

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

            //read settings
           graphicsPanel1.BackColor =  Properties.Settings.Default.BackColor;

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


        #region Finite and Toroidal tab selections
        private void finiteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            isToroidal = false;
        }

        private void torToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            isToroidal = true;
        }
        #endregion


        #region Settings: Color Dialog boxes
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

        #region Settings: options
        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModalDialog dlg = new ModalDialog();

            dlg.numericUpDown1_ValueChanged = timer.Interval;

           if (DialogResult.OK == dlg.ShowDialog())
            {
                timer.Interval = dlg.numericUpDown1_ValueChanged;

                graphicsPanel1.Invalidate();
            }

            // universe = new bool[5,5];
            ////scratchPad = new bool[,];

            //dlg.numericUpDown2_ValueChanged = universe.Length;

            //if (DialogResult.OK == dlg.ShowDialog())
            //{
            //    isToroidal = true;
            //    //= dlg.numericUpDown2_ValueChanged;

            //    graphicsPanel1.Invalidate();
            //}

            //dlg.numericUpDown3_ValueChanged = universe.Length;

            //if (DialogResult.OK == dlg.ShowDialog())
            //{
            //    universe.SetValue = dlg.numericUpDown3_ValueChanged;

            //    graphicsPanel1.Invalidate();
            //}

        }
        #endregion

        #region Reset/Reload

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor;
        }
        #endregion

        #region Seeds
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedDialog dlg = new SeedDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                //Where do i get the seed. how to change?

                graphicsPanel1.Invalidate();
            }

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

        #endregion

        #region View menu
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ///////
        }
        #endregion

        #region Open and Save
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row.Contains == '!')
                    {
                        
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.

                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        // If row[xPos] is a 'O' (capital O) then
                        // set the corresponding cell in the universe to alive.

                        // If row[xPos] is a '.' (period) then
                        // set the corresponding cell in the universe to dead.
                    }
                }
                // Close the file.
                reader.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creat a boolean that indicates the document has been modified.
            //creat a string that stores the path to the current document.

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.

                writer.WriteLine("Save work.");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.Length; y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.Length; x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                            Console.WriteLine(currentRow);
                        }

                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else
                        {
                            currentRow += '.';
                            Console.WriteLine(currentRow);
                        }
                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    currentRow = Console.ReadLine();
                    Console.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.BackColor = graphicsPanel1.BackColor;

            Properties.Settings.Default.Save();
        }
    }
}
