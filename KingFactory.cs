using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class KingFactory : IPieceFactory
    {
        public override Piece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new King(f, cpb);
        }
    }
}
