using GraSzachy;
using nsFigura;

namespace nsRook
{
    class Rook : Figura
    {
        public Rook(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Wieża";
            this.Icon = color == fColor.Black ? "img/Rook.png" : "img/Rook_White.png";
            this.Power = 5;
            this.SetOnTable();
        }
        override public bool Move(int row, int col)
        {
            if ((this.Position.Row == row - 1 && this.Position.Col == col) ||
                (this.Position.Row == row + 1 && this.Position.Col == col))
            {
                this.Position = new Cell(row, col);
                return true;
            }
            else
                return false;
        }
    }
}
