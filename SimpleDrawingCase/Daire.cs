using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleDrawingCase
{
    [Serializable]
    internal class Daire : Sekil
    {
        private float yaricap = 0;
        public Point merkezNokta;
        public Brush FircaRenk
        {
            get { return fircaRenk; }
            set { fircaRenk = value; }
        }
        public float Yaricap
        {
            get
            {
                return yaricap;
            }
            set
            {
                yaricap = value;
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

        public bool dahilMi(int tıkX, int tıkY)
        {                                                                                                          // seçilen noktanın merkez noktayla olan uzaklığı
            double nokta_uzaklık;                                                                                  // yarıçaptan küçük ise nokta daire içersindedir.
            nokta_uzaklık = Math.Sqrt(Math.Pow((tıkX - merkezNokta.X), 2) + Math.Pow((tıkY - merkezNokta.Y), 2));

            if (nokta_uzaklık > Math.Abs(yaricap))
            {
                return false;
            }
            else
                return true;
        }
        public override void Ciz(Graphics cizimAraci)
        {
            if (fircaRenk == null)
            {
                fircaRenk = new SolidBrush(Color.Black);
            }
            cizimAraci.FillEllipse(fircaRenk, x, y, 2 * yaricap, 2 * yaricap);
        }
    }
}
