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
        }

        private void SelectRandomHotkey()
        {
            Random r = new Random();

            SelectedHotkey = Hotkeys[r.Next(Hotkeys.Count)];

            lblCategory.Text = SelectedHotkey.Category;
            lblCommand.Text = SelectedHotkey.Command;
            lblAnswer.Text = SelectedHotkey.Hotkey;
        }

        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            lblKeys.Text = e.KeyData.ToString();

            e.SuppressKeyPress = true;

            if (e.KeyData.ToString().Equals(SelectedHotkey.Hotkey))
            {
                Thread.Sleep(100);
                SelectRandomHotkey();
            }
            else
            {
                //if (txtGuess.Text.Equals(SelectedHotkey.Hotkey))
                //{
                //    Thread.Sleep(100);
                //    SelectRandomHotkey();
                //}
                //else
                //{
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
                    Thread.Sleep(100);
                    SelectRandomHotkey();
                }
                //}
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