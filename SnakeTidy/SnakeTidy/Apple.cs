using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTidy {
    class Apple : Point {

        Random random = new Random();
        int boardWidth;
        int boardHeigth;

        public Apple(int Width, int Height) {
            boardWidth = Width;
            boardHeigth = Height;
            setCoords(this);
        }
        public Apple setCoords(Apple apple) {
            apple.X = random.Next(0, boardWidth);
            apple.Y = random.Next(0, boardHeigth);

            return apple;
        }
    }
}
