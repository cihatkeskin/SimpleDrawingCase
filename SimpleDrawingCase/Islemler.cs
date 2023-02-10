using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDrawingCase
{
    internal class Islemler
    {
        protected int x;
        protected int y;
        protected int sekilOncekiX;
        protected int sekilOncekiY;

        public virtual void Tasima(int x, int y, int mesafeX, int mesafeY)
        {
            x = sekilOncekiX + mesafeX;
            y = sekilOncekiY + mesafeY;
            this.x = x;
            this.y = y;

        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int SekilOncekiX

        {
            get { return sekilOncekiX; }
            set { sekilOncekiX = value; }
        }
        public int SekilOncekiY
        {
            get { return sekilOncekiY; }
            set { sekilOncekiY = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
