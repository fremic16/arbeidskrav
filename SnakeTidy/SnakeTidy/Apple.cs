using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTidy {
    class Apple : Point {

        Random rnd = new Random();
        int boardW;
        int boardH;

        public Apple(int Width, int Height) {
            boardW = Width;
            boardH = Height;
            setCoords(this);
        }
        public Apple setCoords(Apple apple) {
            apple.X = rnd.Next(0, boardW);
            apple.Y = rnd.Next(0, boardH);

            return apple;
        }
    }
}
