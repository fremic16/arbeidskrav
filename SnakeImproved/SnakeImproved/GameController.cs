using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    class GameController {

        public GameController() {
            int boardW = Console.WindowWidth, boardH = Console.WindowHeight;

            Console.CursorVisible = false;                                  //Hide cursor
            Console.Title = "Westerdals Oslo ACT - SNAKE";                  //Windows title
            Console.ForegroundColor = ConsoleColor.Green;                   //Point color
            Console.SetCursorPosition(10, 10);                              //Set cursor position
            Console.Write("@");

            var snake = new Snake();
            var apple = new Apple();
        }
    }
}
