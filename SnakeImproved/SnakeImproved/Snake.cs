using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    class Snake {

        public Snake() {
            List<Point> snake = new List<Point>();                          //List of points
            snake.Add(new Point(10, 10));                                   //Creating snake
            snake.Add(new Point(10, 10));                                   //
            snake.Add(new Point(10, 10));                                   //
            snake.Add(new Point(10, 10));                                   //
        }
    }
}
