﻿namespace Coursework
{
    partial class NonstandartForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 64);
            this.button1.TabIndex = 6;
            this.button1.Text = "Меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 422);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 64);
            this.button3.TabIndex = 7;
            this.button3.Text = "Выйти";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NonstandartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 544);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "NonstandartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Напутствие";
            this.Load += new System.EventHandler(this.NonstandartForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NonstandartForm_Paint_1);
            this.Resize += new System.EventHandler(this.NonstandartForm_Resize_1);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}