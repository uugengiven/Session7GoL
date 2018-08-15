using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoLSession7
{
    public partial class Form1 : Form
    {
        public GameOfLife blake;
        public int sizeOfGrid = 300;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blake = new GameOfLife();
            blake.Setup(sizeOfGrid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(sizeOfGrid, sizeOfGrid);
            // print
            for (int row = 0; row < sizeOfGrid; row++)
            {
                for (int col = 0; col < sizeOfGrid; col++)
                {
                    // don't do console write, do something else
                    if(blake.grid[row, col] == blake.aliveCell)
                    {
                        ((Bitmap)pictureBox1.Image).SetPixel(row, col, Color.White);
                    }
                    else
                    {
                        ((Bitmap)pictureBox1.Image).SetPixel(row, col, Color.Black);
                    }
                }
            }
            // go to next gen
            blake.NextGen();
        }
    }
}
