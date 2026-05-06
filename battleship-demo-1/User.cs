using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace battleship_demo_1
{
    public class User : Player
    {
        protected override bool PlaceShip(Ship ship)
        {
            char CharA = 'A';
            char CharB = 'B';
            char CharC = 'C';
            char CharD = 'D';
            char CharE = 'E';
            char CharF = 'F';
            char CharG = 'G';
            char CharH = 'H';
            char CharI = 'I';
            char CharJ = 'J';


            Board.Print();
            Console.WriteLine($"Place your {ship.Name} (size: {ship.Size})");

            while (true)
            {
                char row1, row2;
                int c1, c2;

                // ask row column
                do
                {
                    try
                    {
                        Console.Write("Enter row (A-J): ");
                        string input = Console.ReadLine().ToUpper();
                        row1 = Convert.ToChar(input);
                    }
                    catch
                    {
                        row1 = ' ';
                        Console.WriteLine("Invalid input. Enter a single letter A-J.");
                    }
                } while (row1 != 'A' && row1 != 'B' && row1 != 'C' && row1 != 'D' && row1 != 'E' && row1 != 'F' && row1 != 'G' && row1 != 'H' && row1 != 'I' && row1 != 'J');

                switch (row1)
                {
                    case 'A':
                        row1 = CharA;
                        break;
                    case 'B':
                        row1 = CharB;
                        break;
                    case 'C':
                        row1 = CharC;
                        break;
                    case 'D':
                        row1 = CharD;
                        break;
                    case 'E':
                        row1 = CharE;
                        break;
                    case 'F':
                        row1 = CharF;
                        break;
                    case 'G':
                        row1 = CharG;
                        break;
                    case 'H':
                        row1 = CharH;
                        break;
                    case 'I':
                        row1 = CharI;
                        break;
                    case 'J':
                        row1 = CharJ;
                        break;
                    default:
                        break;
                }

                int r1 = row1 - 65;


                do
                {
                    try
                    {
                        Console.Write("Enter column (1-10): ");
                        c1 = Convert.ToInt32(Console.ReadLine());
                        if (c1 < 1 || c1 > 10)
                            Console.WriteLine("Invalid input. Enter a number between 1-10.");
                    }
                    catch
                    {
                        c1 = 0;
                        Console.WriteLine("Invalid input. Enter a number between 1-10.");
                    }
                } while (c1 != 1 && c1 != 2 && c1 != 3 && c1 != 4 && c1 != 5 && c1 != 6 && c1 != 7 && c1 != 8 && c1 != 9 && c1 != 10);
                c1 -= 1;


                // ask user for second row column
                bool finalOption = false;
                bool option = true;
                int x = ship.Size;
                row2 = row1;
                int r2 = row2 - 65;
                c2 = c1;

                while (!finalOption)
                {
                    // check right
                    option = true;
                    x = ship.Size;
                    if (c1 + ship.Size - 1 < 10 && Board.Matrix[r1][c1] == CellState.Empty && finalOption != true)
                    {
                        for (int i = c1; i <= c1 + ship.Size - 1; i++)
                        {
                            if (Board.Matrix[r1][i] != CellState.Empty)
                            {
                                option = false;
                                break;
                            }
                        }

                        while (option)
                        {
                            Console.WriteLine($"Would you like to place your {ship.Name} on {row1}{c1 + ship.Size}? (y/n)");

                            string input = Console.ReadLine()?.Trim().ToLower();

                            if (input == "y")
                            {
                                option = false;
                                c2 = c1 + ship.Size - 1;
                                finalOption = true;
                                break;
                            }
                            else if (input == "n")
                            {
                                option = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                            option = true;
                            finalOption = false;
                        }
                    }


                    // check down
                    option = true;
                    x = ship.Size;
                    if (r1 + ship.Size - 1 < 10 && Board.Matrix[r1][c1] == CellState.Empty && finalOption != true)
                    {
                        for (int i = r1; i <= r1 + ship.Size - 1; i++)
                        {
                            if (Board.Matrix[i][c1] != CellState.Empty)
                            {
                                option = false;
                                break;
                            }
                        }

                        r2 = r1 + ship.Size - 1;
                        row2 = (char)('A' + r2);

                        while (option)
                        {
                            Console.WriteLine($"Would you like to place your {ship.Name} on {row2}{c1 + 1}? (y/n)");

                            string input = Console.ReadLine()?.Trim().ToLower();

                            if (input == "y")
                            {
                                option = false;
                                c2 = c1;
                                finalOption = true;
                                break;
                            }
                            else if (input == "n")
                            {
                                option = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                            finalOption = false;
                            option = true;
                        }
                    }

                    // check left
                    option = true;
                    x = ship.Size;
                    if (c1 - ship.Size + 1 >= 0 && Board.Matrix[r1][c1] == CellState.Empty && finalOption != true)
                    {
                        for (int i = c1; i >= c1 - ship.Size + 1; i--)
                        {
                            if (Board.Matrix[r1][i] != CellState.Empty)
                            {
                                option = false;
                                break;
                            }
                        }

                        r2 = r1;

                        while (option)
                        {
                            Console.WriteLine($"Would you like to place your {ship.Name} on {row1}{c1 - ship.Size + 2}? (y/n)");

                            string input = Console.ReadLine()?.Trim().ToLower();

                            if (input == "y")
                            {
                                option = false;
                                c2 = c1 - ship.Size + 1;
                                finalOption = true;
                                break;
                            }
                            else if (input == "n")
                            {
                                option = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                            finalOption = false;
                            option = true;
                        }
                        
                    }

                    //check up
                    option = true;
                    x = ship.Size;
                    if (r1 - ship.Size + 1 >= 0 && Board.Matrix[r1][c1] == CellState.Empty && finalOption != true)
                    {
                        for (int i = r1; i >= r1 - ship.Size + 1; i--)
                        {
                            if (Board.Matrix[i][c1] != CellState.Empty)
                            {
                                option = false;
                                break;
                            }
                        }

                        r2 = r1 - ship.Size + 1;
                        row2 = (char)('A' + r2);

                        while (option)
                        {
                            Console.WriteLine($"Would you like to place your {ship.Name} on {row2}{c1 + 1}? (y/n)");

                            string input = Console.ReadLine()?.Trim().ToLower();

                            if (input == "y")
                            {
                                option = false;
                                c2 = c1;
                                finalOption = true;
                                break;
                            }
                            else if (input == "n")
                            {
                                option = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                            option = true;
                            x = ship.Size;
                        }

                        
                    }
                    
                }
                if (Board.PlaceShip(ship, r1, c1, r2, c2))
                {
                    Console.WriteLine($"\n{ship.Name} placed!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid placement. Try again.");
                }
                return true;
            }
        }

        public override (int row, int col) Move() {
            char CharA = 'A';
            char CharB = 'B';
            char CharC = 'C';
            char CharD = 'D';
            char CharE = 'E';
            char CharF = 'F';
            char CharG = 'G';
            char CharH = 'H';
            char CharI = 'I';
            char CharJ = 'J';
            
            while (true)
            {
                char row1;
                int c1;

                // ask row column
                do
                {
                    try
                    {
                        Console.Write("Enter row to fire at (A-J): ");
                        string input = Console.ReadLine().ToUpper();
                        row1 = Convert.ToChar(input);
                    }
                    catch
                    {
                        row1 = ' ';
                        Console.WriteLine("Invalid input. Enter a single letter A-J.");
                    }
                } while (row1 != 'A' && row1 != 'B' && row1 != 'C' && row1 != 'D' && row1 != 'E' && row1 != 'F' && row1 != 'G' && row1 != 'H' && row1 != 'I' && row1 != 'J');

                switch (row1)
                {
                    case 'A':
                        row1 = CharA;
                        break;
                    case 'B':
                        row1 = CharB;
                        break;
                    case 'C':
                        row1 = CharC;
                        break;
                    case 'D':
                        row1 = CharD;
                        break;
                    case 'E':
                        row1 = CharE;
                        break;
                    case 'F':
                        row1 = CharF;
                        break;
                    case 'G':
                        row1 = CharG;
                        break;
                    case 'H':
                        row1 = CharH;
                        break;
                    case 'I':
                        row1 = CharI;
                        break;
                    case 'J':
                        row1 = CharJ;
                        break;
                    default:
                        break;
                }

                int r1 = row1 - 65;


                do
                {
                    Console.Write("Enter column to fire at (1-10): ");
                    c1 = Convert.ToInt32(Console.ReadLine());
                } while (c1 != 1 && c1 != 2 && c1 != 3 && c1 != 4 && c1 != 5 && c1 != 6 && c1 != 7 && c1 != 8 && c1 != 9 && c1 != 10);
                c1 -= 1;
                return (r1, c1);
            }
        }

        public override bool IsAllSunk()
        {
            if (Board.Matrix.All(row => row.All(cell => cell != CellState.Ship)))
            {
                Console.WriteLine("Computer wins!");
                return true;
            }
            return false;
        }
    }
}
