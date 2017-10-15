using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeImproved {
    enum PointType { Snake, Apple}
    class PointFactory {

        private PointFactory() { }

        public static Point Create(PointType type, int[] parameters) {
            switch(type) {
                case PointType.Snake:
                    Point = new SnakePoint()
            }
        }
    }
}
