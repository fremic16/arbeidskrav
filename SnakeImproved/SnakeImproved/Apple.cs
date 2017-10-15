using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    class Apple {

        Random rnd = new Random();
        int boardW;
        int boardH;

        public Apple(int boardw, int boardh) {
            boardW = boardw;
            boardH = boardh;
            Point point = new Point(boardW,boardH);
        }

        public void AppleGen(Point point) {

                                                  
            point.X = rnd.Next(0, boardW); point.Y = rnd.Next(0, boardH);

        }
    }
}
