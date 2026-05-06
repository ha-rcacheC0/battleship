using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace battleship_demo_1
{
    public class Ship
    {
        private int _size;
        public int Size { get { return _size; } }
        private string _name;
        public string Name { get { return _name; } }
        private int _hit;

        public Ship(int size, string name)
        {
            _size = size;
            _name = name;
            _hit = 0;
        }


        public bool isSunk()
        {
            if (_hit == 0 || _hit < _size)
            {
                return false;
            }

            if (_hit >= _size)
            {
                return true;
            }
            return false;
        }
        public void Hit()
        {
            _hit++;
        }

    }
}
