﻿namespace MatrisDondurme
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
            tcMain = new TabControl();
            tpSeviyeli = new TabPage();
            pDondur = new Panel();
            cbSeviye = new ComboBox();
            btnSag = new Button();
            btnSol = new Button();
            pBoyutlanabilir = new Panel();
            cbSarmal = new CheckBox();
            pR = new Panel();
            mtbRMax = new MaskedTextBox();
            label5 = new Label();
            label4 = new Label();
            mtbRMin = new MaskedTextBox();
            pNotR = new Panel();
            lblBaslangicDeg = new Label();
            mtbBaslangic = new MaskedTextBox();
            label1 = new Label();
            cbRastgele = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            mtbSutun = new MaskedTextBox();
            mtbSatir = new MaskedTextBox();
            lblMatrisBoyutu = new Label();
            rbMainMatris = new RadioButton();
            rbOrnek = new RadioButton();
            btnBaslat = new Button();
            rtbEkran = new RichTextBox();
            tcMain.SuspendLayout();
            tpSeviyeli.SuspendLayout();
            pDondur.SuspendLayout();
            pBoyutlanabilir.SuspendLayout();
            pR.SuspendLayout();
            pNotR.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Alignment = TabAlignment.Bottom;
            tcMain.Controls.Add(tpSeviyeli);
            tcMain.Dock = DockStyle.Left;
            tcMain.Location = new Point(0, 0);
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(259, 683);
            tcMain.TabIndex = 0;
            // 
            // tpSeviyeli
            // 
            tpSeviyeli.BorderStyle = BorderStyle.FixedSingle;
            tpSeviyeli.Controls.Add(pDondur);
            tpSeviyeli.Controls.Add(pBoyutlanabilir);
            tpSeviyeli.Controls.Add(rbMainMatris);
            tpSeviyeli.Controls.Add(rbOrnek);
            tpSeviyeli.Controls.Add(btnBaslat);
            tpSeviyeli.Location = new Point(4, 4);
            tpSeviyeli.Name = "tpSeviyeli";
            tpSeviyeli.Padding = new Padding(3);
            tpSeviyeli.Size = new Size(251, 655);
            tpSeviyeli.TabIndex = 0;
            tpSeviyeli.Text = "Seviyeli Matris";
            tpSeviyeli.UseVisualStyleBackColor = true;
            // 
            // pDondur
            // 
            pDondur.Controls.Add(cbSeviye);
            pDondur.Controls.Add(btnSag);
            pDondur.Controls.Add(btnSol);
            pDondur.Location = new Point(8, 363);
            pDondur.Name = "pDondur";
            pDondur.Size = new Size(232, 86);
            pDondur.TabIndex = 17;
            // 
            // cbSeviye
            // 
            cbSeviye.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSeviye.FormattingEnabled = true;
            cbSeviye.Location = new Point(64, 53);
            cbSeviye.Name = "cbSeviye";
            cbSeviye.Size = new Size(91, 23);
            cbSeviye.TabIndex = 16;
            // 
            // btnSag
            // 
            btnSag.Location = new Point(133, 21);
            btnSag.Name = "btnSag";
            btnSag.Size = new Size(96, 23);
            btnSag.TabIndex = 2;
            btnSag.Text = "Sağa Döndür";
            btnSag.UseVisualStyleBackColor = true;
            btnSag.Click += btnSag_Click;
            // 
            // btnSol
            // 
            btnSol.Location = new Point(5, 21);
            btnSol.Name = "btnSol";
            btnSol.Size = new Size(86, 23);
            btnSol.TabIndex = 1;
            btnSol.Text = "Sola Döndür";
            btnSol.UseVisualStyleBackColor = true;
            btnSol.Click += btnSol_Click;
            // 
            // pBoyutlanabilir
            // 
            pBoyutlanabilir.Controls.Add(cbSarmal);
            pBoyutlanabilir.Controls.Add(pR);
            pBoyutlanabilir.Controls.Add(pNotR);
            pBoyutlanabilir.Controls.Add(label1);
            pBoyutlanabilir.Controls.Add(cbRastgele);
            pBoyutlanabilir.Controls.Add(label3);
            pBoyutlanabilir.Controls.Add(label2);
            pBoyutlanabilir.Controls.Add(mtbSutun);
            pBoyutlanabilir.Controls.Add(mtbSatir);
            pBoyutlanabilir.Controls.Add(lblMatrisBoyutu);
            pBoyutlanabilir.Location = new Point(8, 67);
            pBoyutlanabilir.Name = "pBoyutlanabilir";
            pBoyutlanabilir.Size = new Size(232, 233);
            pBoyutlanabilir.TabIndex = 15;
            // 
            // cbSarmal
            // 
            cbSarmal.AutoSize = true;
            cbSarmal.Location = new Point(5, 151);
            cbSarmal.Name = "cbSarmal";
            cbSarmal.Size = new Size(110, 19);
            cbSarmal.TabIndex = 24;
            cbSarmal.Text = "Sarmal Matris";
            cbSarmal.UseVisualStyleBackColor = true;
            // 
            // pR
            // 
            pR.Controls.Add(mtbRMax);
            pR.Controls.Add(label5);
            pR.Controls.Add(label4);
            pR.Controls.Add(mtbRMin);
            pR.Location = new Point(3, 80);
            pR.Name = "pR";
            pR.Size = new Size(225, 65);
            pR.TabIndex = 16;
            // 
            // mtbRMax
            // 
            mtbRMax.Location = new Point(163, 35);
            mtbRMax.Mask = "000";
            mtbRMax.Name = "mtbRMax";
            mtbRMax.Size = new Size(32, 21);
            mtbRMax.TabIndex = 23;
            mtbRMax.Text = "50";
            mtbRMax.ValidatingType = typeof(int);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 38);
            label5.Name = "label5";
            label5.Size = new Size(130, 15);
            label5.TabIndex = 22;
            label5.Text = "Random max. değer: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 12);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 21;
            label4.Text = "Random min. değer: ";
            // 
            // mtbRMin
            // 
            mtbRMin.Location = new Point(163, 9);
            mtbRMin.Mask = "000";
            mtbRMin.Name = "mtbRMin";
            mtbRMin.Size = new Size(32, 21);
            mtbRMin.TabIndex = 20;
            mtbRMin.Text = "0";
            mtbRMin.ValidatingType = typeof(int);
            // 
            // pNotR
            // 
            pNotR.Controls.Add(lblBaslangicDeg);
            pNotR.Controls.Add(mtbBaslangic);
            pNotR.Location = new Point(5, 191);
            pNotR.Name = "pNotR";
            pNotR.Size = new Size(224, 39);
            pNotR.TabIndex = 16;
            // 
            // lblBaslangicDeg
            // 
            lblBaslangicDeg.AutoSize = true;
            lblBaslangicDeg.Location = new Point(40, 12);
            lblBaslangicDeg.Name = "lblBaslangicDeg";
            lblBaslangicDeg.Size = new Size(106, 15);
            lblBaslangicDeg.TabIndex = 24;
            lblBaslangicDeg.Text = "Başlangıç değeri:";
            // 
            // mtbBaslangic
            // 
            mtbBaslangic.Location = new Point(161, 6);
            mtbBaslangic.Mask = " 000";
            mtbBaslangic.Name = "mtbBaslangic";
            mtbBaslangic.Size = new Size(32, 21);
            mtbBaslangic.TabIndex = 23;
            mtbBaslangic.Text = "1";
            mtbBaslangic.ValidatingType = typeof(int);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 31);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 23;
            label1.Text = "satır:";
            // 
            // cbRastgele
            // 
            cbRastgele.AutoSize = true;
            cbRastgele.Location = new Point(5, 55);
            cbRastgele.Name = "cbRastgele";
            cbRastgele.Size = new Size(185, 19);
            cbRastgele.TabIndex = 20;
            cbRastgele.Text = "Sayılar Rastgele belirlensin";
            cbRastgele.UseVisualStyleBackColor = true;
            cbRastgele.CheckedChanged += cbRastgele_CheckStateChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 31);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 19;
            label3.Text = "sütun:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 31);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 18;
            label2.Text = "satır:";
            // 
            // mtbSutun
            // 
            mtbSutun.Location = new Point(166, 28);
            mtbSutun.Mask = "000";
            mtbSutun.Name = "mtbSutun";
            mtbSutun.Size = new Size(32, 21);
            mtbSutun.TabIndex = 17;
            mtbSutun.Text = "5";
            mtbSutun.ValidatingType = typeof(int);
            // 
            // mtbSatir
            // 
            mtbSatir.Location = new Point(55, 28);
            mtbSatir.Mask = "000";
            mtbSatir.Name = "mtbSatir";
            mtbSatir.Size = new Size(33, 21);
            mtbSatir.TabIndex = 16;
            mtbSatir.Text = "5";
            mtbSatir.ValidatingType = typeof(int);
            // 
            // lblMatrisBoyutu
            // 
            lblMatrisBoyutu.AutoSize = true;
            lblMatrisBoyutu.Location = new Point(3, 4);
            lblMatrisBoyutu.Name = "lblMatrisBoyutu";
            lblMatrisBoyutu.Size = new Size(91, 15);
            lblMatrisBoyutu.TabIndex = 15;
            lblMatrisBoyutu.Text = "Matris Boyutu";
            // 
            // rbMainMatris
            // 
            rbMainMatris.AutoSize = true;
            rbMainMatris.Location = new Point(8, 17);
            rbMainMatris.Name = "rbMainMatris";
            rbMainMatris.Size = new Size(177, 19);
            rbMainMatris.TabIndex = 13;
            rbMainMatris.TabStop = true;
            rbMainMatris.Text = "Boyutlandırılabilir Matris";
            rbMainMatris.UseVisualStyleBackColor = true;
            rbMainMatris.CheckedChanged += matrisSecim;
            // 
            // rbOrnek
            // 
            rbOrnek.AutoSize = true;
            rbOrnek.Location = new Point(8, 42);
            rbOrnek.Name = "rbOrnek";
            rbOrnek.Size = new Size(102, 19);
            rbOrnek.TabIndex = 12;
            rbOrnek.TabStop = true;
            rbOrnek.Text = "Örnek Matris";
            rbOrnek.UseVisualStyleBackColor = true;
            rbOrnek.CheckedChanged += matrisSecim;
            // 
            // btnBaslat
            // 
            btnBaslat.Location = new Point(34, 334);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(172, 23);
            btnBaslat.TabIndex = 8;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // rtbEkran
            // 
            rtbEkran.BorderStyle = BorderStyle.None;
            rtbEkran.Dock = DockStyle.Fill;
            rtbEkran.Location = new Point(259, 0);
            rtbEkran.Name = "rtbEkran";
            rtbEkran.Size = new Size(985, 683);
            rtbEkran.TabIndex = 1;
            rtbEkran.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 683);
            Controls.Add(rtbEkran);
            Controls.Add(tcMain);
            Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Matris Uygulamaları";
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            tpSeviyeli.ResumeLayout(false);
            tpSeviyeli.PerformLayout();
            pDondur.ResumeLayout(false);
            pBoyutlanabilir.ResumeLayout(false);
            pBoyutlanabilir.PerformLayout();
            pR.ResumeLayout(false);
            pR.PerformLayout();
            pNotR.ResumeLayout(false);
            pNotR.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMain;
        private TabPage tpSeviyeli;
        private Button btnBaslat;
        private Button btnSag;
        private Button btnSol;
        private RadioButton rbMainMatris;
        private RadioButton rbOrnek;
        private Panel pBoyutlanabilir;
        private Label label1;
        private CheckBox cbRastgele;
        private Label label3;
        private Label label2;
        private MaskedTextBox mtbSutun;
        private MaskedTextBox mtbSatir;
        private Label lblMatrisBoyutu;
        private Panel pNotR;
        private Label lblBaslangicDeg;
        private MaskedTextBox mtbBaslangic;
        private Panel pR;
        private Label label4;
        private MaskedTextBox mtbRMin;
        private MaskedTextBox mtbRMax;
        private Label label5;
        private ComboBox cbSeviye;
        private Panel pDondur;
        private RichTextBox rtbEkran;
        private CheckBox cbSarmal;
    }
}
