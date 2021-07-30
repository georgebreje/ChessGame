using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PawnFactory : IPieceFactory
    {


        public override IPiece CreatePiece(Field f, CustomPictureBox customPictureBox)
        {
            return new IPiece(f,customPictureBox);
        }
    }
}
