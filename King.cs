using GraSzachy;
using nsFigura;

namespace nsKing
{
    class King : Figura
    {
        public King(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Król";
            this.Icon = (color == fColor.Black) ? "img/King.png" : "img/King_White.png";
            this.Power = 12;
            this.SetOnTable();
        }
        override public bool Move(int row, int col)
        {
            int[] x = { 0, 0, 1, 1, 1 };
            int[] y = { 1, -1, 0, 1 -1 };

            for (int i = 0; i < x.Length; i++)
            {
                if ((this.Position.Row - row == x[i]) && (this.Position.Col - col == y[i]))
                {
                    this.Position = new Cell(row, col);
                    return true;
                }
            }
            return false;
        }
    }
}
