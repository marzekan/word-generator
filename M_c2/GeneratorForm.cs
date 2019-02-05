using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_c2
{
    public partial class GeneratorForm : Form
    {
        private string Search_path { get; set; }
        private int Iterator { get; set; }
        private int Sleep { get; set; }

        private int count = 1;
        Thread t;
        FileManager fm;

        public GeneratorForm(string search, int iter, int sleep)
        {
            InitializeComponent();

            SaveBtn.Enabled = false;

            Search_path = search;
            Iterator = iter;
            Sleep = sleep;

            fm = new FileManager();
            fm.Delete_generated();

            t = new Thread(new ParameterizedThreadStart(p => { Generate(); }));
            t.Start();

            this.FormClosing += GeneratorForm_FormClosing;
        }

        private void GeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false;

                fm.Delete_generated();
            }
        }

        /// <summary>
        /// Makes ListBox control 'WordsListBox' thread-safe.
        /// </summary>
        /// <param name="text"></param>
        private void WriteToLBox(string text)
        {
            if (WordsListBox.InvokeRequired)
            {
                WordsListBox.Invoke((MethodInvoker)delegate () {

                    WordsListBox.Items.Add(text);
                    WordsListBox.TopIndex = WordsListBox.Items.Count - 1;
                });
            }
        }

        /// <summary>
        /// Generating words and writing them to listbox.
        /// </summary>
        private void Generate()
        {
            Searcher search = new Searcher(Search_path);
            List<string> generated_words = new List<string>();
            int counter = 0;

            for (int i = 0; i < Iterator; i++)
            {
                search.Word = Algorythm.Generate_Word();
                bool is_eng = search.Is_English_Word();

                if (is_eng)
                {
                    counter++;
                    WriteToLBox(search.Word + "         ENGLISH" + Environment.NewLine);

                }
                else
                {
                    WriteToLBox(search.Word + "         NOT ENGLISH" + Environment.NewLine);
                }

                generated_words.Add(search.Word);

                WriteToLBox(Environment.NewLine);

                Thread.Sleep(Sleep);
            }

            fm.AddTo_GeneratedWords(generated_words);

            WriteToLBox("English words generated: " + counter + "/" + Iterator + Environment.NewLine);

            WriteToLBox("Press 'Save' button to save generated words.");

            SaveBtn.Invoke((MethodInvoker)delegate () {
                SaveBtn.Enabled = true;
            });
        }

        /// <summary>
        /// Pauses or continues the thread that generates words.
        /// </summary>
        private void OnPauseClick()
        {
            if (t.IsAlive)
            {
                if (count % 2 != 0)
                {
                    t.Suspend();
                    PauseBtn.Text = "Continue";
                    count++;
                }
                else
                {
                    t.Resume();
                    PauseBtn.Text = "Pause";
                    count++;
                }
            }

        }

        private void OnSaveClick()
        {
            Program.SaveToFile();

            SaveBtn.Invoke((MethodInvoker)delegate () {
                SaveBtn.Enabled = false;
            });
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            OnPauseClick();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Thread savethread = new Thread(new ParameterizedThreadStart(p => { OnSaveClick(); }));
            savethread.SetApartmentState(ApartmentState.STA);
            savethread.Start();
        }
    }
}
