using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public GeneratorForm(string search, int iter, int sleep)
        {
            InitializeComponent();

            Search_path = search;
            Iterator = iter;
            Sleep = sleep;

            t = new Thread(new ParameterizedThreadStart(p => { Generate(); }));
            t.Start();
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
            FileManager fm = new FileManager(DateTime.Now);
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

                fm.AddTo_GeneratedWords(search.Word);

                WriteToLBox(Environment.NewLine);

                Thread.Sleep(Sleep);
            }

            WriteToLBox("English words generated: " + counter + "/" + Iterator + Environment.NewLine);

            WriteToLBox("Press 'Save' button to save generated words.");
        }

        /// <summary>
        /// Pauses or continues the thread that generates words.
        /// </summary>
        private void OnPauseClick()
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

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            OnPauseClick();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
