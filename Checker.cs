using GraSzachy;
using nsFigura;

namespace nsChecker
{
    class Checker : Figura
    {
        public Checker(Chessboard szachownica, Cell position, fColor color) : base(szachownica, position, color)
        {
            this.Name = "Warcab";
            this.Icon = color == fColor.Black ? "img/Checker.png" : "img/Checker_White.png";
            this.Power = 1;
            this.SetOnTable();
        }
        override public bool Move(int row, int col)
        {
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7,
                        -1, -2, -3, -4, -5, -6, -7, -1, -2, -3, -4, -5, -6, -7 };
            int[] y = { 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, 7,
                        1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7 };

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
