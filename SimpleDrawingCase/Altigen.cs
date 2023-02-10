using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace SimpleDrawingCase
{
    [Serializable]
    internal class Altigen : Sekil
    {
        int mesafeX;
        int mesafeY;
        public Brush FircaRenk
        {
            get { return fircaRenk; }
            set { fircaRenk = value; }

        }
        public PointF[] shape = new PointF[6];
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

        private void CokgenPointBul()
        {


            var r = (mesafeX + mesafeY) / 2; // px radius 
            /*if (mesafeX > mesafeY)
            {
                r = mesafeX;
            }
            else
                r = mesafeY;*/
            //Create 6 points
            for (int a = 0; a < 6; a++)
            {
                shape[a] = new PointF(
                    x + r * (float)Math.Cos(a * 60 * Math.PI / 180f),
                    y + r * (float)Math.Sin(a * 60 * Math.PI / 180f));
            }

        }

        // tıklanan noktanınn poligon içersinde olup olmadığını kontrol edip boolen türünde bir dönüt sağlar
        public bool PointInPolygon(Vector2 p, PointF[] poly)
        {
            float m, c, solKx, sagKx, ustKy, altKy;
            solKx = poly[3].X;
            sagKx = poly[0].X;
            ustKy = poly[5].Y;
            altKy = poly[1].Y;
            Boolean icerde = false;
            if (p.X < solKx || p.X > sagKx || p.Y < ustKy || p.Y > altKy)
            {
                icerde = false;
            }
            else if (p.X <= poly[1].X && p.X >= poly[2].X && p.Y >= poly[5].Y && p.Y <= poly[1].Y)
            {
                icerde = true;
                return icerde;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5 && (poly[0].X >= p.X) && (p.X >= poly[5].X) && (poly[0].Y >= p.Y) && (poly[5].Y <= p.Y))
                    {
                        m = (poly[i].Y - poly[0].Y) / (poly[i].X - poly[0].X);
                        c = poly[0].Y - m * (poly[0].X);
                        if (p.Y >= m * (p.X) + c) // for döngüsünde sınır ihlalinden kurtulmak için 4. bölge ayrı yazıldı.
                        {
                            icerde = true;
                            return icerde;
                        }
                    }
                    else if (i == 5)
                    {
                        return icerde;
                    }
                    else
                    {
                        m = (poly[i + 1].Y - poly[i].Y) / (poly[i + 1].X - poly[i].X);
                        c = poly[i].Y - m * (poly[i].X);
                        if ((poly[0].X >= p.X) && (p.X >= poly[1].X) && (poly[0].Y <= p.Y) && (poly[1].Y >= p.Y) && i == 0)
                        {
                            if ((p.Y <= m * (p.X) + c)) // altıgenimizin başlangıç noktasındaki kücük kareyi temsil eden (1 bölge) iki nokta arasında 
                                                        // kurulan denklemi baz alarak seçilen noktanın denklem içersinde olup olmadığını kontrol eder
                            {
                                icerde = true;
                                return icerde;
                            }

                        }
                        else if ((p.X >= poly[3].X) && (p.X <= poly[2].X) && (p.Y >= poly[3].Y) && (poly[2].Y >= p.Y) && i == 2)
                        {
                            if ((p.Y <= m * (p.X) + c)) // aynı durum 2.bölge
                            {
                                icerde = true;
                                return icerde;
                            }
                        }
                        else if ((p.X >= poly[3].X) && (p.X <= poly[4].X) && (p.Y <= poly[3].Y) && (poly[4].Y <= p.Y) && i == 3)
                        {
                            if ((p.Y >= m * (p.X) + c)) // 3.bölge
                            {
                                icerde = true;
                                return icerde;
                            }
                        }

                    }
                }
            }
            return icerde;
        }
        public override void Ciz(Graphics cizimAraci)
        {
            CokgenPointBul();
            if (fircaRenk == null)
            {
                fircaRenk = new SolidBrush(Color.Black);
            }

            cizimAraci.FillPolygon(fircaRenk, shape);
        }
    }
}
