namespace ChessGame
{
    internal class PawnFactory : IPieceFactory
    {
        public override Piece CreatePiece(Field f, CustomPictureBox cpb)
        {
            return new Pawn(f, cpb);
        }
    }
}