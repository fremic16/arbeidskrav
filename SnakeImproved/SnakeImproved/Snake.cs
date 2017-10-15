using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    class Snake {

        List<Point> snake;
        Point head;

        public Snake() {
            snake = new List<Point>();                          //List of points
            snake.Add(new Point(10, 10));                                   //Creating snake
            snake.Add(new Point(10, 10));                                   //
            snake.Add(new Point(10, 10));                                   //
            snake.Add(new Point(10, 10));
            head = new Point(10, 10);
        }
        
        public void RemoveTail() {
            snake.RemoveAt(0);
        }
        //Creates a new head and returns it
        public Point NewHead() {
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
            return newH;
        }
    }
}
