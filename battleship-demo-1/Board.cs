using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace battleship_demo_1
{
    public class Board
    {
        private const int size = 10;
        public List<List<CellState>> Matrix { get; private set; }
        public Board()
        {
            Matrix = new List<List<CellState>>();

            for (int r = 0; r < 10; r++)
            {
                var row = new List<CellState>();
                for (int c = 0; c < size; c++)
                {
                    row.Add(CellState.Empty);
                }
                Matrix.Add(row);
            }
        }

        public void Print(bool hidden = false)
        {
            char colCharA = 'A';
            char colCharB = 'B';
            char colCharC = 'C';
            char colCharD = 'D';
            char colCharE = 'E';
            char colCharF = 'F';
            char colCharG = 'G';
            char colCharH = 'H';
            char colCharI = 'I';
            char colCharJ = 'J';


            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|||| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |10 |");
            Console.WriteLine("-------------------------------------------|");
            for (int r = 0; r < size; r++)
            {
                switch (r)
                {
                    case 0:
                        Console.Write($" {colCharA} |");
                        break;
                    case 1:
                        Console.Write($" {colCharB} |");
                        break;
                    case 2:
                        Console.Write($" {colCharC} |");
                        break;
                    case 3:
                        Console.Write($" {colCharD} |");
                        break;
                    case 4:
                        Console.Write($" {colCharE} |");
                        break;
                    case 5:
                        Console.Write($" {colCharF} |");
                        break;
                    case 6:
                        Console.Write($" {colCharG} |");
                        break;
                    case 7:
                        Console.Write($" {colCharH} |");
                        break;
                    case 8:
                        Console.Write($" {colCharI} |");
                        break;
                    case 9:
                        Console.Write($" {colCharJ} |");
                        break;
                    default:
                        break;
                }

                if (hidden == true)
                {
                    for (int c = 0; c < size; c++)
                    {
                        switch (Matrix[r][c])
                        {
                            case CellState.Empty:
                                Console.Write(" ~ |");
                                break;
                            case CellState.Hit:
                                Console.Write(" * |");
                                break;
                            case CellState.Ship:
                                Console.Write(" ~ |");
                                break;
                            case CellState.Miss:
                                Console.Write(" ! |");
                                break;
                        }
                    }
                } else
                {
                    for (int c = 0; c < size; c++)
                    {
                        switch (Matrix[r][c])
                        {
                            case CellState.Empty:
                                Console.Write(" ~ |");
                                break;
                            case CellState.Ship:
                                Console.Write(" $ |");
                                break;
                            case CellState.Hit:
                                Console.Write(" * |");
                                break;
                            case CellState.Miss:
                                Console.Write(" ! |");
                                break;
                        }
                    }
                }                
                Console.WriteLine();
            }


            Console.WriteLine("--------------------------------------------");

        }

        public bool PlaceShip(Ship ship, int r1, int c1, int r2, int c2)
        {

            // horizontal 
            if (r1 == r2)
            {
                // side to side
                int start = Math.Min(c1, c2);
                int end = Math.Max(c1, c2);

                for (int i = start; i <= end; i++)
                {
                    if (Matrix[r1][i] != CellState.Empty)
                    {
                        return false;
                    }
                }

                for (int i = start; i <= end; i++)
                {
                    Matrix[r1][i] = CellState.Ship;
                }

                return true;
            }

            // verticle
            if (c1 == c2)
            {
                // up and down
                int start = Math.Min(r1, r2);
                int end = Math.Max(r1, r2);

                for (int i = start; i <= end; i++)
                {
                    if (Matrix[i][c1] != CellState.Empty)
                    {
                        return false;
                    }
                }

                for (int i = start; i <= end; i++)
                {
                    Matrix[i][c1] = CellState.Ship;
                }

                return true;
            }

            return false;
        }


        public void Fire(int row, int col)
        {
            switch (Matrix[row][col])
            {
                case CellState.Ship:
                    Matrix[row][col] = CellState.Hit;
                    Console.WriteLine("\nHit!");
                    break;
                case CellState.Empty:
                    Matrix[row][col] = CellState.Miss;
                    Console.WriteLine("\nMiss!");
                    break;
                default:
                    Console.WriteLine("\nAlready fired here!");
                    break;  
            }
        }
    }
}
