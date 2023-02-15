using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleDrawingCase
{
    [Serializable]
    public class CircleShape : Shape
    {
        public CircleShape(Point locationStaritng, Point locationEnding) : base(locationStaritng, locationEnding) { }
        public CircleShape(Point locationStaritng, Point locationEnding, Color color) : base(locationStaritng, locationEnding, color) { }

        public override void SetCornerPoints()
        {
            Point[] points ={
                  new Point(LocationStarting.X, LocationStarting.Y)
            };
            this.cornerPoints = points;
        }
    }
}
