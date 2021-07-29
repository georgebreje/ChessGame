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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > Fields[i, j].points[0].X && e.X < Fields[i, j].points[2].X
                                    && e.Y > Fields[i, j].points[0].Y && e.Y < Fields[i, j].points[2].Y)
                    {
                        Fields[i, j].Select(grp);
                    }
                }
            }
            
           
            

            grp.FillEllipse(new SolidBrush(Color.Red), e.X, e.Y, 3, 3);
            //MessageBox.Show($"Clicked at: {e.X}, {e.Y} \n" +
            //    $"Fields[0,0].points[0]: {Fields[0, 0].points[0].X}, {Fields[0, 0].points[0].Y} \n" +
            //    $"Fields[0,0].points[1]: {Fields[0, 0].points[1].X}, {Fields[0, 0].points[1].Y} \n" +
            //    $"Fields[0,0].points[2]: {Fields[0, 0].points[2].X}, {Fields[0, 0].points[2].Y} \n" +
            //    $"Fields[0,0].points[3]: {Fields[0, 0].points[3].X}, {Fields[0, 0].points[3].Y} \n" );
        }

        
    }
}
