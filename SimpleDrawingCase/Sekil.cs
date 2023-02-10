using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleDrawingCase
{
    [Serializable]
    internal abstract class Sekil
    {
        protected int x;
        protected int y;
        protected Brush fircaRenk;

        public abstract void Ciz(Graphics cizimAraci);
    }
}
