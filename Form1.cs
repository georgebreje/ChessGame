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
            //Dict.Add(Fields[0, 0], new Rook(Fields[0,0], pictureBox1));
            DictInit();

            KnightFactory knightFactory = new KnightFactory();
            IPiece wKnight = knightFactory.CreatePiece(Fields[0, 1], wKnight1);



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

        private void DictInit()
        {
            Dict.Add(Fields[0, 0], new Rook(Fields[0, 0], wRook1));
            //Dict.Add(Fields[0, 1], new Rook(Fields[0, 1], wKnight1));
            Dict.Add(Fields[0, 2], new Rook(Fields[0, 2], wBishop1));
            Dict.Add(Fields[0, 3], new Rook(Fields[0, 3], wQueen));
            Dict.Add(Fields[0, 4], new Rook(Fields[0, 4], wKing));
            Dict.Add(Fields[0, 5], new Rook(Fields[0, 5], wBishop2));
            Dict.Add(Fields[0, 6], new Rook(Fields[0, 6], wKnight2));
            Dict.Add(Fields[0, 7], new Rook(Fields[0, 7], wRook2));

            Dict.Add(Fields[1, 0], new Pawn(Fields[1, 0], whitePawn1));
            Dict.Add(Fields[1, 1], new Pawn(Fields[1, 1], whitePawn2));
            Dict.Add(Fields[1, 2], new Pawn(Fields[1, 2], whitePawn3));
            Dict.Add(Fields[1, 3], new Pawn(Fields[1, 3], whitePawn4));
            Dict.Add(Fields[1, 4], new Pawn(Fields[1, 4], whitePawn5));
            Dict.Add(Fields[1, 5], new Pawn(Fields[1, 5], whitePawn6));
            Dict.Add(Fields[1, 6], new Pawn(Fields[1, 6], whitePawn7));
            Dict.Add(Fields[1, 7], new Pawn(Fields[1, 7], whitePawn8));
        }

        private void FillFields()
        {

        }

        private void FillMatrix()
        {
            Field.heightToAdd = 0;
            for (int i = 0; i < 8; i++)
            {
                Field.widthToAdd = 0;
                for (int j = 0; j < 8; j++)
                {
                    Field f = new Field(FieldW, FieldH);
                    whitePawn1.Width = FieldW;
                    whitePawn1.Height = FieldH;

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
                    Field.widthToAdd += FieldW;
                }
                Field.heightToAdd += FieldH;
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
    }
}
