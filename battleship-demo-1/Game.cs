using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship_demo_1
{
    public class Game
    {
        private User _user;
        private Computer _computer;
        private int userWins = 0;
        private int computerWins = 0;
        public void Start()
        {
            bool play = true;
            Console.WriteLine("Welcome to Battleship!");
            // Game Loop
            while (play)
            {
                Console.WriteLine("-- Place your ships --");

                _user = new User();
                _computer = new Computer();

                _user.GiveShips();
                _computer.GiveShips();

                // Match Loop
                while (true)
                {
                    var (r, c) = _user.Move();

                    _computer.Board.Fire(r, c);

                    if (_computer.IsAllSunk())
                    {
                        userWins++;
                        break;
                    }

                    Console.WriteLine("\nComputer board:");
                    _computer.Board.Print(hidden: false);

                    var (ro, co) = _computer.Move();
                    _user.Board.Fire(ro, co);

                    if (_user.IsAllSunk())
                    {
                        computerWins++;
                        break;
                    }

                    Console.WriteLine("\nYour board:");
                    _user.Board.Print();
                }

                Console.WriteLine($"User Wins: {userWins} Computer Wins: {computerWins}");
                Console.WriteLine($"Would you like to play again? (y/n)");

                bool choice = true;
                do
                {
                    string input = Console.ReadLine()?.Trim().ToLower();

                    if (input == "y")
                    {
                        play = true;
                        choice = false;
                    }
                    else if (input == "n")
                    {
                        play = false;
                        break;
                    }
                    else
                    {
                        choice = true;
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    }
                } while (choice);  
            }
        }
    }
}
