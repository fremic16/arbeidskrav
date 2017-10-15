using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SnakeTidy {

    class GameController {

        Stopwatch time;
        int boardWidth, boardHeigth;
        short newDir = 2; 
        short lastDir;
        bool pause;
        bool eaten;
        List<Point> snake;
        Point apple;
        Point newHead;

        public GameController() {
            time = new Stopwatch();
            pause = false;


            /// Board ///
            boardWidth = Console.WindowWidth;
            boardHeigth = Console.WindowHeight;
            Console.Title = "Westerdals Oslo ACT - SNAKE"; 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.SetCursorPosition(10, 10);                              
            Console.Write("@");

            ///Generate Apple///
            apple = PointFactory.Create(1, boardWidth, boardHeigth);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(apple.X, apple.Y);
            Console.Write("$");

            ///Generate Snake///
            SnakeGen();

            /////Direction variables/////
            newDir = 2;
            lastDir = newDir;
        }

        
        ///////////////////////
        /// Snake Generator ///
        ///////////////////////

        private void SnakeGen() {
            snake = new List<Point> { };
            for (int i = 0; i < 4; i++) {
                snake.Add(PointFactory.Create(0, 10, 10));
            }

        }


        /////////////////
        /// THE GAME! ///
        /////////////////

        public void PlayGame() {
            time.Start();
            while (true) {
                Input();

                if (!pause) {
                    if (time.ElapsedMilliseconds < 100) {
                        continue;
                    }
                    time.Restart();

                    newHead = PointFactory.Create(0, snake.Last().X, snake.Last().Y);
                    switch (newDir) {
                        case 0:
                            newHead.Y -= 1;
                            break;
                        case 1:
                            newHead.X += 1;
                            break;
                        case 2:
                            newHead.Y += 1;
                            break;
                        default:
                            newHead.X -= 1;
                            break;
                    }
                    Checks();
                    Printer();
                }
            }
        }


        /////////////////
        /// Game Over ///
        /////////////////

        public void GameOver() {
            Environment.Exit(0);
        }


        //////////////////
        /// Div Checks ///
        //////////////////

        private void Checks() {
            if (newHead.X < 0 || newHead.X >= boardWidth)
                GameOver();
            else if (newHead.Y < 0 || newHead.Y >= boardHeigth)
                GameOver();

            if (newHead.X == apple.X && newHead.Y == apple.Y) {
                if (snake.Count + 1 >= boardWidth * boardHeigth) {
                    GameOver();
                } else {
                    eaten = true;
                }
            }
            if (!eaten) {
                foreach (Point x in snake)
                    if (x.X == newHead.X && x.Y == newHead.Y) {
                        // Death by accidental self-cannibalism.
                        GameOver();
                        break;
                    }
            }
        }


        //////////////////////////
        /// Printing to screen ///
        //////////////////////////

        public void Printer() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(snake.Last().X, snake.Last().Y);
            Console.Write("0");
            if (!eaten) {
                Console.SetCursorPosition(snake.First().X, snake.First().Y);
                Console.Write(" ");
                snake.RemoveAt(0);
            } else {
                while (true) {
                    PointFactory.RenewApple((Apple)apple);
                    foreach (Point i in snake) {
                        if (!(i.X == apple.X && i.Y == apple.Y)) {
                            break;
                        }
                    }
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(apple.X, apple.Y);
                Console.Write("$");
                eaten = false;
            }
            snake.Add(newHead);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write("@");
            lastDir = newDir;
        }


        /////////////////////
        /// Input handler ///
        /////////////////////

        public void Input() {
            if (Console.KeyAvailable) {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    GameOver();
                else if (cki.Key == ConsoleKey.Spacebar)
                    pause = !pause;
                else if (cki.Key == ConsoleKey.UpArrow && lastDir != 2)
                    newDir = 0;
                else if (cki.Key == ConsoleKey.RightArrow && lastDir != 3)
                    newDir = 1;
                else if (cki.Key == ConsoleKey.DownArrow && lastDir != 0)
                    newDir = 2;
                else if (cki.Key == ConsoleKey.LeftArrow && lastDir != 1)
                    newDir = 3;
            }
        }
    }
}

