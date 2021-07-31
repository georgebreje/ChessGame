using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class QueenFactory : IPieceFactory
    {
        public override Piece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new Queen(f, cpb);
        }
    }
}
