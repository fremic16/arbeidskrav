using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SnakeTidy {

    class GameController {

        Stopwatch time;
        int boardW, boardH;
        short newDir = 2; 
        short last;
        bool pause;
        bool Eaten;
        List<Point> snake;
        Point apple;
        Point newH;

        public GameController() {
            time = new Stopwatch();
            pause = false;


            /// Board ///
            boardW = Console.WindowWidth;
            boardH = Console.WindowHeight;
            Console.Title = "Westerdals Oslo ACT - SNAKE"; 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.SetCursorPosition(10, 10);                              
            Console.Write("@");

            ///Generate Apple///
            apple = PointFactory.Create(1, boardW, boardH);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(apple.X, apple.Y);
            Console.Write("$");

            ///Generate Snake///
            SnakeGen();

            /////Direction variables/////
            newDir = 2;
            last = newDir;
        }
        //////////////////////
        /// Sake Generator ///
        //////////////////////

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

                    newH = PointFactory.Create(0, snake.Last().X, snake.Last().Y);
                    switch (newDir) {
                        case 0:
                            newH.Y -= 1;
                            break;
                        case 1:
                            newH.X += 1;
                            break;
                        case 2:
                            newH.Y += 1;
                            break;
                        default:
                            newH.X -= 1;
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
            if (newH.X < 0 || newH.X >= boardW)
                GameOver();
            else if (newH.Y < 0 || newH.Y >= boardH)
                GameOver();

            if (newH.X == apple.X && newH.Y == apple.Y) {
                if (snake.Count + 1 >= boardW * boardH) {
                    GameOver();
                } else {
                    Eaten = true;
                }
            }
            if (!Eaten) {
                foreach (Point x in snake)
                    if (x.X == newH.X && x.Y == newH.Y) {
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
            if (!Eaten) {
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
                Eaten = false;
            }
            snake.Add(newH);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(newH.X, newH.Y);
            Console.Write("@");
            last = newDir;
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

