using GraSzachy;
using nsFigura;

namespace nsPawn
{
    class Pawn : Figura
    {
        public Pawn(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Pionek";
            this.Icon = color == fColor.Black ? "img/Pawn.png" : "img/Pawn_White.png";
            this.Power = 1;
            this.SetOnTable();
        }
        override public bool Move(int row, int col)
        {
            if ((this.Position.Col == col) &&
                ((this.Position.Row == row - 1) ||
                (this.Position.Row == row + 1) ||
                (this.Position.Row == row - 2 && row == 3) ||
                (this.Position.Row == row + 2 && row == 4)))
            {
                this.Position = new Cell(row, col);
                return true;
            }
            else
                return false;
        }
    }
}
