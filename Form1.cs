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
        Graphics grp;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;


            g.FillRectangle(new SolidBrush(Color.Black), p.DisplayRectangle);

            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);
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
            points[0] = new PointF(0, 0);
            points[1] = new PointF(0, BorderH);
            points[2] = new PointF(BorderW, BorderH);
            points[3] = new PointF(BorderW, 0);
            Redraw(grp);
        }

        private void Redraw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);
        }

        private void Refresh(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.Black), points);
        }
    }
}
