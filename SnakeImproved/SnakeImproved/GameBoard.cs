using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SnakeImproved {
    class GameBoard {

        


        public GameBoard() {

            

        }

        public void InGame() {

            if (Console.KeyAvailable) {                                 //Input controller
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    Console.WriteLine("Hey");
                else if (cki.Key == ConsoleKey.Spacebar)
                    GameController.Pause();
                else if (cki.Key == ConsoleKey.UpArrow && last != 2)
                    newDir = 0;
                else if (cki.Key == ConsoleKey.RightArrow && last != 3)
                    newDir = 1;
                else if (cki.Key == ConsoleKey.DownArrow && last != 0)
                    newDir = 2;
                else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
                    newDir = 3;
            }


        }

    }
}
