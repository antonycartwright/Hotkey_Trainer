using CsvHelper;
using Hotkey_Trainer.Models;
using System.Diagnostics;

namespace Hotkey_Trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        List<HotkeyEntry> Hotkeys;

        HotkeyEntry SelectedHotkey;

        Task RevealAnswerTask;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("hotkeys.csv"))

            using (var csv = new CsvHelper.CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                Hotkeys = csv.GetRecords<HotkeyEntry>().ToList();

                dataGridView1.DataSource = Hotkeys;

                SelectRandomHotkey();

                txtGuess.Focus();
            }

            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            lblAnswer.Visible = true;
            timer.Stop();
        }

        private void SelectRandomHotkey()
        {
            Random r = new Random();

            SelectedHotkey = Hotkeys[r.Next(Hotkeys.Count)];

            lblCategory.Text = SelectedHotkey.Category;
            lblCommand.Text = SelectedHotkey.Command;

            lblAnswer.Visible = false;
            lblAnswer.Text = SelectedHotkey.Hotkey;

            timer.Start();
        }

        private void SetAnswerGreen()
        {
            lblAnswer.ForeColor = Color.Green;
            Application.DoEvents();
            Thread.Sleep(1000);
            lblAnswer.ForeColor = Color.Black;
        }

        private void HandleCorrectAnswer()
        {
            timer.Stop();

            lblAnswer.Visible = true;

            SetAnswerGreen();

            SelectRandomHotkey();
        }

        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            lblKeys.Text = e.KeyData.ToString();

            e.SuppressKeyPress = true;

            if (e.KeyData.ToString().Equals(SelectedHotkey.Hotkey))
            {
                HandleCorrectAnswer();
            }
            else
            {
                string[] expected = SelectedHotkey.Hotkey.Replace(" ", "").Split("+");
                Array.Sort(expected);

                string[] given = e.KeyData.ToString().Replace(" ", "").Split(",");

                if (given.Contains("ControlKey"))
                {
                    string[] c = new string[given.Length - 1];

                    int counter = 0;

                    for (int i = 0; i < given.Length; i++)
                    {
                        if (!given[i].Equals("ControlKey"))
                        {
                            c[counter] = given[i];
                        }
                    }

                    given = c;
                }

                if (given.Contains("ShiftKey"))
                {
                    string[] c = new string[given.Length - 1];

                    int counter = 0;

                    for (int i = 0; i < given.Length; i++)
                    {
                        if (!given[i].Equals("ShiftKey"))
                        {
                            c[counter] = given[i];
                        }
                    }

                    given = c;
                }

                if (given.Contains("Oemcomma"))
                {
                    int counter = 0;

                    foreach (string s in given)
                    {
                        if (s.Equals("Oemcomma"))
                        {
                            given[counter] = ",";
                        }

                        counter++;
                    }
                }

                if (given.Contains("OemPeriod"))
                {
                    int counter = 0;

                    foreach (string s in given)
                    {
                        if (s.Equals("OemPeriod"))
                        {
                            given[counter] = ".";
                        }

                        counter++;
                    }
                }

                Array.Sort(given);

                if (AreArraysEqual(expected, given))
                {
                    HandleCorrectAnswer();
                }
            }
        }

        private void txtGuess_KeyUp(object sender, KeyEventArgs e)
        {
            lblKeys.Text = "-";
            txtGuess.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectRandomHotkey();
        }

        public bool AreArraysEqual(string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}