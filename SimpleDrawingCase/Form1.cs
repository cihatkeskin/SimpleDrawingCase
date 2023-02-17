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
        Graphics g;
        Color color;
        SolidBrush brush;
        Shape shape;
        RectangleShape rec;
        CircleShape cir;
        TriangleShape tri;
        HexagonShape hex;
        List<Shape> shapeList; // oluşturulan her şekil bir nesne olarak generic bir yapıda tutuldu
        Point MouseDownStartingLocation; // çizilen şeklin başlangıç konumu
        Point MouseDownEndingLocation; // çizilen şeklin bitiş konumu (mouse bırakıldığı nokta)
        Point newLocation; // taşıma işlemlerinde yeni konumu belirlemek için
        Button prevSelectedButton; // önceki seçilen butonu belirtmek için
        Button selectedButton; // seçilen butonu belirtmek için
        
        // hangi nesnenin çizildiğini belirlemek için 
        bool IsMouseDownRectange = false;
        bool IsMouseDownCircle = false;
        bool IsMouseDownTriangle = false;
        bool IsMouseDownHexagon = false;

        bool paint = false; // çizim işleminin yapılıp yapılmadığını anlamak için

        // şekil işlemlerinde hangi olayın aktif olduğunu belirlemek için 
        bool IsMouseChoose = false;
        bool IsMouseDownChoose = false;
        bool IsMouseDownDelete = false;
        bool IsMouseChangedColor = false;
        bool Moving = false;
        bool IsDelete = false;

        enum _Shapes // karışıklık olmaması adına hangi şeklin çizildiğini belirlemek için enum yapısı tutuldu
        {
            _rectangle = 1,
            _circle,
            _triangle,
            _hexagon
        }
        _Shapes _shape;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            g = Panel.CreateGraphics();
            shapeList = new List<Shape>();
        }

        #region Tanımlanan Fonksiyonlar
        private void SelectedButtonBorder(Button button) // buton seçildiğinde o butonun borderını arttırma
        {
            // Seçili butonu belirleyin
            selectedButton = button;

            // Tüm butonların kenarlıklarını kaldırın
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.FlatStyle = FlatStyle.Standard;
                btn.FlatAppearance.BorderSize = 1;
            }

            // Seçili butonun kenarlarını kalınlaştırın
            selectedButton.FlatStyle = FlatStyle.Flat;
            selectedButton.FlatAppearance.BorderSize = 3;
            selectedButton.FlatAppearance.BorderColor = Color.DarkGray;

            // Önceki seçili butonun kenarlık detaylarını sıfırlayın
            if (prevSelectedButton != null && prevSelectedButton != selectedButton)
            {
                prevSelectedButton.FlatStyle = FlatStyle.Standard;
                prevSelectedButton.FlatAppearance.BorderSize = 1;
            }

            // Seçili butonu önceki seçili buton olarak ayarlayın
            prevSelectedButton = selectedButton;
        }

        private void ColorButtonClick(Color color) // renk seçildiğinde seçilen rengi alma
        {
            brush = new SolidBrush(color);
            IsMouseChangedColor = true;
        }

        private void CreateShape(Shape shape)
        {

            shape.SetCornerPoints();
            shapeList.Add(shape);
            if (shape is CircleShape)
                g.FillEllipse(shape.BrushColor, shape.CornerPoints[0].X, shape.CornerPoints[0].Y, shape.Width, shape.Height);
            else
                g.FillPolygon(shape.BrushColor, shape.CornerPoints);

        }

        #region Dosya İşlemleri için Fonksiyonlar
        
        public string ImportToTextFile() // text dosyasını okur
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // hani dizinde açılacağı
            file.Filter = "txt Dosyaları|*.txt";
            file.RestoreDirectory = true; // bu kod ile her açıldığında açılan bir önceki klasörü açacaktır. (anlamadım)
                                          //  file.CheckFileExists = false;
                                          // bu kod dosya adı kısmına bir isim yazdığınızda dosya var mı yok mu kontrolünü yapar.
            file.Title = "Txt";
            string filePath = string.Empty;

            if (file.ShowDialog() == DialogResult.OK) // dosya seçildi mi kontrolü
                filePath = file.FileName;

            file.ShowDialog(); // ekranı açma
            return filePath;

        }
        public void FileReadingAndDrawing(string filePath)
        {
            System.Drawing.Color colorObject;
            Point locationStartingObject;
            Point locationEndingObject;
        
            StreamReader sr = new StreamReader(filePath);
            string line = sr.ReadLine();
            string[] phrases;
            while (line != null)
            {
                phrases = line.Split(',');
                colorObject = Color.FromName(phrases[1]);
                locationStartingObject = new Point(Convert.ToInt32(phrases[2]), Convert.ToInt32(phrases[3]));
                locationEndingObject = new Point(Convert.ToInt32(phrases[4]), Convert.ToInt32(phrases[5]));

                if (phrases[0] == "RectangleShape")
                {
                    Shape shapeObject = new RectangleShape(locationStartingObject, locationEndingObject, colorObject);
                    CreateShape(shapeObject);

                }
                else if (phrases[0] == "CircleShape")
                {
                    Shape shapeObject = new CircleShape(locationStartingObject, locationEndingObject, colorObject);
                    CreateShape(shapeObject);
                }
                else if (phrases[0] == "TriangleShape")
                {
                    Shape shapeObject = new TriangleShape(locationStartingObject, locationEndingObject, colorObject);
                    CreateShape(shapeObject);
                }
                else if (phrases[0] == "HexagonShape")
                {
                    Shape shapeObject = new HexagonShape(locationStartingObject, locationEndingObject, colorObject);
                    CreateShape(shapeObject);
                }
                line = sr.ReadLine();
            }
            sr.Close();
        }
        #endregion

        #endregion

        #region Şekil ve Renk Clickleri
        private void ClickDikdortgen(object sender, EventArgs e)
        {
            _shape = _Shapes._rectangle; // nesnenin rectangle olacağı belirleniyor
            SelectedButtonBorder(BtnDikdortgen);
        }

        private void ClickDaire(object sender, EventArgs e)
        {
            _shape = _Shapes._circle;
            SelectedButtonBorder(BtnDaire);
        }

        private void ClickUcgen(object sender, EventArgs e)
        {
            _shape = _Shapes._triangle; ;
            SelectedButtonBorder(BtnUcgen);
        }

        private void ClickAltigen(object sender, EventArgs e)
        {
            _shape = _Shapes._hexagon;
            SelectedButtonBorder(BtnAltigen);
        }
        private void KirmiziMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Red);
            SelectedButtonBorder(BtnKirmizi);
        }

        private void YesilMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Green);
            SelectedButtonBorder(BtnYesil);
        }

        private void MaviMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Blue);
            SelectedButtonBorder(BtnMavi);
        }

        private void TuruncuMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Orange);
            SelectedButtonBorder(BtnTuruncu);
        }

        private void SiyahMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Black);
            SelectedButtonBorder(BtnSiyah);
        }

        private void SariMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Yellow);
            SelectedButtonBorder(BtnSari);
        }

        private void MorMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Purple);
            SelectedButtonBorder(BtnMor);
        }

        private void KahveMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.Brown);
            SelectedButtonBorder(BtnKahve);
        }

        private void BeyazMouseClick(object sender, MouseEventArgs e)
        {
            ColorButtonClick(Color.White);
            SelectedButtonBorder(BtnBeyaz);
        }

        #endregion

        private void ClickSecim(object sender, EventArgs e)
        {
            IsMouseDownChoose = true;
            //IsMouseDownDelete = false;
            SelectedButtonBorder(BtnSecim);
        }


        private void ClickSil(object sender, EventArgs e)
        {
            //IsMouseDownChoose = false;
            IsMouseDownDelete = true;
            SelectedButtonBorder(BtnSil);
        }

        private void ClickTemizle(object sender, EventArgs e)
        {
            shapeList.Clear();
            Panel.Invalidate();
            Panel.Update();
            MouseDownStartingLocation = new Point(0, 0);
            MouseDownEndingLocation = new Point(0, 0);
            SelectedButtonBorder(BtnTemizle);
        }

        private void ClickDosyaAc(object sender, EventArgs e)
        {
            string filePath = ImportToTextFile();
            FileReadingAndDrawing(filePath);
        }

        private void ClickKaydet(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // savedialog ekranını açma
            save.Filter = "txt Dosyaları|*.txt"; //dialog ekranında görebileceğimiz uzantılar
                                                 // save.ShowDialog();
            save.OverwritePrompt = true; // aynı isimde bir dosya varsa üzerine yazmaz onay mesajı çıkar
            save.CreatePrompt = true; // aynı isimde dosya yoksa yine onay mesajı çıkar

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(save.FileName);
                foreach (Shape item in shapeList)
                {
                    sw.WriteLine(item.X);
                    sw.WriteLine(item.Y);
                    sw.WriteLine(item.Width);
                    sw.WriteLine(item.Height);
                    sw.WriteLine(item.LocationStarting);
                    sw.WriteLine(item.LocationEnding);
                }

                sw.Close();
            }
        }

        private void MouseDownPanel(object sender, MouseEventArgs e)
        {
            //// Şekil çizme işlemi başlatıldığında
            //drawingShape = true;

            //// Başlangıç noktasını kaydedin
            //startPoint = e.Location;

            //// Şekil merkez noktasını hesaplayın
            //center = e.Location;

            // çizdirme, seçim olmadan, sadece nesneyi seçerek
            if (e.Button == MouseButtons.Left && !paint && !IsMouseChoose && IsDelete == false && !IsMouseDownChoose && !IsMouseDownDelete)
            {
                paint = true;
                if (IsMouseDownRectange == false && _shape == _Shapes._rectangle)
                {
                    MouseDownStartingLocation = e.Location;
                    IsMouseDownRectange = true;
                }
                if (IsMouseDownCircle == false && _shape == _Shapes._circle)
                {
                    MouseDownStartingLocation = e.Location;
                    IsMouseDownCircle = true;

                }
                if (IsMouseDownTriangle == false && _shape == _Shapes._triangle)
                {
                    MouseDownStartingLocation = e.Location;
                    IsMouseDownTriangle = true;
                }
                if (IsMouseDownHexagon == false && _shape == _Shapes._hexagon)
                {
                    MouseDownStartingLocation = e.Location;
                    IsMouseDownHexagon = true;
                }
            }

            // artık seçim basılıysa, nesneyi taşımak için
            if (e.Button == MouseButtons.Left && !IsMouseChoose && IsMouseDownChoose && !IsMouseChangedColor && !IsMouseDownDelete && !paint && !Moving)
            {
                foreach (var item in shapeList)
                {
                    //  shape = item;
                    if ((item.X < e.X && e.X < item.X + item.Width) && (item.Y < e.Y && e.Y < item.Y + item.Height))
                    {
                        shape = item;
                        newLocation = e.Location;
                        IsMouseChoose = true;
                        Moving = true;
                    }
                }
            }

            // seçilen nesnenin rengini değiştirme
            if (e.Button == MouseButtons.Left && IsMouseDownChoose && shapeList.Count != 0 && !paint && !IsMouseDownDelete && IsMouseChangedColor)
            {
                foreach (var item in shapeList)
                {
                    if ((item.X < e.X && e.X < item.X + item.Width) && (item.Y < e.Y && e.Y < item.Y + item.Height))
                        shape = item;
                }
            }

            // silme
            if (e.Button == MouseButtons.Left && IsDelete && shapeList.Count != 0 && !paint && !IsMouseDownDelete && !IsMouseChangedColor)
            {
                foreach (var item in shapeList)
                {
                    if ((item.X < e.X && e.X < item.X + item.Width) && (item.Y < e.Y && e.Y < item.Y + item.Height))
                        shape = item;
                }
            }

            // seçili nesnenin etrafını işaretleme -- çalışmıyor
            if (e.Button == MouseButtons.Left && IsMouseDownChoose && !Moving && shapeList.Count != 0 && !paint && !IsMouseDownDelete && !IsMouseChangedColor)
            {
                foreach (var item in shapeList)
                {
                    if ((item.X < e.X && e.X < item.X + item.Width) && (item.Y < e.Y && e.Y < item.Y + item.Height))
                    {
                        shape = item;
                        Color c = Color.FromArgb(150, 0, 0, 0);
                        SolidBrush sb = new SolidBrush(c);

                        g.FillRectangle(sb, item.X, item.Y, item.Width, item.Height);

                    }
                }

                IsMouseDownChoose = false;

            }

            //nesnenin renginin değişmesi için nesneyi taşıma
            // basıldıysa ve renk değiştirme aktifse
        }

        private void MouseMovePanel(object sender, MouseEventArgs e)
        {
            label1.Text = $"Mouse Location(X, Y):  {e.X.ToString()}  {e.Y.ToString()}";//mouse lokasyonunu belirtir.

            //// Şekil çizme işlemi sırasında
            //if (drawingShape)
            //{
            //    // Şekil boyutunu ve konumunu hesaplayın
            //    width = Math.Abs(e.X - startPoint.X);
            //    height = Math.Abs(e.Y - startPoint.Y);
            //    size = Math.Max(width, height);
            //    x = Math.Min(startPoint.X, e.X) - size / 2;
            //    y = Math.Min(startPoint.Y, e.Y) - size / 2;

            //    // Şekil merkez noktasını güncelleyin
            //    center = new Point(x + size / 2, y + size / 2);
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    // Fare sola doğru çekildiğinde genişlik artacak
            //    rectSize.Width = e.X - rectCenter.X;

            //    // Fare aşağı doğru çekildiğinde yükseklik artacak
            //    rectSize.Height = e.Y - rectCenter.Y;

            //    Panel.Refresh();
            //}

            //Daire
            //if (drawingShape)
            //{
            //    radius = (int)Math.Sqrt(Math.Pow(e.X - centerX, 2) + Math.Pow(e.Y - centerY, 2));
            //    Panel.Invalidate();
            //}

            // nesneyi oluşturma
            if (e.Button == MouseButtons.Left && paint && !IsMouseChoose && !IsMouseDownChoose && !IsMouseDownDelete)
                MouseDownEndingLocation = e.Location;


            // nesneyi taşıma
            if (e.Button == MouseButtons.Left && IsMouseChoose && Moving && IsMouseDownChoose && !IsMouseChangedColor && !IsMouseDownDelete && !paint)
            {
                Panel.Invalidate(new Rectangle(shape.X, shape.Y, shape.Width, shape.Height));
                Panel.Update();
            }

        }

        private void MouseUpPanel(object sender, MouseEventArgs e)
        {
            //// Şekil çizme işlemi bittiğinde
            //drawingShape = false;

            //// Paneli yeniden çizin
            //Panel.Invalidate();

            //// Dikdörtgenin koordinatlarını ayarla
            //int x = rectCenter.X - rectSize.Width / 2;
            //int y = rectCenter.Y - rectSize.Height / 2;
            //int width = rectSize.Width;
            //int height = rectSize.Height;

            //// Dikdörtgenin merkezini bul
            //rectCenter = new Point(x + width / 2, y + height / 2);

            //// Dikdörtgenin koordinatlarını merkezi sabit kalacak şekilde ayarla
            //x = rectCenter.X - width / 2;
            //y = rectCenter.Y - height / 2;

            //Panel.Refresh();

            //Daire
            ////drawingShape = false;

            // nesneyi oluşturma
            if (e.Button == MouseButtons.Left && paint && !IsMouseChoose && !IsMouseDownChoose && !IsMouseDownDelete)
            {
                paint = false;
                if (MouseDownEndingLocation != MouseDownStartingLocation && _shape == _Shapes._rectangle)
                {
                    rec = new RectangleShape(MouseDownStartingLocation, MouseDownEndingLocation);
                    if (IsMouseChangedColor)
                        rec.BrushColor = brush;

                    CreateShape(rec);
                    IsMouseDownRectange = false;
                }
                if (MouseDownEndingLocation != MouseDownStartingLocation && _shape == _Shapes._circle)
                {
                    cir = new CircleShape(MouseDownStartingLocation, MouseDownEndingLocation);
                    if (IsMouseChangedColor)
                        cir.BrushColor = brush;

                    CreateShape(cir);
                    IsMouseDownCircle = false;
                }
                if (MouseDownEndingLocation != MouseDownStartingLocation && _shape == _Shapes._triangle)
                {
                    tri = new TriangleShape(MouseDownStartingLocation, MouseDownEndingLocation);
                    if (IsMouseChangedColor)
                        tri.BrushColor = brush;

                    CreateShape(tri);
                    IsMouseDownTriangle = false;
                }
                if (MouseDownEndingLocation != MouseDownStartingLocation && _shape == _Shapes._hexagon)
                {
                    hex = new HexagonShape(MouseDownStartingLocation, MouseDownEndingLocation);
                    if (IsMouseChangedColor)
                        hex.BrushColor = brush;

                    CreateShape(hex);
                    IsMouseDownHexagon = false;
                }
                MouseDownEndingLocation = new Point(0, 0);
                MouseDownStartingLocation = new Point(0, 0);

            }

            // taşıma işlemi 
            if (e.Button == MouseButtons.Left && IsMouseChoose && IsMouseDownChoose && !IsMouseChangedColor && !IsMouseChangedColor && !IsMouseDownDelete && !paint) ///// rectangle oluştu onu seçtim çalıştı !!!!!!!!1
            {
                int _x = 0, _y = 0, _w = 0, _h = 0;
                Color _c = Color.Black;

                var _temp = shapeList.Where(x => x == shape).ToList();
                foreach (var item in _temp)
                {
                    _x = item.X;
                    _y = item.Y;
                    _w = item.Width;
                    _h = item.Height;
                    _c = item.BrushColor.Color;
                }
                Point newP = new Point((e.X - (newLocation.X - _x)), (e.Y + (_y - newLocation.Y)));
                Point newP2 = new Point(newP.X + _w, newP.Y + _h);
                shapeList.Remove(shapeList.SingleOrDefault(x => x == shape));

                if (shape is RectangleShape)
                {
                    RectangleShape ps = new RectangleShape(newP, newP2, _c);
                    ps.SetCornerPoints();
                    shapeList.Add(ps);
                    g.FillPolygon(ps.BrushColor, ps.CornerPoints);
                }
                if (shape is TriangleShape)
                {
                    TriangleShape ts = new TriangleShape(newP, newP2, _c);
                    ts.SetCornerPoints();
                    shapeList.Add(ts);
                    g.FillPolygon(ts.BrushColor, ts.CornerPoints);
                }
                if (shape is CircleShape)
                {
                    CircleShape cs = new CircleShape(newP, newP2, _c);
                    cs.SetCornerPoints();
                    shapeList.Add(cs);
                    g.FillEllipse(cs.BrushColor, cs.CornerPoints[0].X, cs.CornerPoints[0].Y, cs.Width, cs.Height);
                }
                if (shape is HexagonShape)
                {
                    HexagonShape hs = new HexagonShape(newP, newP2, _c);
                    hs.SetCornerPoints();
                    shapeList.Add(hs);
                    g.FillPolygon(hs.BrushColor, hs.CornerPoints);
                }

                IsMouseChoose = false;
                Moving = false;
                IsMouseDownChoose = false; 
                shape = null;
            }

            // renk değiştime
            if (e.Button == MouseButtons.Left && IsMouseDownChoose && shape != null && IsMouseChangedColor && !IsMouseDownDelete && !paint)
            {
                var _temp = shapeList.Where(x => x == shape);
                foreach (var item in _temp)
                {
                    item.BrushColor = brush;
                }

                Panel.Invalidate(new Rectangle(shape.X, shape.Y, shape.Width, shape.Height));
                Panel.Update();
                if (shape is CircleShape)
                {
                    g.FillEllipse(cir.BrushColor, shape.CornerPoints[0].X, shape.CornerPoints[0].Y, shape.Width, shape.Height);
                }
                else
                {
                    g.FillPolygon(brush, shape.CornerPoints);
                }

                Panel.Update();

                IsMouseDownChoose = false;

                shape = null;
                IsMouseChangedColor = false;
                IsMouseDownChoose = false;
            }

            // silme
            if (e.Button == MouseButtons.Left && !IsMouseDownDelete && IsDelete && !IsMouseDownChoose && !IsMouseChoose && !paint && !Moving && shape != null)
            {
                Panel.Invalidate(new Rectangle(shape.X, shape.Y, shape.Width, shape.Height)); //null dönebilir
                Panel.Update();
                shapeList.Remove(shapeList.SingleOrDefault(x => x == shape));
                shape = null;
                IsMouseDownChoose = false;
                IsDelete = false;
                System.Threading.Thread.Sleep(500);

            }
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            // Şekli çizmek için gerekli olan Pen ve Brush nesnelerini oluşturun
            //SolidBrush brush = new SolidBrush(Color.Black);

            // Şekli çizin
            //if (selectedShape == Shapes.Rectangle)
            //{
            //    e.Graphics.FillRectangle(brush, x, y, size, size);
            //}

            //else if (selectedShape == Shapes.Circle)
            //{
            //    e.Graphics.FillEllipse(brush, center.X - size / 2, center.Y - size / 2, size, size);
            //}
        }
    }
}
