using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleDrawingCase
{
    [Serializable]
    internal class Dikdortgen : Sekil
    {
        private int width = 0;
        private int height = 0;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Brush FircaRenk
        {
            get { return fircaRenk; }
            set { fircaRenk = value; }
        }

        public bool dahilMi(int tıkX, int tıkY)// mouse tıklamasından gelen x-y değerlerinin dikdörtgen içersinde olup olmamasına bakar.
        {
            if (tıkX >= x && tıkY >= y && tıkX <= x + width && tıkY <= y + height)
            {
                return true;
            }

            else
                return false;

        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (fircaRenk == null)
            {
                fircaRenk = new SolidBrush(Color.Black);
            }

            cizimAraci.FillRectangle(fircaRenk, x, y, width, height);

        }
    }
}
