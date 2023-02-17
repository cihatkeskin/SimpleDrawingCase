
namespace SimpleDrawingCase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDikdortgen = new System.Windows.Forms.Button();
            this.BtnUcgen = new System.Windows.Forms.Button();
            this.BtnDaire = new System.Windows.Forms.Button();
            this.BtnAltigen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnBeyaz = new System.Windows.Forms.Button();
            this.BtnKirmizi = new System.Windows.Forms.Button();
            this.BtnMor = new System.Windows.Forms.Button();
            this.BtnYesil = new System.Windows.Forms.Button();
            this.BtnKahve = new System.Windows.Forms.Button();
            this.BtnMavi = new System.Windows.Forms.Button();
            this.BtnSari = new System.Windows.Forms.Button();
            this.BtnTuruncu = new System.Windows.Forms.Button();
            this.BtnSiyah = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSecim = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnDosyaAc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Location = new System.Drawing.Point(12, 12);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1133, 768);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintPanel);
            this.Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownPanel);
            this.Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMovePanel);
            this.Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpPanel);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.BtnDikdortgen);
            this.groupBox1.Controls.Add(this.BtnUcgen);
            this.groupBox1.Controls.Add(this.BtnDaire);
            this.groupBox1.Controls.Add(this.BtnAltigen);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(1151, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ÇİZİM ŞEKLİ";
            // 
            // BtnDikdortgen
            // 
            this.BtnDikdortgen.BackColor = System.Drawing.SystemColors.Window;
            this.BtnDikdortgen.Image = global::SimpleDrawingCase.Properties.Resources.kare;
            this.BtnDikdortgen.Location = new System.Drawing.Point(6, 22);
            this.BtnDikdortgen.Name = "BtnDikdortgen";
            this.BtnDikdortgen.Size = new System.Drawing.Size(103, 88);
            this.BtnDikdortgen.TabIndex = 0;
            this.BtnDikdortgen.UseVisualStyleBackColor = false;
            this.BtnDikdortgen.Click += new System.EventHandler(this.ClickDikdortgen);
            // 
            // BtnUcgen
            // 
            this.BtnUcgen.BackColor = System.Drawing.SystemColors.Window;
            this.BtnUcgen.Image = global::SimpleDrawingCase.Properties.Resources.ucgen;
            this.BtnUcgen.Location = new System.Drawing.Point(6, 116);
            this.BtnUcgen.Name = "BtnUcgen";
            this.BtnUcgen.Size = new System.Drawing.Size(103, 91);
            this.BtnUcgen.TabIndex = 1;
            this.BtnUcgen.UseVisualStyleBackColor = false;
            this.BtnUcgen.Click += new System.EventHandler(this.ClickUcgen);
            // 
            // BtnDaire
            // 
            this.BtnDaire.BackColor = System.Drawing.SystemColors.Window;
            this.BtnDaire.Image = global::SimpleDrawingCase.Properties.Resources.daire;
            this.BtnDaire.Location = new System.Drawing.Point(122, 22);
            this.BtnDaire.Name = "BtnDaire";
            this.BtnDaire.Size = new System.Drawing.Size(99, 88);
            this.BtnDaire.TabIndex = 3;
            this.BtnDaire.UseVisualStyleBackColor = false;
            this.BtnDaire.Click += new System.EventHandler(this.ClickDaire);
            // 
            // BtnAltigen
            // 
            this.BtnAltigen.BackColor = System.Drawing.SystemColors.Window;
            this.BtnAltigen.Image = global::SimpleDrawingCase.Properties.Resources.altigen;
            this.BtnAltigen.Location = new System.Drawing.Point(122, 116);
            this.BtnAltigen.Name = "BtnAltigen";
            this.BtnAltigen.Size = new System.Drawing.Size(101, 91);
            this.BtnAltigen.TabIndex = 2;
            this.BtnAltigen.UseVisualStyleBackColor = false;
            this.BtnAltigen.Click += new System.EventHandler(this.ClickAltigen);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.BtnBeyaz);
            this.groupBox2.Controls.Add(this.BtnKirmizi);
            this.groupBox2.Controls.Add(this.BtnMor);
            this.groupBox2.Controls.Add(this.BtnYesil);
            this.groupBox2.Controls.Add(this.BtnKahve);
            this.groupBox2.Controls.Add(this.BtnMavi);
            this.groupBox2.Controls.Add(this.BtnSari);
            this.groupBox2.Controls.Add(this.BtnTuruncu);
            this.groupBox2.Controls.Add(this.BtnSiyah);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(1151, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 245);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RENK SEÇİMİ";
            // 
            // BtnBeyaz
            // 
            this.BtnBeyaz.BackColor = System.Drawing.Color.White;
            this.BtnBeyaz.Location = new System.Drawing.Point(154, 170);
            this.BtnBeyaz.Name = "BtnBeyaz";
            this.BtnBeyaz.Size = new System.Drawing.Size(67, 68);
            this.BtnBeyaz.TabIndex = 2;
            this.BtnBeyaz.UseVisualStyleBackColor = false;
            this.BtnBeyaz.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BeyazMouseClick);
            // 
            // BtnKirmizi
            // 
            this.BtnKirmizi.BackColor = System.Drawing.Color.Red;
            this.BtnKirmizi.Location = new System.Drawing.Point(6, 22);
            this.BtnKirmizi.Name = "BtnKirmizi";
            this.BtnKirmizi.Size = new System.Drawing.Size(69, 68);
            this.BtnKirmizi.TabIndex = 1;
            this.BtnKirmizi.UseVisualStyleBackColor = false;
            this.BtnKirmizi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KirmiziMouseClick);
            // 
            // BtnMor
            // 
            this.BtnMor.BackColor = System.Drawing.Color.Purple;
            this.BtnMor.Location = new System.Drawing.Point(6, 170);
            this.BtnMor.Name = "BtnMor";
            this.BtnMor.Size = new System.Drawing.Size(69, 68);
            this.BtnMor.TabIndex = 7;
            this.BtnMor.UseVisualStyleBackColor = false;
            this.BtnMor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MorMouseClick);
            // 
            // BtnYesil
            // 
            this.BtnYesil.BackColor = System.Drawing.Color.Green;
            this.BtnYesil.Location = new System.Drawing.Point(154, 22);
            this.BtnYesil.Name = "BtnYesil";
            this.BtnYesil.Size = new System.Drawing.Size(67, 68);
            this.BtnYesil.TabIndex = 3;
            this.BtnYesil.UseVisualStyleBackColor = false;
            this.BtnYesil.MouseClick += new System.Windows.Forms.MouseEventHandler(this.YesilMouseClick);
            // 
            // BtnKahve
            // 
            this.BtnKahve.BackColor = System.Drawing.Color.Brown;
            this.BtnKahve.Location = new System.Drawing.Point(81, 170);
            this.BtnKahve.Name = "BtnKahve";
            this.BtnKahve.Size = new System.Drawing.Size(67, 68);
            this.BtnKahve.TabIndex = 1;
            this.BtnKahve.UseVisualStyleBackColor = false;
            this.BtnKahve.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KahveMouseClick);
            // 
            // BtnMavi
            // 
            this.BtnMavi.BackColor = System.Drawing.Color.Blue;
            this.BtnMavi.Location = new System.Drawing.Point(81, 22);
            this.BtnMavi.Name = "BtnMavi";
            this.BtnMavi.Size = new System.Drawing.Size(67, 68);
            this.BtnMavi.TabIndex = 2;
            this.BtnMavi.UseVisualStyleBackColor = false;
            this.BtnMavi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MaviMouseClick);
            // 
            // BtnSari
            // 
            this.BtnSari.BackColor = System.Drawing.Color.Yellow;
            this.BtnSari.Location = new System.Drawing.Point(154, 96);
            this.BtnSari.Name = "BtnSari";
            this.BtnSari.Size = new System.Drawing.Size(67, 68);
            this.BtnSari.TabIndex = 6;
            this.BtnSari.UseVisualStyleBackColor = false;
            this.BtnSari.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SariMouseClick);
            // 
            // BtnTuruncu
            // 
            this.BtnTuruncu.BackColor = System.Drawing.Color.Orange;
            this.BtnTuruncu.Location = new System.Drawing.Point(6, 96);
            this.BtnTuruncu.Name = "BtnTuruncu";
            this.BtnTuruncu.Size = new System.Drawing.Size(69, 68);
            this.BtnTuruncu.TabIndex = 4;
            this.BtnTuruncu.UseVisualStyleBackColor = false;
            this.BtnTuruncu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TuruncuMouseClick);
            // 
            // BtnSiyah
            // 
            this.BtnSiyah.BackColor = System.Drawing.Color.Black;
            this.BtnSiyah.Location = new System.Drawing.Point(81, 96);
            this.BtnSiyah.Name = "BtnSiyah";
            this.BtnSiyah.Size = new System.Drawing.Size(67, 68);
            this.BtnSiyah.TabIndex = 5;
            this.BtnSiyah.UseVisualStyleBackColor = false;
            this.BtnSiyah.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SiyahMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Controls.Add(this.BtnSecim);
            this.groupBox3.Controls.Add(this.BtnSil);
            this.groupBox3.Controls.Add(this.BtnTemizle);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(1151, 469);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ŞEKİL İŞLEMLERİ";
            // 
            // BtnSecim
            // 
            this.BtnSecim.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSecim.Image = global::SimpleDrawingCase.Properties.Resources.secim;
            this.BtnSecim.Location = new System.Drawing.Point(6, 22);
            this.BtnSecim.Name = "BtnSecim";
            this.BtnSecim.Size = new System.Drawing.Size(69, 72);
            this.BtnSecim.TabIndex = 1;
            this.BtnSecim.UseVisualStyleBackColor = false;
            this.BtnSecim.Click += new System.EventHandler(this.ClickSecim);
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.SystemColors.Window;
            this.BtnSil.Image = global::SimpleDrawingCase.Properties.Resources.sil;
            this.BtnSil.Location = new System.Drawing.Point(81, 22);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(67, 72);
            this.BtnSil.TabIndex = 2;
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.ClickSil);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.BackColor = System.Drawing.SystemColors.Window;
            this.BtnTemizle.Image = global::SimpleDrawingCase.Properties.Resources.kalem;
            this.BtnTemizle.Location = new System.Drawing.Point(154, 22);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(69, 72);
            this.BtnTemizle.TabIndex = 3;
            this.BtnTemizle.UseVisualStyleBackColor = false;
            this.BtnTemizle.Click += new System.EventHandler(this.ClickTemizle);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.BtnKaydet);
            this.groupBox4.Controls.Add(this.BtnDosyaAc);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(1151, 569);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DOSYA İŞLEMLERİ";
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.SystemColors.Window;
            this.BtnKaydet.Image = global::SimpleDrawingCase.Properties.Resources.kaydet;
            this.BtnKaydet.Location = new System.Drawing.Point(87, 22);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(75, 72);
            this.BtnKaydet.TabIndex = 2;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.ClickKaydet);
            // 
            // BtnDosyaAc
            // 
            this.BtnDosyaAc.BackColor = System.Drawing.SystemColors.Window;
            this.BtnDosyaAc.Image = global::SimpleDrawingCase.Properties.Resources.dosya;
            this.BtnDosyaAc.Location = new System.Drawing.Point(6, 22);
            this.BtnDosyaAc.Name = "BtnDosyaAc";
            this.BtnDosyaAc.Size = new System.Drawing.Size(75, 72);
            this.BtnDosyaAc.TabIndex = 1;
            this.BtnDosyaAc.UseVisualStyleBackColor = false;
            this.BtnDosyaAc.Click += new System.EventHandler(this.ClickDosyaAc);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1157, 768);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "MouseLocation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 792);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnDaire;
        private System.Windows.Forms.Button BtnAltigen;
        private System.Windows.Forms.Button BtnUcgen;
        private System.Windows.Forms.Button BtnDikdortgen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnBeyaz;
        private System.Windows.Forms.Button BtnMor;
        private System.Windows.Forms.Button BtnKahve;
        private System.Windows.Forms.Button BtnTuruncu;
        private System.Windows.Forms.Button BtnKirmizi;
        private System.Windows.Forms.Button BtnSiyah;
        private System.Windows.Forms.Button BtnSari;
        private System.Windows.Forms.Button BtnMavi;
        private System.Windows.Forms.Button BtnYesil;
        private System.Windows.Forms.Button BtnSecim;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnDosyaAc;
        private System.Windows.Forms.Label label1;
    }
}

