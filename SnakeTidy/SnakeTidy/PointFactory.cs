using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTidy {

    class PointFactory {

        private PointFactory() { }

        public static Point Create(int type, params int[] parameters) {
            Point point = null;
            switch (type) {
                case 0:
                    point = new SnakePoint(parameters[0], parameters[1]);
                    break;
                case 1:
                    point = new Apple(parameters[0], parameters[1]);
                    break;
            }
            return point;
        }

        public static Point RenewApple(Apple apple) {
            apple.setCoords(apple);
            return apple;

        }
    }
}