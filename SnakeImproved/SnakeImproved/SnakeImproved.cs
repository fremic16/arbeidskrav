using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code! And I can now (proudly?) say that this is the uggliest short piece of code I've ever written!
//          (And yes, it could have been ugglier. But the idea wasn't to make it fuggly-uggly, just funny-uggly or sweet-uggly.)
//
//          -Tomas
//
namespace SnakeImproved {

    class SnakeMess {
        public static void Main(string[] arguments) {
            bool gg = false, pause = false, inUse = false;                  //gg = game over //pause = pause eller ikke //inUse
            short newDir = 2;                                               // 0 = up, 1 = right, 2 = down, 3 = left
            short last = newDir;                                            //Last direction
            //The board
                                                 //Creating points
            
                                                         //Snake icon
            while (true) {                                                  //Placing first apple
                
                bool spot = true;
                foreach (Point i in snake)
                    if (i.X == point.X && i.Y == point.Y) {
                        spot = false;
                        break;
                    }                                                       //Apple placed
                if (spot) {                                                 //Creating Apple
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write("$");
                    break;
                }                                                           //Apple created
            }
            Stopwatch t = new Stopwatch();                                  //Instantiate time variable
            t.Start();                                                      //Start clock
            while (!gg) {                                                   //While game is running...
                if (Console.KeyAvailable) {                                 //Input controller
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                        gg = true;
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
                }                                                           //Input end
                if (!pause) {                                               //As long as not pause
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();
                    Point tail = new Point(snake.First());
                    Point head = new Point(snake.Last());
                    Point newH = new Point(head);
                    switch (newDir) {                                      //Move snake
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
                    }                                                   //End not-pause
                    if (newH.X < 0 || newH.X >= boardW)                 //Border-control
                        gg = true;
                    else if (newH.Y < 0 || newH.Y >= boardH)            //Border-control
                        gg = true;
                    if (newH.X == point.X && newH.Y == point.Y) {       //Eating apple
                        if (snake.Count + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gg = true;
                        else {
                            while (true) {                              //Placing next apple
                                point.X = rnd.Next(0, boardW); point.Y = rnd.Next(0, boardH);
                                bool found = true;
                                foreach (Point i in snake)              //No-snake-collide check
                                    if (i.X == point.X && i.Y == point.Y) {
                                        found = false;
                                        break;                          //Retry if snake-collision
                                    }
                                if (found) {                            //If all-good
                                    inUse = true;                       //Activate apple
                                    break;
                                }
                            }
                        }
                    }
                    if (!inUse) {                                       //Remove snake-point(movement compensation)
                        snake.RemoveAt(0);                              //Will not trigger on apple consumption
                        foreach (Point x in snake)
                            if (x.X == newH.X && x.Y == newH.Y) {
                                // Death by accidental self-cannibalism.
                                gg = true;
                                break;
                            }
                    }
                    if (!gg) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y);
                        Console.Write("0");
                        if (!inUse) {
                            Console.SetCursorPosition(tail.X, tail.Y);
                            Console.Write(" ");
                        } else {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(point.X, point.Y);
                            Console.Write("$");
                            inUse = false;
                        }
                        snake.Add(newH);                                //Add snake-point(for movement)
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.X, newH.Y); Console.Write("@");
                        last = newDir;
                    }
                }
            }
        }
    }
}