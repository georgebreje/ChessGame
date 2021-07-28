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
        PointF[] pointz = new PointF[4];

        Graphics grp;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            float a = 0;
            float b = 0;
            
            for (int i = 1; i <= 8; i++)
            {
                points[0] = new PointF(b, 0);
                points[1] = new PointF(b, BorderH);
                points[2] = new PointF(b + BorderW, BorderH);
                points[3] = new PointF(b + BorderW, 0);
                if (i % 2 != 0)
                    Redraw(grp, Color.SaddleBrown);
                else
                    Redraw(grp, Color.Chocolate);
                b += BorderW;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static Random rnd = new Random();

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            var p = sender as Panel;
            grp = panel1.CreateGraphics();
            Refresh(); 
            Latime = p.Height;
            Lungime = p.Width;
            BorderW = Lungime / 8;
            BorderH = Latime / 8;
            float a = 0;
            float b = 0;

            for (int i = 1; i <= 8; i++)
            {
                points[0] = new PointF(b, 0);
                points[1] = new PointF(b, BorderH);
                points[2] = new PointF(b + BorderW, BorderH);
                points[3] = new PointF(b + BorderW, 0);

                if (i % 2 != 0)
                    Redraw(grp, Color.SaddleBrown);
                else
                    Redraw(grp, Color.Chocolate);

                b += BorderW;
            }
            //pointz[0] = new PointF(BorderW, 0);
            //pointz[1] = new PointF(BorderW, BorderH);
            //pointz[2] = new PointF(BorderW + BorderW, BorderH);
            //pointz[3] = new PointF(BorderW + BorderW, 0);

            //grp.FillPolygon(new SolidBrush(Color.Black), pointz);


            //float a = 0;
            //for (int i = 1; i <= 8; i++)  
            //{
            //    float b = 0;
            //    for (int j = 1; j <= 8; j++)
            //    {
            //        if (i % 2 != 0)
            //        {
            //            if (j % 2 != 0)
            //            {
            //                Redraw(grp, Color.SaddleBrown);
            //            }
            //            else
            //                Redraw(grp, Color.White);
            //        }
            //        else
            //        {

            //        }
            //        b += BorderW;
            //    }
            //    a += BorderH;
            //}

            //Redraw(grp);
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
