using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class King : Piece, IPiece
    {

        public King(Field f, CustomPictureBox pictureBox) : base(f, pictureBox)
        {

        }

        public override void Direction()
        {
            throw new NotImplementedException();
        }
    }
}
