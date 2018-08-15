using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoLSession7
{
    public class GameOfLife
    {
        public int[,] grid;
        public int sizeOfGrid;
        public int deadCell = 0;
        public int aliveCell = 1;

        public void Setup(int size)
        {
            sizeOfGrid = size;
            Random rnd = new Random();

            grid = new int[sizeOfGrid, sizeOfGrid];
            for (int i = 0; i < sizeOfGrid; i++)
            {
                for (int j = 0; j < sizeOfGrid; j++)
                {
                    // decide if it should be
                    // alive or dead and set it
                    if (rnd.Next(0, 9) < 3)
                    {
                        grid[i, j] = deadCell;
                    }
                    else
                    {
                        grid[i, j] = aliveCell;
                    }
                }
            }
        }

        public void NextGen()
        {
            // Apply rules to /grid/
            //   to make /newgrid/
            // create /newgrid/
            int[,] newgrid = new int[sizeOfGrid, sizeOfGrid];

            // count up living /neighbors/
            // for each individual cell
            for (int row = 0; row < sizeOfGrid; row++)
            {
                for (int col = 0; col < sizeOfGrid; col++)
                {
                    int neighbors = 0;

                    // check upper left first
                    if (row > 0 && col > 0)
                    {
                        if (grid[row - 1, col - 1] == aliveCell)
                        {
                            neighbors = neighbors + 1;
                        }
                    }

                    // check upper middle
                    if (row > 0)
                    {
                        if (grid[row - 1, col] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check upper right
                    if (row > 0 && col < sizeOfGrid - 1)
                    {
                        if (grid[row - 1, col + 1] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check middle right
                    if (col < sizeOfGrid - 1)
                    {
                        if (grid[row, col + 1] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check lower right
                    if (row < sizeOfGrid - 1 && col < sizeOfGrid - 1)
                    {
                        if (grid[row + 1, col + 1] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check lower middle
                    if (row < sizeOfGrid - 1)
                    {
                        if (grid[row + 1, col] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check lower left
                    if (row < sizeOfGrid - 1 && col > 0)
                    {
                        if (grid[row + 1, col - 1] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    // check middle left
                    if (col > 0)
                    {
                        if (grid[row, col - 1] == aliveCell)
                        {
                            neighbors += 1;
                        }
                    }

                    //if (neighbors > 0)
                    //{
                    //    Console.WriteLine($"{neighbors} found on {row},{col}!");
                    //}

                    // apply game of life rules
                    if (grid[row, col] == aliveCell)
                    {
                        if (neighbors == 2 || neighbors == 3)
                        {
                            newgrid[row, col] = aliveCell;
                        }
                        else if (neighbors < 2)
                        {
                            newgrid[row, col] = deadCell;
                        }
                        else if (neighbors > 3)
                        {
                            newgrid[row, col] = deadCell;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            newgrid[row, col] = aliveCell;
                        }
                    }


                }
            }

            // Copy /newgrid/ into /grid/
            grid = newgrid;
        }
    }
}
