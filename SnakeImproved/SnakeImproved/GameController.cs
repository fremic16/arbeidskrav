using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SnakeImproved {
    class GameController {

        Stopwatch t;
        short newDir = 2;                                               // 0 = up, 1 = right, 2 = down, 3 = left
        short last;
        bool go;
        Snake snake;

        public GameController() {
            t = new Stopwatch();
            go = false;

            int boardW = Console.WindowWidth, boardH = Console.WindowHeight;

            Console.Title = "Westerdals Oslo ACT - SNAKE";                  //Windows title
            Console.ForegroundColor = ConsoleColor.Green;

            newDir = 2;
            last = newDir;

            var snake = new Snake();
            var apple = new Apple(boardW, boardH);

            Console.CursorVisible = false;

            Console.SetCursorPosition(10, 10);                              //Set cursor position
            Console.Write("@");

        }
        public void PlayGame() {

            t.Start();

            if (Console.KeyAvailable) {                                 //Input controller
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    Console.WriteLine("Quit");
                else if (cki.Key == ConsoleKey.Spacebar)
                    Console.WriteLine("Pause");
                else if (cki.Key == ConsoleKey.UpArrow && last != 2)
                    newDir = 0;
                else if (cki.Key == ConsoleKey.RightArrow && last != 3)
                    newDir = 1;
                else if (cki.Key == ConsoleKey.DownArrow && last != 0)
                    newDir = 2;
                else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
                    newDir = 3;
            }

            while(!go) {
                snake.NewHead();
            }
        }
    }
}
