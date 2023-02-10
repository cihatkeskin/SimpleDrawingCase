using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace SimpleDrawingCase
{
    public partial class Form1 : Form
    {
        bool b_dikdortgen = false;
        bool b_daire = false;
        bool b_ucgen = false;
        bool b_altıgen = false;
        bool b_sec = false;
        bool b_isMove_dik = false;
        bool b_isMove_altıgen = false;
        bool b_isMove_daire = false;
        bool b_isMove_ucgen = false;

        bool isDraw = false;
        int ilkX, ilkY, sonY, sonX, mesafeX, mesafeY = 0;
        int sekilSirasiDaire;
        int sekilSirasiDikdortgen;
        int sekilSirasiUcgen;
        int sekilSirasiAltigen;

        Pen kalem = new Pen(Color.Black);

        Graphics CizimAlani;

        Islemler Islemler = new Islemler();

        List<Dikdortgen> dikdortgenler = new List<Dikdortgen>();
        List<Ucgen> ucgenler = new List<Ucgen>();
        List<Daire> daireler = new List<Daire>();
        List<Altigen> altigenler = new List<Altigen>();

        Dikdortgen dikdortgen = new Dikdortgen();
        Daire daire = new Daire();
        Ucgen ucgen = new Ucgen();
        Altigen altigen = new Altigen();

        Brush firca = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
        }

        public void Renk_sec(string renk)
        {
            if (renk == "siyah")
            {
                BtnSiyah.FlatStyle = FlatStyle.Flat;
                BtnSiyah.FlatAppearance.BorderSize = 3;
                BtnSiyah.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 1;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 1;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 1;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 1;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 1;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 1;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 1;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 1;
            }
            else if (renk == "kirmizi")
            {
                BtnKirmizi.FlatStyle = FlatStyle.Flat;
                BtnKirmizi.FlatAppearance.BorderSize = 3;
                BtnKirmizi.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "mavi")
            {
                BtnMavi.FlatStyle = FlatStyle.Flat;
                BtnMavi.FlatAppearance.BorderSize = 3;
                BtnMavi.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "yesil")
            {
                BtnYesil.FlatStyle = FlatStyle.Flat;
                BtnYesil.FlatAppearance.BorderSize = 3;
                BtnYesil.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;
            }

            else if (renk == "turuncu")
            {
                BtnTuruncu.FlatStyle = FlatStyle.Flat;
                BtnTuruncu.FlatAppearance.BorderSize = 3;
                BtnTuruncu.FlatAppearance.BorderColor = Color.DarkGray;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "sari")
            {
                BtnSari.FlatStyle = FlatStyle.Flat;
                BtnSari.FlatAppearance.BorderSize = 3;
                BtnSari.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "mor")
            {
                BtnMor.FlatStyle = FlatStyle.Flat;
                BtnMor.FlatAppearance.BorderSize = 3;
                BtnMor.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "kahve")
            {
                BtnKahve.FlatStyle = FlatStyle.Flat;
                BtnKahve.FlatAppearance.BorderSize = 3;
                BtnKahve.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnBeyaz.FlatAppearance.BorderColor = Color.Gray;
                BtnBeyaz.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
            else if (renk == "beyaz")
            {
                BtnBeyaz.FlatStyle = FlatStyle.Flat;
                BtnBeyaz.FlatAppearance.BorderSize = 3;
                BtnBeyaz.FlatAppearance.BorderColor = Color.DarkGray;

                BtnTuruncu.FlatAppearance.BorderColor = Color.Gray;
                BtnTuruncu.FlatAppearance.BorderSize = 2;

                BtnSiyah.FlatAppearance.BorderColor = Color.Gray;
                BtnSiyah.FlatAppearance.BorderSize = 2;

                BtnSari.FlatAppearance.BorderColor = Color.Gray;
                BtnSari.FlatAppearance.BorderSize = 2;

                BtnMor.FlatAppearance.BorderColor = Color.Gray;
                BtnMor.FlatAppearance.BorderSize = 2;

                BtnKahve.FlatAppearance.BorderColor = Color.Gray;
                BtnKahve.FlatAppearance.BorderSize = 2;

                BtnKirmizi.FlatAppearance.BorderColor = Color.Gray;
                BtnKirmizi.FlatAppearance.BorderSize = 2;

                BtnMavi.FlatAppearance.BorderColor = Color.Gray;
                BtnMavi.FlatAppearance.BorderSize = 2;

                BtnYesil.FlatAppearance.BorderColor = Color.Gray;
                BtnYesil.FlatAppearance.BorderSize = 2;
            }
        }
        public void RenkVer()
        {
            if (b_sec && sekilSirasiDikdortgen != -1)
            {
                dikdortgenler[sekilSirasiDikdortgen].FircaRenk = firca;
            }
            else if (b_sec && sekilSirasiDaire != -1)
            {
                daireler[sekilSirasiDaire].FircaRenk = firca;
            }
            else if (b_sec && sekilSirasiUcgen != -1)
            {
                ucgenler[sekilSirasiUcgen].FircaRenk = firca;
            }
            else if (b_sec && sekilSirasiAltigen != -1)
            {
                altigenler[sekilSirasiAltigen].FircaRenk = firca;
            }

            Panel.Refresh();
        }

        public void SekilRenkBul(Brush sekil)
        {

            if (((SolidBrush)sekil).Color.Name == "Black")
            {
                BtnSiyah.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Red")
            {
                BtnKirmizi.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Yellow")
            {
                BtnSari.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Orange")
            {
                BtnTuruncu.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "White")
            {
                BtnBeyaz.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Green")
            {
                BtnYesil.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Blue")
            {
                BtnMavi.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Brown")
            {
                BtnKahve.PerformClick();
            }

            if (((SolidBrush)sekil).Color.Name == "Purple")
            {
                BtnMor.PerformClick();
            }
        }

        private void ClickDikdortgen(object sender, EventArgs e)
        {
            dikdortgen = new Dikdortgen();

            BtnDikdortgen.FlatStyle = FlatStyle.Flat;
            BtnDikdortgen.FlatAppearance.BorderSize = 3;
            BtnDikdortgen.FlatAppearance.BorderColor = Color.DarkGray;

            BtnDaire.FlatAppearance.BorderColor = Color.Gray;
            BtnDaire.FlatAppearance.BorderSize = 2;

            BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
            BtnAltigen.FlatAppearance.BorderSize = 2;

            BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
            BtnUcgen.FlatAppearance.BorderSize = 2;

            b_altıgen = false;
            b_dikdortgen = true;
            b_daire = false;
            b_ucgen = false;
            b_sec = false;
        }

        private void ClickDaire(object sender, EventArgs e)
        {
            daire = new Daire();

            BtnDaire.FlatStyle = FlatStyle.Flat;
            BtnDaire.FlatAppearance.BorderSize = 3;
            BtnDaire.FlatAppearance.BorderColor = Color.DarkGray;

            BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
            BtnDikdortgen.FlatAppearance.BorderSize = 2;

            BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
            BtnAltigen.FlatAppearance.BorderSize = 2;

            BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
            BtnUcgen.FlatAppearance.BorderSize = 2;

            b_altıgen = false;
            b_dikdortgen = false;
            b_daire = true;
            b_ucgen = false;
            b_sec = false;
        }

        private void ClickUcgen(object sender, EventArgs e)
        {
            ucgen = new Ucgen();

            BtnUcgen.FlatStyle = FlatStyle.Flat;
            BtnUcgen.FlatAppearance.BorderSize = 3;
            BtnUcgen.FlatAppearance.BorderColor = Color.DarkGray;

            BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
            BtnDikdortgen.FlatAppearance.BorderSize = 2;

            BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
            BtnAltigen.FlatAppearance.BorderSize = 2;

            BtnDaire.FlatAppearance.BorderColor = Color.Gray;
            BtnDaire.FlatAppearance.BorderSize = 2;

            b_altıgen = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = true;
            b_sec = false;
        }

        private void ClickAltigen(object sender, EventArgs e)
        {
            altigen = new Altigen();

            BtnAltigen.FlatStyle = FlatStyle.Flat;
            BtnAltigen.FlatAppearance.BorderSize = 3;
            BtnAltigen.FlatAppearance.BorderColor = Color.DarkGray;

            BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
            BtnDikdortgen.FlatAppearance.BorderSize = 2;

            BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
            BtnUcgen.FlatAppearance.BorderSize = 2;

            BtnDaire.FlatAppearance.BorderColor = Color.Gray;
            BtnDaire.FlatAppearance.BorderSize = 2;

            b_altıgen = true;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_sec = false;
        }

        private void ClickKirmizi(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Red);
            Renk_sec("kirmizi");
            RenkVer();
        }

        private void ClickMavi(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Blue);
            Renk_sec("mavi");
            RenkVer();
        }

        private void ClickYesil(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Green);
            Renk_sec("yesil");
            RenkVer();
        }

        private void ClickTuruncu(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Orange);
            Renk_sec("turuncu");
            RenkVer();
        }

        private void ClickSiyah(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Black);
            Renk_sec("siyah");
            RenkVer();
        }

        private void ClickSari(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Yellow);
            Renk_sec("sari");
            RenkVer();
        }

        private void ClickMor(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Purple);
            Renk_sec("mor");
            RenkVer();
        }

        private void ClickKahve(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.Brown);
            Renk_sec("kahverengi");
            RenkVer();
        }

        private void ClickBeyaz(object sender, EventArgs e)
        {
            firca = new SolidBrush(Color.White);
            Renk_sec("beyaz");
            RenkVer();
        }

        private void ClickSecim(object sender, EventArgs e)
        {
            b_sec = true;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;

            BtnSecim.FlatStyle = FlatStyle.Flat;
            BtnSecim.FlatAppearance.BorderSize = 3;
            BtnSecim.FlatAppearance.BorderColor = Color.DarkGray;

            BtnSil.FlatAppearance.BorderColor = Color.Gray;
            BtnSil.FlatAppearance.BorderSize = 2;

            BtnTemizle.FlatAppearance.BorderColor = Color.Gray;
            BtnTemizle.FlatAppearance.BorderSize = 2;
        }

        private void ClickSil(object sender, EventArgs e)
        {
            if (b_sec)
            {
                altigenler.Remove(altigen);
                daireler.Remove(daire);
                dikdortgenler.Remove(dikdortgen);
                ucgenler.Remove(ucgen);
                if (true)
                {

                    /*for (int i = 0; i < sekiller.Count; i++)
                    {
                        Daire temp = (Daire)sekiller[i];
                        if (temp.dahilMi(sonX, sonY))
                        {
                            sekiller.Remove(temp);
                            temp.X = 0;
                            temp.Y = 0;
                            temp.Yaricap = 0;
                            Panel.Refresh();
                        }
                    }*/
                }
            }

            BtnSil.FlatStyle = FlatStyle.Flat;
            BtnSil.FlatAppearance.BorderSize = 3;
            BtnSil.FlatAppearance.BorderColor = Color.DarkGray;

            BtnSecim.FlatAppearance.BorderColor = Color.Gray;
            BtnSecim.FlatAppearance.BorderSize = 2;

            BtnTemizle.FlatAppearance.BorderColor = Color.Gray;
            BtnTemizle.FlatAppearance.BorderSize = 2;

            b_sec = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;
            Panel.Refresh();
        }

        private void ClickTemizle(object sender, EventArgs e)
        {
            Panel.Refresh();

            dikdortgenler.Clear();
            daireler.Clear();
            ucgenler.Clear();
            altigenler.Clear();

            b_sec = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_altıgen = false;

            Panel.Refresh();

            BtnTemizle.FlatStyle = FlatStyle.Flat;
            BtnTemizle.FlatAppearance.BorderSize = 3;
            BtnTemizle.FlatAppearance.BorderColor = Color.DarkGray;

            BtnSecim.FlatAppearance.BorderColor = Color.Gray;
            BtnSecim.FlatAppearance.BorderSize = 2;

            BtnSil.FlatAppearance.BorderColor = Color.Gray;
            BtnSil.FlatAppearance.BorderSize = 2;
        }

        private void ClickDosyaAc(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = @"Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            DialogResult result = dialog.ShowDialog();
            IEnumerable<String> objeler = new List<String>();
            if (result == DialogResult.OK)
                objeler = File.ReadLines(dialog.FileName);
            foreach (String obje in objeler)
            {
                string[] temp = obje.Split(' ');
                if (temp[0] == "Daire")
                {
                    daire = new Daire();
                    daire.X = Convert.ToInt32(temp[1]);
                    daire.Y = Convert.ToInt32(temp[2]);
                    daire.Yaricap = Convert.ToInt32(temp[3]);
                    daire.merkezNokta = new Point(Convert.ToInt32(temp[4]), Convert.ToInt32(temp[5]));
                    daire.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[6])));
                    daireler.Add(daire);
                    daire = new Daire();
                }
                else if (temp[0] == "Dikdortgen")
                {
                    dikdortgen = new Dikdortgen();
                    dikdortgen.X = Convert.ToInt32(temp[1]);
                    dikdortgen.Y = Convert.ToInt32(temp[2]);
                    dikdortgen.Width = Convert.ToInt32(temp[3]);
                    dikdortgen.Height = Convert.ToInt32(temp[4]);
                    dikdortgen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[5])));
                    dikdortgenler.Add(dikdortgen);
                    dikdortgen = new Dikdortgen();
                }
                else if (temp[0] == "Ucgen")
                {
                    ucgen = new Ucgen();
                    ucgen.X = Convert.ToInt32(temp[1]);
                    ucgen.Y = Convert.ToInt32(temp[2]);
                    ucgen.MesafeX = Convert.ToInt32(temp[3]);
                    ucgen.MesafeY = Convert.ToInt32(temp[4]);
                    ucgen.CizimAlaniWidth = Convert.ToInt32(temp[5]);
                    ucgen.CizimAlaniHeight = Convert.ToInt32(temp[6]);
                    ucgen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[7])));
                    ucgenler.Add(ucgen);
                    ucgen = new Ucgen();
                }
                else if (temp[0] == "Altigen")
                {
                    altigen = new Altigen();
                    altigen.X = Convert.ToInt32(temp[1]);
                    altigen.Y = Convert.ToInt32(temp[2]);
                    altigen.MesafeX = Convert.ToInt32(temp[3]);
                    altigen.MesafeY = Convert.ToInt32(temp[4]);
                    altigen.FircaRenk = new SolidBrush(Color.FromArgb(Convert.ToInt32(temp[5])));
                    altigenler.Add(altigen);
                    altigen = new Altigen();
                }
                Panel.Refresh();
            }
        }

        private void ClickKaydet(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = @"Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            kaydet.InitialDirectory = "D://";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                StreamWriter dosya = new StreamWriter(kaydet.FileName);
                foreach (Sekil item in daireler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in dikdortgenler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in ucgenler)
                {
                    dosya.WriteLine(item);
                }
                foreach (Sekil item in altigenler)
                {
                    dosya.WriteLine(item);
                }

                dosya.Flush();
                dosya.Close();
            }
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            int CizimAlani_x = Panel.Size.Width;
            int CizimAlani_y = Panel.Size.Height;

            if (b_dikdortgen)
            {
                dikdortgen.FircaRenk = firca;
            }
            else if (b_daire)
            {
                daire.FircaRenk = firca;
            }
            else if (b_altıgen)
            {
                altigen.FircaRenk = firca;
            }
            else if (b_ucgen)
            {
                ucgen.FircaRenk = firca;
            }

            //CizimAlani = Panel.CreateGraphics(); //Graphics for panel
            CizimAlani = e.Graphics;
            
            foreach (Dikdortgen dikdortgen in dikdortgenler)
            {
                dikdortgen.Ciz(CizimAlani);
            }

            foreach (Ucgen ucgen in ucgenler)
            {
                ucgen.Ciz(CizimAlani);
            }

            if (b_dikdortgen && isDraw)
            {
                dikdortgen.Ciz(CizimAlani);
            }

            if (b_daire && isDraw)
            {
                daire.Ciz(CizimAlani);

            }
            foreach (Sekil sekil in daireler)
            {
                sekil.Ciz(CizimAlani);
            }
            if (b_ucgen && isDraw)
            {
                ucgen.Ciz(CizimAlani);

            }
            if (b_altıgen && isDraw)
            {
                altigen.Ciz(CizimAlani);

            }
            foreach (Sekil altigen_sekil in altigenler)
            {
                altigen_sekil.Ciz(CizimAlani);
            }
        }

        private void MouseDownPanel(object sender, MouseEventArgs e)
        {
            isDraw = true;
            ilkX = e.X;
            ilkY = e.Y;
            Vector2 p;
            Vector2[] shape = new Vector2[6];
            p.X = e.X; 
            p.Y = e.Y;


            if (b_dikdortgen)
            {
                dikdortgen.X = ilkX;
                dikdortgen.Y = ilkY;
                Panel.Refresh();
            }
            if (b_daire)
            {
                daire.X = ilkX;
                daire.Y = ilkY;
                daire.merkezNokta.X = ilkX;
                daire.merkezNokta.Y = ilkY;
            }
            if (b_ucgen)
            {
                ucgen.X = ilkX;
                ucgen.Y = ilkY;
                Invalidate();
            }
            if (b_altıgen)
            {
                for (int i = 0; i < 6; i++)
                {
                    shape[i].X = altigen.shape[i].X;
                    shape[i].Y = altigen.shape[i].Y;
                }
                altigen.X = ilkX;
                altigen.Y = ilkY;

                Invalidate();
            }
            if (b_sec)
            {
                for (int i = 0; i < dikdortgenler.Count; i++)
                {
                    Dikdortgen temp = dikdortgenler[i];
                    if (temp.dahilMi(ilkX, ilkY))
                    {
                        dikdortgen = temp;
                        sekilSirasiDikdortgen = i;
                        sekilSirasiDaire = -1;
                        sekilSirasiUcgen = -1;
                        sekilSirasiAltigen = -1;
                        Islemler.SekilOncekiX = dikdortgen.X;
                        Islemler.SekilOncekiY = dikdortgen.Y;

                        b_isMove_altıgen = false;
                        b_isMove_daire = false;
                        b_isMove_ucgen = false;
                        b_isMove_dik = true;

                        BtnDikdortgen.FlatStyle = FlatStyle.Flat;
                        BtnDikdortgen.FlatAppearance.BorderSize = 3;
                        BtnDikdortgen.FlatAppearance.BorderColor = Color.DarkGray;

                        BtnDaire.FlatAppearance.BorderColor = Color.Gray;
                        BtnDaire.FlatAppearance.BorderSize = 2;

                        BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
                        BtnAltigen.FlatAppearance.BorderSize = 2;

                        BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnUcgen.FlatAppearance.BorderSize = 2;

                        SekilRenkBul(dikdortgen.FircaRenk);

                    }
                }
                for (int i = 0; i < altigenler.Count; i++)
                {
                    Altigen altigen_sekil = altigenler[i];
                    if (altigen_sekil.PointInPolygon(p, altigen_sekil.shape))
                    {

                        altigen = altigen_sekil;
                        sekilSirasiDikdortgen = -1;
                        sekilSirasiDaire = -1;
                        sekilSirasiUcgen = -1;
                        sekilSirasiAltigen = i;
                        Islemler.SekilOncekiX = altigen.X;
                        Islemler.SekilOncekiY = altigen.Y;

                        b_isMove_altıgen = true;
                        b_isMove_daire = false;
                        b_isMove_ucgen = false;
                        b_isMove_dik = false;
                        SekilRenkBul(altigen.FircaRenk);

                        BtnAltigen.FlatStyle = FlatStyle.Flat;
                        BtnAltigen.FlatAppearance.BorderSize = 3;
                        BtnAltigen.FlatAppearance.BorderColor = Color.DarkGray;

                        BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnDikdortgen.FlatAppearance.BorderSize = 2;

                        BtnDaire.FlatAppearance.BorderColor = Color.Gray;
                        BtnDaire.FlatAppearance.BorderSize = 2;

                        BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnUcgen.FlatAppearance.BorderSize = 2;
                    }
                }
                for (int i = 0; i < daireler.Count; i++)
                {
                    Daire temp = (Daire)daireler[i];
                    if (temp.dahilMi(ilkX, ilkY))
                    {
                        sekilSirasiDaire = i;
                        sekilSirasiDikdortgen = -1;
                        sekilSirasiUcgen = -1;
                        sekilSirasiAltigen = -1;
                        daire = temp;
                        Islemler.SekilOncekiX = daire.X;
                        Islemler.SekilOncekiY = daire.Y;
                        b_isMove_daire = true;
                        b_isMove_ucgen = false;
                        b_isMove_altıgen = false;
                        b_isMove_dik = false;

                        SekilRenkBul(daire.FircaRenk);

                        BtnDaire.FlatStyle = FlatStyle.Flat;
                        BtnDaire.FlatAppearance.BorderSize = 3;
                        BtnDaire.FlatAppearance.BorderColor = Color.DarkGray;

                        BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnDikdortgen.FlatAppearance.BorderSize = 2;

                        BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
                        BtnAltigen.FlatAppearance.BorderSize = 2;

                        BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnUcgen.FlatAppearance.BorderSize = 2;
                    }
                }
                for (int i = 0; i < ucgenler.Count; i++)
                {
                    Ucgen temp = (Ucgen)ucgenler[i];
                    if (temp.Dahil_mi(ilkX, ilkY))
                    {
                        sekilSirasiDaire = -1;
                        sekilSirasiDikdortgen = -1;
                        sekilSirasiUcgen = i;
                        sekilSirasiAltigen = -1;
                        ucgen = temp;
                        Islemler.SekilOncekiX = ucgen.X;
                        Islemler.SekilOncekiY = ucgen.Y;

                        b_isMove_ucgen = true;
                        b_isMove_daire = false;
                        b_isMove_altıgen = false;
                        b_isMove_dik = false;

                        SekilRenkBul(ucgen.FircaRenk);

                        BtnUcgen.FlatStyle = FlatStyle.Flat;
                        BtnUcgen.FlatAppearance.BorderSize = 3;
                        BtnUcgen.FlatAppearance.BorderColor = Color.DarkGray;

                        BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
                        BtnDikdortgen.FlatAppearance.BorderSize = 2;

                        BtnDaire.FlatAppearance.BorderColor = Color.Gray;
                        BtnDaire.FlatAppearance.BorderSize = 2;

                        BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
                        BtnAltigen.FlatAppearance.BorderSize = 2;
                    }
                }
            }
        }

        private void MouseMovePanel(object sender, MouseEventArgs e)
        {
            //Point p = e.Location;
            label1.Text = $"Mouse Location(X, Y):  {e.X.ToString()}, {e.Y.ToString()}";//mouse lokasyonunu belirtir.
            mesafeX = e.X - ilkX;
            mesafeY = e.Y - ilkY;
            if (isDraw && b_dikdortgen)
            {
                if (dikdortgen.X > 0 && dikdortgen.Y > 0 && (dikdortgen.X + dikdortgen.Width) < Panel.Size.Width
                                                         && (dikdortgen.Y + dikdortgen.Height) < Panel.Size.Height)
                {

                    dikdortgen.X = ilkX - mesafeX;
                    dikdortgen.Y = ilkY - mesafeY;
                    dikdortgen.Width = 2 * mesafeX + mesafeX * (7 / 8);//karenin sol üsttende genişlemesini absorbe edebilmek için 2 ile çarp. 
                    dikdortgen.Height = 2 * mesafeY;

                }

                else if ((dikdortgen.X + dikdortgen.Width) >= Panel.Size.Width)
                {
                    //-------  soldan ve yukaridan asim olursa  -------//

                    if (dikdortgen.X < 0)
                    {
                        dikdortgen.X = 0;
                        sonX = mesafeX; sonY = mesafeY;
                        dikdortgen.Width = sonX;
                        dikdortgen.Height = sonY;
                    }

                    if (dikdortgen.Y < 0)
                    {
                        dikdortgen.Y = 0;
                        sonX = mesafeX; sonY = mesafeY;
                        dikdortgen.Width = sonX;
                        dikdortgen.Height = sonY;
                    }
                    // -------sagdan ve asagıdan asim olursa  -------//
                    if ((dikdortgen.X + dikdortgen.Width) >= Panel.Size.Width)
                    {
                        dikdortgen.X = Panel.Size.Width - dikdortgen.Width;

                    }
                    if ((dikdortgen.Y + dikdortgen.Height) >= Panel.Height)
                    {
                        dikdortgen.Y = Panel.Size.Height - dikdortgen.Height;
                    }

                }

                Panel.Refresh();
            }
            if (isDraw && b_daire)
            {
                if ((mesafeX > 0) && (mesafeY > 0) && (ilkX + daire.Yaricap + 2 < Panel.Size.Width) && (daire.Yaricap + ilkY < Panel.Size.Height)
                    && (daire.X != 0) && (daire.Y != 0) && ilkX + mesafeX < Panel.Size.Width && ilkY + mesafeY < Panel.Size.Height)
                {
                    daire.X = ilkX - mesafeX;
                    daire.Y = ilkY - mesafeY;
                }
                if (ilkX - daire.Yaricap < 0 && daire.Y != 0 && daire.Yaricap + ilkX < Panel.Size.Width && mesafeY + ilkY < Panel.Size.Height)
                {
                    daire.X = 0;
                }
                if (ilkY - daire.Yaricap < 0 && daire.X != 0 && daire.Yaricap + ilkX < Panel.Size.Width && mesafeY + ilkY < Panel.Size.Height)
                {
                    daire.Y = 0;
                }
                if (daire.Yaricap + ilkX >= Panel.Size.Width || daire.Yaricap + ilkY >= Panel.Size.Height)
                {
                    if (daire.Yaricap + ilkX >= Panel.Size.Width)
                    {
                        mesafeX = Panel.Size.Width - ilkX;
                    }
                    if (daire.Yaricap + ilkY >= Panel.Size.Height)
                    {
                        mesafeY = Panel.Size.Height - ilkY;
                    }
                }
                else
                {
                    if (mesafeY >= 0 && mesafeX >= 0 && daire.Yaricap + ilkX < Panel.Size.Width && daire.Yaricap + ilkY < Panel.Size.Height && daire.X != 0 && daire.Y != 0)
                    {
                        daire.Yaricap = (mesafeY + mesafeX) / 2 + 2;
                    }
                }

                Panel.Refresh();
            }
            if (isDraw && b_ucgen)
            {
                ucgen.CizimAlaniWidth = Panel.Size.Width;
                ucgen.CizimAlaniHeight = Panel.Size.Height;
                ucgen.MesafeX = mesafeX;
                ucgen.MesafeY = mesafeY;
                Panel.Refresh();
            }
            if (isDraw && b_altıgen)
            {
                if (altigen.shape[3].X >= 0 && altigen.shape[4].Y >= 0 && altigen.shape[0].X <= Panel.Width && altigen.shape[1].Y <= Panel.Height)
                {
                    altigen.MesafeX = mesafeX;
                    altigen.MesafeY = mesafeY;
                }

                Panel.Refresh();
            }
            if (b_sec && isDraw)
            {
                if (b_isMove_dik)
                {

                    Islemler.Tasima(dikdortgen.X, dikdortgen.Y, mesafeX, mesafeY);

                    dikdortgen.X = Islemler.X;
                    dikdortgen.Y = Islemler.Y;
                    if (dikdortgen.X < 0)
                    {
                        dikdortgen.X = 0;
                    }
                    if (dikdortgen.Y < 0)
                    {
                        dikdortgen.Y = 0;
                    }
                    if (dikdortgen.X + dikdortgen.Width >= Panel.Size.Width)
                    {
                        dikdortgen.X = Panel.Size.Width - dikdortgen.Width;
                    }
                    if (dikdortgen.Y + dikdortgen.Height >= Panel.Size.Height)
                    {
                        dikdortgen.Y = Panel.Size.Height - dikdortgen.Height;
                    }

                    Panel.Refresh();
                }

                if (b_isMove_altıgen)
                {
                    Islemler.Tasima(altigen.X, altigen.Y, mesafeX, mesafeY);

                    altigen.X = Islemler.X;
                    altigen.Y = Islemler.Y;
                    var altigenYaricap = (altigen.MesafeX + altigen.MesafeY) / 2;
                    if (altigen.X - (altigenYaricap) < 0)
                    {
                        altigen.X = altigenYaricap;
                    }
                    if (altigen.Y - (altigenYaricap) < 0)
                    {
                        altigen.Y = (int)(altigenYaricap * Math.Sin(1 * 60 * Math.PI / 180f));
                    }
                    if (altigen.X + altigenYaricap >= Panel.Size.Width)
                    {
                        altigen.X = Panel.Size.Width - altigenYaricap;
                    }
                    if (altigen.Y + (altigenYaricap) >= Panel.Size.Height)
                    {
                        altigen.Y = Panel.Size.Height - (int)(altigenYaricap * Math.Sin(2 * 60 * Math.PI / 180f));
                    }
                    Panel.Refresh();
                }

                if (b_isMove_daire)
                {
                    Islemler.Tasima(daire.X, daire.Y, mesafeX, mesafeY);

                    daire.X = Islemler.X;
                    daire.Y = Islemler.Y;
                    if (daire.X <= 0)
                    {
                        daire.X = 0;
                    }

                    if (daire.Y <= 0)
                    {
                        daire.Y = 0;
                    }
                    if (daire.Y + 2 * (daire.Yaricap) >= Panel.Size.Height)
                    {
                        daire.Y = Panel.Size.Height - 2 * (int)(daire.Yaricap);
                    }
                    if (daire.X + 2 * (daire.Yaricap) >= Panel.Size.Width)
                    {
                        daire.X = Panel.Size.Width - 2 * (int)(daire.Yaricap); ;
                    }
                    Panel.Refresh();
                }

                if (b_isMove_ucgen)
                {
                    Islemler.Tasima(ucgen.X, ucgen.Y, mesafeX, mesafeY);

                    ucgen.X = Islemler.X;
                    ucgen.Y = Islemler.Y;
                    if (ucgen.X - ucgen.MesafeX <= 0)
                    {
                        ucgen.X = ucgen.MesafeX;
                    }

                    if (ucgen.Y - 2 * ucgen.MesafeY <= 0)
                    {
                        ucgen.Y = 2 * ucgen.MesafeY;
                    }
                    if (ucgen.Y + ucgen.MesafeY > Panel.Size.Height)
                    {
                        ucgen.Y = Panel.Size.Height - ucgen.MesafeY;
                    }
                    if (ucgen.X + ucgen.MesafeX > Panel.Size.Width)
                    {
                        ucgen.X = Panel.Size.Width - ucgen.MesafeX - 3;
                    }

                    Panel.Refresh();

                }
            }
        }

        private void MouseUpPanel(object sender, MouseEventArgs e)
        {
            sonX = e.X;
            sonY = e.Y;
            mesafeX = e.X - ilkX;
            mesafeY = e.Y - ilkY;
            if (b_daire)
            {
                daireler.Add(daire);
                daire = new Daire();
                daire.FircaRenk = firca;
            }
            if (b_isMove_daire)
            {
                daire.merkezNokta.X = (int)(daire.X + daire.Yaricap);
                daire.merkezNokta.Y = (int)(daire.Y + daire.Yaricap);
                daireler[sekilSirasiDaire] = daire;
            }
            if (b_dikdortgen)
            {
                dikdortgenler.Add(dikdortgen);
                dikdortgen = new Dikdortgen();
                dikdortgen.FircaRenk = firca;
            }
            if (b_ucgen)
            {
                ucgenler.Add(ucgen);
                ucgen = new Ucgen();
            }
            if (b_altıgen)
            {
                altigenler.Add(altigen);
                altigen = new Altigen();
            }

            b_isMove_dik = false;
            b_isMove_daire = false;
            b_isMove_altıgen = false;
            isDraw = false;
            Panel.Refresh();
        }
        private void BtnUcgen_Click(object sender, EventArgs e)
        {
            ucgen = new Ucgen();

            BtnUcgen.FlatStyle = FlatStyle.Flat;
            BtnUcgen.FlatAppearance.BorderSize = 3;
            BtnUcgen.FlatAppearance.BorderColor = Color.DarkGray;
            BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
            BtnDikdortgen.FlatAppearance.BorderSize = 2;
            BtnDaire.FlatAppearance.BorderColor = Color.Gray;
            BtnDaire.FlatAppearance.BorderSize = 2;
            BtnAltigen.FlatAppearance.BorderColor = Color.Gray;
            BtnAltigen.FlatAppearance.BorderSize = 2;


            b_altıgen = false;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = true;
            b_sec = false;
        }
        private void BtnAltigen_Click(object sender, EventArgs e)
        {
            altigen = new Altigen();

            BtnAltigen.FlatStyle = FlatStyle.Flat;
            BtnAltigen.FlatAppearance.BorderSize = 3;
            BtnAltigen.FlatAppearance.BorderColor = Color.DarkGray;
            BtnDikdortgen.FlatAppearance.BorderColor = Color.Gray;
            BtnDikdortgen.FlatAppearance.BorderSize = 2;
            BtnDaire.FlatAppearance.BorderColor = Color.Gray;
            BtnDaire.FlatAppearance.BorderSize = 2;
            BtnUcgen.FlatAppearance.BorderColor = Color.Gray;
            BtnUcgen.FlatAppearance.BorderSize = 2;


            b_altıgen = true;
            b_dikdortgen = false;
            b_daire = false;
            b_ucgen = false;
            b_sec = false;
        }
    }
}
