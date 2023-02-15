using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace SimpleDrawingCase
{
    [Serializable]
    public class HexagonShape : Shape
    {
        public HexagonShape(Point locationStaritng, Point locationEnding) : base(locationStaritng, locationEnding) { }
        public HexagonShape(Point locationStaritng, Point locationEnding, Color color) : base(locationStaritng, locationEnding, color) { }
        public override void SetCornerPoints()
        {
            int high = LocationEnding.Y - LocationStarting.Y;
            Point[] points ={
                new Point(LocationStarting.X+high/4, LocationEnding.Y),
                new Point(LocationEnding.X-high/4, LocationEnding.Y),
                new Point(LocationEnding.X,LocationEnding.Y-high/2),
                new Point(LocationEnding.X-high/4,LocationStarting.Y),
                new Point(LocationStarting.X+high/4, LocationStarting.Y),
                new Point(LocationStarting.X, LocationStarting.Y+high/2)
            };
            this.cornerPoints = points;
        }
    }
}
