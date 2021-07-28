using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public float Latime { get; set; }
        public float Lungime { get; set; }
        public float BorderH { get; set; }
        public float BorderW { get; set; }
        PointF[] points = new PointF[4];

        Dictionary<Field, IPiece> Dict = new Dictionary<Field, IPiece>();

        Graphics grp;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            //float a = 0;
            Field.a = 0;
            for (int j = 1; j <= 8; j++)
            {
                //float b = 0;
                Field.b = 0;
                for (int i = 1; i <= 8; i++)
                {
                    Field f = new Field(BorderW, BorderH);
                    f.CreatePolygon();
                    //points[0] = new PointF(b, a);
                    //points[1] = new PointF(b, a + BorderH);
                    //points[2] = new PointF(b + BorderW, a + BorderH);
                    //points[3] = new PointF(b + BorderW, a);

                    if (j % 2 != 0)
                    {
                        if (i % 2 != 0)
                            f.Redraw(grp, Color.SaddleBrown);
                        else
                            f.Redraw(grp, Color.Chocolate);
                    }
                    else
                    {
                        if (i % 2 == 0)
                            f.Redraw(grp, Color.SaddleBrown);
                        else
                            f.Redraw(grp, Color.Chocolate);
                    }
                    // b += BorderW;
                    Field.b += BorderW;
                }
                //a += BorderH;
                Field.a += BorderH;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            var p = sender as Panel;
            grp = panel1.CreateGraphics();
            Refresh();
            Latime = p.Height;
            Lungime = p.Width;
            BorderW = Lungime / 8;
            BorderH = Latime / 8;
            //float a = 0;
            Field.a = 0;
            for (int j = 1; j <= 8; j++)
            {
                //float b = 0;
                Field.b = 0;
                for (int i = 1; i <= 8; i++)
                {
                    Field f = new Field(BorderW, BorderH);
                    f.CreatePolygon();
                    //points[0] = new PointF(b, a);
                    //points[1] = new PointF(b, a + BorderH);
                    //points[2] = new PointF(b + BorderW, a + BorderH);
                    //points[3] = new PointF(b + BorderW, a);

                    if (j % 2 != 0)
                    {
                        if (i % 2 != 0)
                            f.Redraw(grp, Color.SaddleBrown);
                        else
                            f.Redraw(grp, Color.Chocolate);
                    }
                    else
                    {
                        if (i % 2 == 0)
                            f.Redraw(grp, Color.SaddleBrown);
                        else
                            f.Redraw(grp, Color.Chocolate);
                    }
                    //b += BorderW;
                    Field.b += BorderW;
                }
                // a += BorderH;
                Field.a += BorderH;
            }
        }

        private void Redraw(Graphics g, Color c)
        {
            Brush brush = new SolidBrush(c);

            g.FillPolygon(brush, points);
        }

        private void Redraw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.SaddleBrown);

            g.FillPolygon(brush, points);
        }

        private void Refresh(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.Black), points);
        }
    }
}
