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
        public float FieldH { get; set; }
        public float FieldW { get; set; }

        public Field[,] Fields = new Field[8, 8];

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
            Latime = p.Height;
            Lungime = p.Width;
            FillMatrix();

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            var p = sender as Panel;
            grp = panel1.CreateGraphics();
            Latime = p.Height;
            Lungime = p.Width;
            FieldW = Lungime / 8;
            FieldH = Latime / 8;
            FillMatrix();



        }

        private void FillMatrix()
        {
            Field.a = 0;
            for (int i = 0; i < 8; i++)
            {
                Field.b = 0;
                for (int j = 0; j < 8; j++)
                {
                    Field f = new Field(FieldW, FieldH);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            f.CreatePolygon(grp, Color.SaddleBrown);

                        else
                            f.CreatePolygon(grp, Color.Chocolate);
                    }
                    else
                    {
                        if (j % 2 == 0)
                            f.CreatePolygon(grp, Color.Chocolate);
                        else
                            f.CreatePolygon(grp, Color.SaddleBrown);
                    }
                    Fields[i, j] = f;
                    Field.b += FieldW;
                }
                Field.a += FieldH;
            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
