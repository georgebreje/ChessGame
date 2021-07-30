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
        public Point[] points = new Point[4]; // polygon coordinates
        public int Width;
        public int Height;
        public static int heightToAdd;
        public static int widthToAdd;
        public Color Color { get; set; }
        public bool Selected { get; set; } = true;
        public int ClickCount { get; set; }
        
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void CreatePolygon(Graphics g, Color c)
        {
            points[0] = new Point(widthToAdd, heightToAdd);
            points[1] = new Point(widthToAdd, heightToAdd + Height);
            points[2] = new Point(widthToAdd + Width, heightToAdd + Height);
            points[3] = new Point(widthToAdd + Width, heightToAdd);
            Color = c;
            DrawField(g, c);
        }


        public void DrawField(Graphics g, Color c)
        {
            Brush brush = new SolidBrush(c);

            g.FillPolygon(brush, points);
        }

        public void Deselect(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color), points);

            if (Selected == false)
            {
                g.FillPolygon(new SolidBrush(Color), points);
                Selected = true;
            }
        }

        public void Select(Graphics g)
        {
            if (Selected == true)
            {
                g.FillPolygon(new SolidBrush(Color.Yellow), points);
                Selected = false;
            }
            else
            {
                Deselect(g);
            }
        }
    }
}