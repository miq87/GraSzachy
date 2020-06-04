using nsFigura;
using System.Collections;
using System.Collections.Generic;

namespace GraSzachy
{
    class FigureList : IEnumerable<Figura>
    {
        public List<Figura> Figury { get; set; }
        public IEnumerator<Figura> GetEnumerator()
        {
            return Figury.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
