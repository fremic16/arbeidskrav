using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    class OldGC {

        Snake snake;
        Apple apple;
        bool pause = false;

        public GameController() {
            //Creating border for collision trigger and point placement


            //Point color

            //snake = new Snake();
            //apple = new Apple(boardW, boardH);
            var GB = new GameBoard();

        }

        private void PlayGame() {


            bool gg = false, inUse = false;                  //gg = game over //pause = pause eller ikke //inUse


            Stopwatch t = new Stopwatch();                                  //Instantiate time variable
            t.Start();

            while (!gg) {                                                   //While game is running...
                                                                            //Input end
                if (!pause) {                                               //As long as not pause
                    if (t.ElapsedMilliseconds < 100)
                        continue;
                    t.Restart();

                    Point tail = new Point(snake.First());              //Make reference to tail
                    Point head = new Point(snake.Last());               //Make reference to head
                    Point newH = new Point(head);                       //Make reference to new head(At current head position)
                    switch (newDir) {                                   //Switch for directions. Move the  new head 1 point away
                        case 0:                                         //from the current head, to make it look like the snake
                            newH.Y -= 1;                                //is moving. Pluss or minus 1 point in the direction it's moving
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

                    if (newH.X < 0 || newH.X >= boardW)                 //Border-control X coordinate
                        gg = true;
                    else if (newH.Y < 0 || newH.Y >= boardH)            //Border-control Y coordinate
                        gg = true;
                    if (newH.X == point.X && newH.Y == point.Y) {       //Colision check new snake-head and apple
                        if (snake.Count + 1 >= boardW * boardH)
                            // No more room to place apples - game over.
                            gg = true;                                  //Game over
                        else {
                            while (true) {                              //If there is enough space, place another apple
                                point.X = rnd.Next(0, boardW);          //Generate new apple X coordinate
                                point.Y = rnd.Next(0, boardH);          //Generate new apple Y coordinate
                                bool found = true;
                                foreach (Point i in snake)              //Check if new apple position collides with current snake position
                                    if (i.X == point.X && i.Y == point.Y) {
                                        found = false;                  //If collision with snake, set found to false
                                        break;
                                    }
                                if (found) {                            //If found is still true, all is good
                                    inUse = true;                       //Set apple-eaten = true
                                    break;
                                }
                            }
                        }
                    } //end collision check between apple and new snake head
                    if (!inUse) {                                       //As long as the snake didn't eat an apple
                        snake.RemoveTail();
                        //Remove the tail(For movement)
                        foreach (Point x in snake)                      //Self-cannibalism check
                            if (x.X == newH.X && x.Y == newH.Y) {
                                // Death by accidental self-cannibalism.
                                gg = true;
                                break;
                            }
                    }
                    if (!gg) {                                          //As long as not Game Over
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y);      //Where the head currently is
                        Console.Write("0");                             //Write 0, wich is a bodypart
                        if (!inUse) {                                   //**\\If we haven't eaten an apple//**\\
                            Console.SetCursorPosition(tail.X, tail.Y);  //Go to tail position
                            Console.Write(" ");                         //Remove the tail(as the head is placed one point ahead
                        } else {                                        //**\\If we've eaten an apple//**\\
                            Console.ForegroundColor = ConsoleColor.Green;//Do not delete the tail
                            Console.SetCursorPosition(point.X, point.Y);//Set the cursor at new apple position
                            Console.Write("$");                         //Write '$'
                            inUse = false;                              //Sets inUse to false, ready to trigger next time we eat an apple
                        }
                        snake.Add(newH);                                //Add the new head to the snake
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(newH.X, newH.Y);      //Go to new head position
                        Console.Write("@");                             //Write '@' to indicate a new head. If tail was not removed, snake has now increased in length 
                        last = newDir;                                  //**And set the last direction to the current one**//
                    }
                }
            }
        }

        public void Pause() {

            if (pause) {
                pause = false;
            } else {
                pause = true;
            }

        }
    }
}
