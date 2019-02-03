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
    public partial class SettingsForm : Form
    {
        public string PathChoice { get; private set; }
        public string IterChoice { get; private set; }
        public string TimeChoice { get; private set; }

        public SettingsForm(string path_defualt, string iter_default, string sleep_default)
        {
            InitializeComponent();
            PathTxtbox.Text = path_defualt;
            IterTxtbox.Text = iter_default;
            TimeTxtbox.Text = sleep_default;

            this.FormClosing += SettingsForm_FormClosing;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false; // or false if you want to continue closing

                if (PathTxtbox.Text == "" || IterTxtbox.Text == "" || TimeTxtbox.Text == "")
                {
                    MessageBox.Show("Please make sure all text fields are filled.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    PathChoice = PathTxtbox.Text;
                    IterChoice = IterTxtbox.Text;
                    TimeChoice = TimeTxtbox.Text;
                }
            }
        }

        /// <summary>
        /// Makes TextBox controls thread-safe.
        /// </summary>
        /// <param name="tbox"></param>
        /// <param name="text"></param>
        private void WriteToTextbox(TextBox tbox, string text)
        {
            if (tbox.InvokeRequired)
            {
                tbox.Invoke((MethodInvoker)delegate ()
                {
                    tbox.Text = text;
                });
            }
        }

        private void FilePicking()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                WriteToTextbox(PathTxtbox, path);
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(p => { FilePicking(); }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// Sets property values to textbox vlaues.
        /// </summary>
        private void Save()
        {
            if (PathTxtbox.Text == "" || IterTxtbox.Text == "" || TimeTxtbox.Text == "")
            {
                MessageBox.Show("Please make sure all text fields are filled.", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PathChoice = PathTxtbox.Text;
                IterChoice = IterTxtbox.Text;
                TimeChoice = TimeTxtbox.Text;
            }
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
