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
        public Color Color { get; set; }
        public bool Selected { get; set; } = true;


        public Field(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public void CreatePolygon(Graphics g, Color c)
        {
            points[0] = new PointF(b, a);
            points[1] = new PointF(b, a + _height);
            points[2] = new PointF(b + _width, a + _height);
            points[3] = new PointF(b + _width, a);
            Color = c;
            DrawField(g, c);
        }


        public void DrawField(Graphics g, Color c)
        {
            Brush brush = new SolidBrush(c);

            g.FillPolygon(brush, points);
        }

        public void Select(Graphics g)
        {
            
            if (Selected == true)
            {
                g.DrawPolygon(new Pen(Color.Yellow), points);
                Selected = false;
            }
            else
            {
                g.DrawPolygon(new Pen(Color), points);
                Selected = true;
            }
        }
    }
}
