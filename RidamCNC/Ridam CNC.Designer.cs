using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class RidamCNC
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                DisposeLog("Ridam CNC Kapatıldı");
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RidamCNC));
            this.StartButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Label = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SignalBox = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.BackupButton = new System.Windows.Forms.Button();
            this.BackupList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ListView = new System.Windows.Forms.ListView();
            this.İSİM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YENİ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.YenilemeButton = new System.Windows.Forms.Button();
            this.LabelYenilendi = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.HistoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SignalBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Lime;
            this.StartButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.StartButton.Font = new System.Drawing.Font("Marlett", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(646, 446);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(319, 87);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Başlat";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.Start);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Marlett", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.Location = new System.Drawing.Point(744, 45);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(206, 105);
            this.Label.TabIndex = 1;
            this.Label.Text = ": 00";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Marlett", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label2.ForeColor = System.Drawing.Color.Red;
            this.Label2.Location = new System.Drawing.Point(519, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(329, 141);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "000";
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ResetButton.Enabled = false;
            this.ResetButton.Font = new System.Drawing.Font("Marlett", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetButton.Location = new System.Drawing.Point(845, 446);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(120, 87);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Sıfırla Kaydet";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Visible = false;
            this.ResetButton.Click += new System.EventHandler(this.Reset);
            // 
            // SignalBox
            // 
            this.SignalBox.ErrorImage = null;
            this.SignalBox.Image = ((System.Drawing.Image)(resources.GetObject("SignalBox.Image")));
            this.SignalBox.InitialImage = null;
            this.SignalBox.Location = new System.Drawing.Point(912, 73);
            this.SignalBox.Name = "SignalBox";
            this.SignalBox.Size = new System.Drawing.Size(53, 50);
            this.SignalBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SignalBox.TabIndex = 4;
            this.SignalBox.TabStop = false;
            this.SignalBox.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DimGray;
            this.ExitButton.Font = new System.Drawing.Font("Marlett", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Location = new System.Drawing.Point(845, 283);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(120, 87);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Çıkış";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // YesButton
            // 
            this.YesButton.BackColor = System.Drawing.Color.Red;
            this.YesButton.Enabled = false;
            this.YesButton.Font = new System.Drawing.Font("Marlett", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesButton.Location = new System.Drawing.Point(845, 283);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(60, 87);
            this.YesButton.TabIndex = 6;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = false;
            this.YesButton.Visible = false;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.BackColor = System.Drawing.Color.Lime;
            this.NoButton.Enabled = false;
            this.NoButton.Font = new System.Drawing.Font("Marlett", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoButton.Location = new System.Drawing.Point(905, 283);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(60, 87);
            this.NoButton.TabIndex = 6;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = false;
            this.NoButton.Visible = false;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // Timer2
            // 
            this.Timer2.Enabled = true;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // BackupButton
            // 
            this.BackupButton.Enabled = false;
            this.BackupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackupButton.Location = new System.Drawing.Point(519, 418);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(121, 27);
            this.BackupButton.TabIndex = 8;
            this.BackupButton.Text = "Geri Yükle";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // BackupList
            // 
            this.BackupList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackupList.FormattingEnabled = true;
            this.BackupList.ItemHeight = 25;
            this.BackupList.Location = new System.Drawing.Point(519, 451);
            this.BackupList.Name = "BackupList";
            this.BackupList.Size = new System.Drawing.Size(121, 79);
            this.BackupList.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Marlett", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(13, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GeriButton);
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.İSİM,
            this.YENİ});
            this.ListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListView.Location = new System.Drawing.Point(13, 45);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.ShowGroups = false;
            this.ListView.Size = new System.Drawing.Size(500, 488);
            this.ListView.SmallImageList = this.ImageList;
            this.ListView.TabIndex = 12;
            this.ListView.TileSize = new System.Drawing.Size(200, 100);
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseDobleClick);
            // 
            // İSİM
            // 
            this.İSİM.DisplayIndex = 1;
            this.İSİM.Text = "İSİM";
            this.İSİM.Width = 260;
            // 
            // YENİ
            // 
            this.YENİ.DisplayIndex = 0;
            this.YENİ.Text = "YENİ PROJE";
            this.YENİ.Width = 93;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "project.png");
            this.ImageList.Images.SetKeyName(1, "PGM.png");
            // 
            // YenilemeButton
            // 
            this.YenilemeButton.Font = new System.Drawing.Font("Marlett", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
            this.YenilemeButton.Location = new System.Drawing.Point(85, 9);
            this.YenilemeButton.Name = "YenilemeButton";
            this.YenilemeButton.Size = new System.Drawing.Size(95, 30);
            this.YenilemeButton.TabIndex = 11;
            this.YenilemeButton.Text = "YENİLE";
            this.YenilemeButton.UseVisualStyleBackColor = true;
            this.YenilemeButton.Click += new System.EventHandler(this.YenilemeButton_Click);
            // 
            // LabelYenilendi
            // 
            this.LabelYenilendi.Enabled = false;
            this.LabelYenilendi.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelYenilendi.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LabelYenilendi.Location = new System.Drawing.Point(186, 9);
            this.LabelYenilendi.Name = "LabelYenilendi";
            this.LabelYenilendi.Size = new System.Drawing.Size(118, 30);
            this.LabelYenilendi.TabIndex = 13;
            this.LabelYenilendi.Text = "Yenilendi";
            this.LabelYenilendi.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(377, 12);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 70;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(115, 39);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.TickFrequency = 3;
            this.trackBar1.Value = 93;
            this.trackBar1.Scroll += new System.EventHandler(this.Slide_Scroll);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HistoryButton.Location = new System.Drawing.Point(519, 385);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(121, 27);
            this.HistoryButton.TabIndex = 15;
            this.HistoryButton.Text = "Geçmiş";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // RidamCNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(977, 545);
            this.ControlBox = false;
            this.Controls.Add(this.HistoryButton);
            this.Controls.Add(this.LabelYenilendi);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.YenilemeButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackupList);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.SignalBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.trackBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RidamCNC";
            this.Text = "Ridam CNC";
            ((System.ComponentModel.ISupportInitialize)(this.SignalBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartButton;
        private Label Label;
        private Label Label2;
        private Button ResetButton;
        private PictureBox SignalBox;
        private Button ExitButton;
        private Button YesButton;
        private Button NoButton;
        private Timer Timer;
        private Timer Timer2;
        private Button BackupButton;
        private ListBox BackupList;
        private Button button1;
        private ListView ListView;
        private ImageList ImageList;
        private ColumnHeader YENİ;
        private ColumnHeader İSİM;
        private Button YenilemeButton;
        private Label LabelYenilendi;
        private TrackBar trackBar1;
        private Button HistoryButton;
    }
}

