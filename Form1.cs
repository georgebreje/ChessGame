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

        public static Field[,] Fields = new Field[8, 8];

        public static Dictionary<Field, Piece> Dict = new Dictionary<Field, Piece>();

        public static Graphics grp;
        
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
            ResizePiece(FieldW, FieldH);
            FillFields();

        }


        int row = 8, col = 7;
        private void FillFields()
        {
            var customPicBoxes = GetAll(this, typeof(CustomPictureBox));
            foreach (CustomPictureBox cpb in customPicBoxes)
            {
                if (col < 0 && row == 0)
                    break;
                if (col < 0)
                    col = 7;
                if (col == 7)
                    if (row != 0)
                        row--;
                if (row == 5)
                    row = 1;
                string pieceName = cpb.Name;
                IPieceFactory pieceFactory;
                if (pieceName.Contains("Knight"))
                {
                    pieceFactory = new KnightFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                else if (pieceName.Contains("Rook"))
                {
                    pieceFactory = new RookFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                else if (pieceName.Contains("Pawn"))
                {
                    pieceFactory = new PawnFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                else if (pieceName.Contains("Bishop"))
                {
                    pieceFactory = new BishopFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                else if (pieceName.Contains("King"))
                {
                    pieceFactory = new KingFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                else if (pieceName.Contains("Queen"))
                {
                    pieceFactory = new QueenFactory();
                    Dict.Add(Fields[row, col], pieceFactory.MakePiece(Fields[row, col], cpb));
                }
                col--;
            }
        }

        // update picturebox size and location with the new field data
        private void ResizePiece(int width, int height)
        {
            row = 8;
            col = 7;
            foreach (KeyValuePair<Field, Piece> kvp in Dict)
            {
                kvp.Value.PictureBox.Height = height;
                kvp.Value.PictureBox.Width = width;
                kvp.Value.PictureBox.Location = new Point(kvp.Key.points[0].X, kvp.Key.points[0].Y);
            }
        }


        // resize each field of the table when panel resizes / is created
        private void FillMatrix()
        {
            Field.heightToAdd = 0;
            for (int i = 0; i < 8; i++)
            {
                Field.widthToAdd = 0;
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
                    f.Row = i;
                    f.Col = j;
                    Field.widthToAdd += FieldW;
                }
                Field.heightToAdd += FieldH;
                
            }
        }

        // functionality to iterate trough what Form1 contains
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillFields();
            ResizePiece(Lungime / 8, Latime / 8);
            

        }
        int iToDeselect = 0;
        int jToDeselect = 0;
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // move picture box in another field
            Fields[iToDeselect, jToDeselect].Deselect(grp);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > Fields[i, j].points[0].X && e.X < Fields[i, j].points[2].X
                     && e.Y > Fields[i, j].points[0].Y && e.Y < Fields[i, j].points[2].Y)
                    {
                        Dict.Add(Fields[i, j], Dict[Fields[1, 1]]);
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
