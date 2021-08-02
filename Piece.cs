using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public abstract class Piece : IPiece
    {
        public  Color ColorHolder { get; set; }
        
        public CustomPictureBox PictureBox { get; set; }
        
        public Field Field { get; set; }

        public bool White { get; set; }

        public bool Black { get; set; }

        public bool Selected { get; set; }
        public  Piece(Field f, CustomPictureBox pictureBox)
        {
            PictureBox = pictureBox;
            Field = f;
            PictureBox.BackColor = f.Color;
            PictureBox.Location = new Point(f.points[0].X, f.points[0].Y);
            PictureBox.Size = new Size(f.Width, f.Height);
            PictureBox.AuxColor = f.Color;
            PictureBox.Piece = this;
            ColorHolder = f.Color;
            Selected = PictureBox.Selected;
            if (PictureBox.Name.Contains("white"))
                White = true;
            else if (PictureBox.Name.Contains("black"))
                Black = true;
        }


        public void Deselect()
        {
            PictureBox.BackColor = ColorHolder; 
        }

        public virtual void Direction()
        {
            throw new NotImplementedException();
        }
    }
}
