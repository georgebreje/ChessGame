using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class IPieceFactory
    {
        
        public Piece MakePiece(Field f, CustomPictureBox cpb)
        {
            Piece piece = CreatePiece(f, cpb);

            return piece;
        }
        public abstract Piece CreatePiece(Field f, CustomPictureBox cpb);
    }
}
