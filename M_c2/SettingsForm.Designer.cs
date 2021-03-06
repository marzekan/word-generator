﻿namespace M_c2
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.PathTxtbox = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IterTxtbox = new System.Windows.Forms.TextBox();
            this.TimeTxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter path of .txt file you want to generate words from.";
            // 
            // PathTxtbox
            // 
            this.PathTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathTxtbox.Location = new System.Drawing.Point(15, 32);
            this.PathTxtbox.Name = "PathTxtbox";
            this.helpProvider1.SetShowHelp(this.PathTxtbox, true);
            this.PathTxtbox.Size = new System.Drawing.Size(482, 22);
            this.PathTxtbox.TabIndex = 1;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "Help za testrbpx";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseBtn.Location = new System.Drawing.Point(499, 32);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(82, 34);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of words to generate:";
            // 
            // IterTxtbox
            // 
            this.IterTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IterTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IterTxtbox.Location = new System.Drawing.Point(15, 87);
            this.IterTxtbox.Name = "IterTxtbox";
            this.IterTxtbox.Size = new System.Drawing.Size(197, 22);
            this.IterTxtbox.TabIndex = 4;
            // 
            // TimeTxtbox
            // 
            this.TimeTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTxtbox.Location = new System.Drawing.Point(15, 146);
            this.TimeTxtbox.Name = "TimeTxtbox";
            this.TimeTxtbox.Size = new System.Drawing.Size(290, 22);
            this.TimeTxtbox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time to pause between new words (in milliseconds):";
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.Location = new System.Drawing.Point(500, 217);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(82, 34);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 263);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.TimeTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IterTxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.PathTxtbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathTxtbox;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IterTxtbox;
        private System.Windows.Forms.TextBox TimeTxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtn;
    }
}