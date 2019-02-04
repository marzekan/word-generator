namespace M_c2
{
    partial class GeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WordsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // WordsListBox
            // 
            this.WordsListBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.WordsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordsListBox.FormattingEnabled = true;
            this.WordsListBox.ItemHeight = 15;
            this.WordsListBox.Location = new System.Drawing.Point(0, 0);
            this.WordsListBox.Name = "WordsListBox";
            this.WordsListBox.Size = new System.Drawing.Size(612, 334);
            this.WordsListBox.TabIndex = 0;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(611, 372);
            this.Controls.Add(this.WordsListBox);
            this.Name = "GeneratorForm";
            this.Text = "Generator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox WordsListBox;
    }
}