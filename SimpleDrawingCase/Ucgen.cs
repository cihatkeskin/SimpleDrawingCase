using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleDrawingCase
{
    [Serializable]
    internal class Ucgen : Sekil
    {
        int mesafeX;
        int mesafeY;
        int cizimAlaniWidth;
        int cizimAlaniHeight;
        public Brush FircaRenk
        {
            get { return fircaRenk; }
            set { fircaRenk = value; }

        }
        Point[] UcgenPoint = new Point[3];
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
        public int MesafeX
        {
            get { return mesafeX; }
            set { mesafeX = value; }

        }
        public int MesafeY
        {
            get { return mesafeY; }
            set { mesafeY = value; }

        }
        public int CizimAlaniWidth
        {
            get { return cizimAlaniWidth; }
            set { cizimAlaniWidth = value; }

        }
        public int CizimAlaniHeight
        {
            get { return cizimAlaniHeight; }
            set { cizimAlaniHeight = value; }

        }

        private void UcgenPointBul()
        {

            if (UcgenPoint[1].X > 0 && UcgenPoint[0].Y > 0 && UcgenPoint[2].Y < cizimAlaniHeight && UcgenPoint[2].X < cizimAlaniWidth)
            {
                UcgenPoint[0].X = x;
                UcgenPoint[0].Y = y - (2 * mesafeY);
                UcgenPoint[1].X = x - mesafeX;
                UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                UcgenPoint[2].Y = UcgenPoint[0].Y + 3 * mesafeY;
                UcgenPoint[1].Y = UcgenPoint[2].Y;

            }
            else if (y - (2 * mesafeY) > 0 && x - mesafeX > 0 && x + mesafeX < cizimAlaniWidth && y + mesafeY < cizimAlaniHeight)
            {
                UcgenPoint[0].X = x;
                UcgenPoint[0].Y = y - (2 * mesafeY);
                UcgenPoint[1].X = x - mesafeX;
                UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                UcgenPoint[2].Y = UcgenPoint[0].Y + 3 * mesafeY;
                UcgenPoint[1].Y = UcgenPoint[2].Y;
            }
            else
            {
                if (UcgenPoint[1].X <= 0 && UcgenPoint[0].Y < 0)
                {
                    UcgenPoint[1].X = 0;
                }
                if (UcgenPoint[0].Y <= 0 && UcgenPoint[1].X < 0)
                {
                    UcgenPoint[0].Y = 0;
                }
                if (x - mesafeX > 0 && UcgenPoint[0].Y > 0 && UcgenPoint[2].X < cizimAlaniWidth && UcgenPoint[2].Y < cizimAlaniHeight)
                {
                    UcgenPoint[1].X = x - mesafeX;
                }
                if (y - (2 * mesafeY) > 0 && x - mesafeX > 0 && UcgenPoint[2].X < cizimAlaniWidth && UcgenPoint[2].Y < cizimAlaniHeight)
                {
                    UcgenPoint[0].Y = y - (2 * mesafeY);
                }
                if (UcgenPoint[0].Y != 0 && UcgenPoint[1].X > 0 && UcgenPoint[0].Y < 0 && UcgenPoint[2].X < cizimAlaniWidth && UcgenPoint[2].Y < cizimAlaniHeight)
                {
                    UcgenPoint[1].Y = UcgenPoint[0].Y + 3 * mesafeY;
                }
                if (UcgenPoint[2].X > cizimAlaniWidth)
                {
                    UcgenPoint[2].X = cizimAlaniWidth;
                }
                if (UcgenPoint[2].X <= cizimAlaniWidth && UcgenPoint[0].Y < 0 && UcgenPoint[1].Y < cizimAlaniHeight && UcgenPoint[2].X < cizimAlaniWidth)
                {
                    UcgenPoint[2].X = 2 * UcgenPoint[0].X - UcgenPoint[1].X;
                }

                UcgenPoint[0].X = x;
                //UcgenPoint[2].Y = UcgenPoint[1].Y;
                UcgenPoint[1].Y = UcgenPoint[2].Y;

            }

        }
        public bool Dahil_mi(int tıkX, int tıkY)
        {
            int m, c;
            Boolean icerde = false;
            if (tıkY < UcgenPoint[0].Y || tıkY > UcgenPoint[1].Y || tıkX < UcgenPoint[1].X || tıkX > UcgenPoint[2].X)
            {
                icerde = false;
            }
            else
            {
                if (tıkX <= UcgenPoint[0].X && tıkY <= UcgenPoint[1].Y)
                {
                    m = (UcgenPoint[0].Y - UcgenPoint[1].Y) / (UcgenPoint[0].X - UcgenPoint[1].X);
                    c = UcgenPoint[0].Y - m * UcgenPoint[0].X;
                    if (tıkY >= m * tıkX + c)
                    {
                        icerde = true;
                        return icerde;
                    }
                    else
                    {
                        icerde = false;
                        return icerde;
                    }
                }
                else if (tıkX >= UcgenPoint[0].X && tıkY <= UcgenPoint[2].Y)
                {
                    m = (UcgenPoint[0].Y - UcgenPoint[2].Y) / (UcgenPoint[0].X - UcgenPoint[2].X);
                    c = UcgenPoint[0].Y - m * UcgenPoint[0].X;
                    if (tıkY >= m * tıkX + c)
                    {
                        icerde = true;
                        return icerde;
                    }
                    else
                    {
                        icerde = false;
                        return icerde;
                    }

                }

            }

            return icerde;
        }
        public override void Ciz(Graphics cizimAraci)
        {
            UcgenPointBul();
            if (fircaRenk == null)
            {
                fircaRenk = new SolidBrush(Color.Black);
            }
            cizimAraci.FillPolygon(fircaRenk, UcgenPoint);

        }
    }
}
