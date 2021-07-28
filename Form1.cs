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
            float d = p.Width;
            float x = p.Height;
            Table t = new Table(d, x);
            t.InitializeFields();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            t[i, j].Redraw(grp, Color.SaddleBrown);
                        else
                            t[i, j].Redraw(grp, Color.Chocolate);
                    }
                    else
                    {
                        if (j % 2 == 0)
                            t[i, j].Redraw(grp, Color.Chocolate);
                        else
                            t[i, j].Redraw(grp, Color.SaddleBrown);
                    }
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            var p = sender as Panel;
            grp = panel1.CreateGraphics();
            Latime = p.Height;
            Lungime = p.Width;
            Table t = new Table(Latime, Lungime);
            t.InitializeFields();

            BorderW = Lungime / 8;
            BorderH = Latime / 8;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            t[i, j].Redraw(grp, Color.SaddleBrown);
                        else
                            t[i, j].Redraw(grp, Color.Chocolate);
                    }
                    else
                    {
                        if (j % 2 == 0)
                            t[i, j].Redraw(grp, Color.Chocolate);
                        else
                            t[i, j].Redraw(grp, Color.SaddleBrown);
                    }
                }
            }

            
        }

        private void Redraw(Graphics g, Color c)
        {
            Brush brush = new SolidBrush(c);

            g.FillPolygon(brush, points);
        }
    }
}
