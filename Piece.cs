using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public abstract class Piece
    {
        public  Color Color { get; set; }
        public  PictureBox PictureBox { get; set; }
        public  Piece(Field f, PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            PictureBox.BackColor = f.Color;
            PictureBox.Location = new Point(f.points[0].X, f.points[0].Y);
            PictureBox.Size = new Size(f.Width, f.Height);
        }
        public abstract void Direction();


    }
}
