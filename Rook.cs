using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
    public class Rook : Piece, IPiece
    {

        public Rook(Field f, CustomPictureBox pictureBox) : base(f,pictureBox)
        {

        }
        public override void Direction()
        {
            
        }
    }
}
