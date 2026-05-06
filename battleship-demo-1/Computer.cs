using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship_demo_1
{
    public class Computer : Player
    {
        Random random = new Random();

        protected override bool PlaceShip(Ship ship)
        {
            while (true)
            {
                int r1 = random.Next(0, 10);
                int c1 = random.Next(0, 10);
                bool horizontal = random.Next(2) == 0;

                int r2, c2;

                if (horizontal)
                {
                    r2 = r1;
                    c2 = c1 + ship.Size - 1;
                }
                else
                {
                    r2 = r1 + ship.Size - 1;
                    c2 = c1;
                }

                if (r2 < 10 && c2 < 10)
                {
                    if (Board.PlaceShip(ship, r1, c1, r2, c2))
                    {
                        return true;
                    }
                }
            }
        }

        public override (int row, int col) Move() {
            int r1 = random.Next(0, 10);
            int c1 = random.Next(0, 10);

            if (Board.Matrix[r1][c1] == CellState.Empty)
            {
                return (r1, c1);
            }
            else
            {
                return Move();
            }
        }

        public override bool IsAllSunk()
        {
            if (Board.Matrix.All(row => row.All(cell => cell != CellState.Ship)))
                {
                    Console.WriteLine("User wins!");
                return true;
            }
            return false;
        }
    }
}
