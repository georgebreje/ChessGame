using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class IPieceFactory
    {
        public IPiece MakePiece(Field f, CustomPictureBox customPictureBox)
        {
            IPiece piece = CreatePiece(f, customPictureBox);
            return piece;
        }
        public abstract IPiece CreatePiece(Field f, CustomPictureBox customPictureBox);
    }
}
