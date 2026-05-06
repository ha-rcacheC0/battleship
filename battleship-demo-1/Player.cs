using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship_demo_1
{
    public abstract class Player
    {
        private Board _board;
        public Board Board {  get { return _board; } }

        public Player ()
        {
            _board = new Board();
        }

        public void GiveShips()
        {
            List<Ship> ships = new List<Ship>
            {
                new Ship(5, "Carrier"),
                new Ship(4, "Battleship"),
                new Ship(3, "Cruiser"),
                new Ship(3, "Submarine"),
                new Ship(2, "Destroyer")
            };

            foreach (var ship in ships)
            {
                PlaceShip(ship);
            }
        }

        protected abstract bool PlaceShip(Ship ship);
        public abstract (int row, int col) Move();

        public abstract bool IsAllSunk();
    }

}
