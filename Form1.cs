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
        public int Latime { get; set; }
        public int Lungime { get; set; }
        public int FieldH { get; set; }
        public int FieldW { get; set; }

        public Field[,] Fields = new Field[8, 8];

        Dictionary<Field, Piece> Dict = new Dictionary<Field, Piece>();


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
            Dict.Add(Fields[0, 0], new Rook(Fields[0,0], pictureBox1));


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
                    pictureBox1.Size = new Size((int)Lungime / 8, (int)Latime / 8);
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

        int iToDeselect = 0;
        int jToDeselect = 0;
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Fields[iToDeselect, jToDeselect].Deselect(grp);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > Fields[i, j].points[0].X && e.X < Fields[i, j].points[2].X
                     && e.Y > Fields[i, j].points[0].Y && e.Y < Fields[i, j].points[2].Y)
                    {
                        if (i == iToDeselect && j == jToDeselect)
                        {
                            Fields[i, j].ClickCount++;
                            if (Fields[i, j].ClickCount % 2 == 0)
                                Fields[i, j].Deselect(grp);
                            else
                                Fields[i, j].Select(grp);
                        }
                        else
                        {
                            Fields[i, j].Select(grp);
                            Fields[i, j].ClickCount++;
                            iToDeselect = i;
                            jToDeselect = j;
                            break;
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
