using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessGame
{
    public class Field
    {
        public PointF[] points = new PointF[4]; // polygon coordinates
        private float _width;
        private float _height;
        public static float a;
        public static float b;


        public Field(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public void CreatePolygon()
        {
            points[0] = new PointF(b, a);
            points[1] = new PointF(b, a + _height);
            points[2] = new PointF(b + _width, a + _height);
            points[3] = new PointF(b + _width, a);
        }

        public void Redraw(Graphics g, Color c)
        {
            Brush brush = new SolidBrush(c);

            g.FillPolygon(brush, points);
        }

    }
}
