using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RidamCNC : Form
    {
        private List<string> FullName = new List<string>();

        private int OnUpdate { get; set; }

        private int Sec { get; set; }

        private int Min { get; set; }

        private string Firmalar { get; } = "Firmalar";

        private string BackupLog { get; } = @".\Firmalar\RidamCNCLog.txt";
        private bool EnableSignal { get; set; } = false;

        public RidamCNC()
        {
            
            InitializeComponent();
            Label.Text = String.Format(": {0:00}", Sec);
            Label2.Text = String.Format("{0:000}", Min);

            LoadContents("./" + Firmalar);
            Opacity = (double)trackBar1.Value / 100;
            DisposeLog("Ridam CNC Açıldı");
        }

        private void Start(object sender, EventArgs e)
        {
            YesButton.Enabled = false;
            YesButton.Visible = false;
            NoButton.Enabled = false;
            NoButton.Visible = false;
            ExitButton.Enabled = true;
            ExitButton.Visible = true;

            if (!Timer.Enabled)
            {
                Timer.Enabled = true;
                StartButton.Text = "Durdur";
                StartButton.Size = new Size(120, 87);
                StartButton.BackColor = Color.Red;
                BackupButton.Enabled = false;
                ResetButton.Enabled = true;
                ResetButton.Visible = true;
                ExitButton.Enabled = false;
                EnableSignal = true;
            }
            else
            {
                if (Min == 0 && Sec == 0)
                {
                    StartButton.Text = "Başlat";
                    StartButton.BackColor = Color.Lime;

                    if (BackupList.Items.Count != 0) BackupButton.Enabled = true;
                }
                else
                {
                    StartButton.Text = "Devam";
                    StartButton.BackColor = Color.Lime;
                    ExitButton.Enabled = false;

                    if (BackupList.Items.Count != 0) BackupButton.Enabled = true;
                }

                Timer.Enabled = false;
                EnableSignal = false;
                SignalBox.Visible = false;
            }
            

        }

        private void Reset(object sender, EventArgs e)
        {
            YesButton.Enabled = false;
            YesButton.Visible = false;
            NoButton.Enabled = false;
            NoButton.Visible = false;
            ExitButton.Enabled = true;
            ExitButton.Visible = true;

            if (String.Format("{0:000}", Min) + String.Format(" : {0:00}", Sec)
                != String.Format("{0:000}", 0) + String.Format(" : {0:00}", 0))
            {
                var Data = DateTime.Now;

                if (File.Exists(BackupLog))
                {
                    var Read = File.ReadAllLines(BackupLog);

                    if (!Read.LastOrDefault().Contains(String.Format("{0:MM/dd/yy} ", Data)))
                    {
                        File.AppendAllText(BackupLog,
                            Environment.NewLine +
                            "----------------------------------------------------------------------" +
                            Environment.NewLine
                        );
                    }
                }
                BackupList.Items.Add(String.Format("{0:000}", Min) + String.Format(" : {0:00}", Sec));

                File.AppendAllText(BackupLog,
                    String.Format("||{0:MM/dd/yy H:mm}|| ", Data) +
                    String.Format("{0:000}", Min) + 
                    String.Format(" : {0:00}", Sec) + 
                    Environment.NewLine
                    );

                if (BackupList.Items.Count == 11)
                {
                    BackupList.Items.RemoveAt(BackupList.SelectedIndex = 0);
                }
            }

            Sec = 0;
            Min = 0;

            Label.Text = String.Format(": {0:00}", Sec);
            Label2.Text = String.Format("{0:000}", Min);

            Timer.Enabled = false;
            EnableSignal = false;
            SignalBox.Visible = false;

            if (BackupList.Items.Count != 0)
            {
                BackupButton.Enabled = true;
            }

            ResetButton.Enabled = false;
            ResetButton.Visible = false;

            StartButton.Size = new Size(319, 87);
            StartButton.Text = "Başlat";
            StartButton.BackColor = Color.Lime;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Sec += 1;
            if (Sec == 60)
            {
                Sec = 0;
                Min += 1;
            }

            Label.Text = String.Format(": {0:00}", Sec);
            Label2.Text = String.Format("{0:000}", Min);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            OnUpdate += 1;

            if (OnUpdate == 5) OnUpdate = 0;

            if (EnableSignal)
            {
                if (OnUpdate == 3) SignalBox.Visible = true;
                if (OnUpdate == 0) SignalBox.Visible = false;
            }
            


        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitButton.Enabled = false;
            ExitButton.Visible = false;
            YesButton.Enabled = true;
            YesButton.Visible = true;
            NoButton.Enabled = true;
            NoButton.Visible = true;

            Task.Delay(3000).ContinueWith(_ =>
            {
                ExitButton.Enabled = true;
                ExitButton.Visible = true;
                YesButton.Enabled = false;
                YesButton.Visible = false;
                NoButton.Enabled = false;
                NoButton.Visible = false;
            });
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(30);
                Opacity = Opacity - 0.1;
            }

            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            YesButton.Enabled = false;
            YesButton.Visible = false;
            NoButton.Enabled = false;
            NoButton.Visible = false;
            ExitButton.Enabled = true;
            ExitButton.Visible = true;
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            if (BackupList.SelectedIndex >= 0)
            {
                Label.Text = BackupList.Text.Substring(4);
                Label2.Text = BackupList.Text;

                Sec = Convert.ToInt32(BackupList.Text.Substring(6));
                Min = Convert.ToInt32(BackupList.Text.Split(char.Parse(" "))[0]);

                BackupList.Items.RemoveAt(BackupList.SelectedIndex);
                BackupList.Items.Add(String.Format("{0:000}", Min) + String.Format(" : {0:00}", Sec));
                

                StartButton.Text = "Devam";
                StartButton.BackColor = Color.Lime;
                StartButton.Size = new Size(120, 87);
                ExitButton.Enabled = false;
                ResetButton.Enabled = true;
                ResetButton.Visible = true;
            }
            else if (BackupList.Items.Count != 0)
            {
                BackupList.SelectedIndex = BackupList.Items.Count - 1;
                Label.Text = BackupList.Text.Substring(4);
                Label2.Text = BackupList.Text;

                Sec = Convert.ToInt32(BackupList.Text.Substring(6));
                Min = Convert.ToInt32(BackupList.Text.Split(char.Parse(" "))[0]);


                StartButton.Text = "Devam";
                StartButton.BackColor = Color.Lime;
                StartButton.Size = new Size(120, 87);
                ExitButton.Enabled = false;
                ResetButton.Enabled = true;
                ResetButton.Visible = true;
            }
            else if (BackupList.Items.Count != 0)
            {

                //BackupList.Items.RemoveAt(BackupList.SelectedIndex = BackupList.Items.Count - 1);
            }
            

            
        }
        private void LoadContents(string path)
        {
            ListView.Items.Clear();
            FullName.Clear();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("Lütfen Projelerinizi Firmalar Klasörüne Atınız");
                return;
            }

            var DirectoryInfo = new DirectoryInfo(path);
            try
            {
                
                foreach (var Dir in DirectoryInfo.GetDirectories())
                {
                    var LVI = new ListViewItem(Dir.Name, 0);
                    LVI.SubItems.Add("");
                    ListView.Items.Add(LVI);
                    FullName.Add(Dir.FullName);
                }

                foreach (var File in DirectoryInfo.GetFiles())
                {
                    var PGM = File.Name.Replace(".pgm", ".PGM");

                    if (PGM.Substring(PGM.LastIndexOf(@".") + 1) == "PGM")
                    {
                        var Begin = new DateTime(File.LastWriteTime.Ticks);
                        var Span = new TimeSpan(DateTime.Now.Ticks - Begin.Ticks);

                        var YENI = (double)Span.Ticks / 864000000000 * 100 <= 100;

                        var LVI = new ListViewItem(PGM, 1);

                        LVI.SubItems.Add(YENI
                            ? (Span.Hours != 0 ? Span.Hours + "s. Once" : "") + (Span.Hours == 0 ? Span.Minutes + "dk. Once" : "") 
                            : "");

                        LVI.ForeColor = YENI ? Color.Aqua : SystemColors.WindowText;

                        ListView.Items.Add(LVI);
                        FullName.Add(File.FullName);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MouseDobleClick(object sender, MouseEventArgs e)
        {
            var FullNameList = FullName.FirstOrDefault(x => x.Contains(ListView.SelectedItems[0].Text));

            if (!FullNameList.Contains(".PGM"))
            {
                LoadContents(FullNameList);
            }
            else
            {
                MessageBox.Show(ListView.SelectedItems[0].Text);
            }
                
        }
        private void GeriButton(object sender, EventArgs e)
        {
            var FullNameList = FullName.FirstOrDefault(x => ListView.Items.Count == FullName.Count);
            var DirectoryInfo = new DirectoryInfo(FullNameList);

            if (DirectoryInfo.Parent.Parent.FullName.Contains(@"\" + Firmalar))
            {
                LoadContents(DirectoryInfo.Parent.Parent.FullName);
            }
        }

        private void YenilemeButton_Click(object sender, EventArgs e)
        {
            var FullNameList = FullName.FirstOrDefault(x => ListView.Items.Count == FullName.Count);
            var DirectoryInfo = new DirectoryInfo(FullNameList);

            if (DirectoryInfo.Parent.FullName.Contains(@"\" + Firmalar))
            {
                LoadContents(DirectoryInfo.Parent.FullName);
            }

            LabelYenilendi.Enabled = true;
            LabelYenilendi.Visible = true;
            YenilemeButton.Enabled = false;

            Task.Delay(500).ContinueWith(_ =>
            {
                LabelYenilendi.Enabled = false;
                LabelYenilendi.Visible = false;
                YenilemeButton.Enabled = true;
            });
        }

        private void Slide_Scroll(object sender, EventArgs e)
        {
            Opacity = (double)trackBar1.Value / 100;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Process.Start(BackupLog);
        }

        private void DisposeLog(string Text)
        {
            var Data = DateTime.Now;

            if (File.Exists(BackupLog))
            {
                var Read = File.ReadAllLines(BackupLog);

                if (!Read.LastOrDefault().Contains(String.Format("{0:MM/dd/yy} ", Data)))
                {
                    File.AppendAllText(BackupLog,
                        Environment.NewLine +
                        "----------------------------------------------------------------------" +
                        Environment.NewLine
                    );
                }
            }

            File.AppendAllText(BackupLog,
                String.Format("||{0:MM/dd/yy H:mm}|| ", Data) +
                Text +
                Environment.NewLine
                );
        }
    }
}
