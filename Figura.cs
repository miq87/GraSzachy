using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using GraSzachy;

namespace nsFigura
{
    enum fColor { Black = 0, White = 1 }
    abstract class Figura
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cell Position { get; set; }
        public fColor Color { get; set; }
        public int Power { get; set; }
        protected string Icon;

        protected Chessboard szachownica;

        public Figura(Chessboard szachownica, Cell position, fColor color)
        {
            this.szachownica = szachownica;
            this.Id = staticCounter.Next();
            this.Position = position;
            this.Color = color;
        }
        // BEGIN OPERATORY
        public static bool operator !=(Figura fig1, Figura fig2)
        {
            return ((fig1.Position != fig2.Position) && (fig1.Name != fig2.Name) && (fig1.Color != fig2.Color));
        }
        public static bool operator ==(Figura fig1, Figura fig2)
        {
            return ((fig1.Position == fig2.Position) && (fig1.Name == fig2.Name) && (fig1.Color == fig2.Color));
        }
        public static bool operator <(Figura fig1, Figura fig2)
        {
            return fig1.Power < fig2.Power;
        }
        public static bool operator >(Figura fig1, Figura fig2)
        {
            return fig1.Power > fig2.Power;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        // END OPERATORY
        public String GetPosString()
        {
            return ("[R" + this.Position.Row + ",C" + this.Position.Col + "]");
        }
        public String GetColorString()
        {
            if (this.Color == fColor.Black) return("Czarny");
            else return("Biały");
        }
        public void SetOnTable()
        {
            Uri resourceUri = new Uri(Icon, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var imageBrush = new ImageBrush
            {
                ImageSource = temp
            };

            this.szachownica.ButtonArray[this.Position.Row, this.Position.Col].Background = imageBrush;
            this.szachownica.ButtonArray[this.Position.Row, this.Position.Col].Tag = this.Id.ToString();
        }
        override public string ToString()
        {
            return("Figura '" + this.Name + "' [id:" + this.Id + "] o kolorze '" + this.GetColorString() + "' na pozycji " + this.GetPosString());
        }
        public abstract bool Move(int row, int col);

    }
}
