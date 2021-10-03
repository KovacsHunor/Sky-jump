
using System;
using System.Windows.Forms;

namespace Sky_jump
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Start = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.Options = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.PictureBox();
            this.Jump = new System.Windows.Forms.Timer(this.components);
            this.Main = new System.Windows.Forms.Timer(this.components);
            this.Move = new System.Windows.Forms.Timer(this.components);
            this.Design = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.White;
            this.Start.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(0, 0);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(150, 50);
            this.Start.TabIndex = 7;
            this.Start.Text = "Start";
            this.Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            this.Start.MouseEnter += new System.EventHandler(this.Start_MouseEnter);
            this.Start.MouseLeave += new System.EventHandler(this.Start_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(150, 50);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "Exit";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.White;
            this.Options.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Options.Location = new System.Drawing.Point(0, 0);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(150, 50);
            this.Options.TabIndex = 5;
            this.Options.Text = "OPTIONS";
            this.Options.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            this.Options.MouseEnter += new System.EventHandler(this.Options_MouseEnter);
            this.Options.MouseLeave += new System.EventHandler(this.Options_MouseLeave);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(800, 200);
            this.Title.TabIndex = 4;
            this.Title.TabStop = false;
            // 
            // Jump
            // 
            this.Jump.Interval = 10;
            this.Jump.Tick += new System.EventHandler(this.Jump_Tick);
            // 
            // Main
            // 
            this.Main.Interval = 10;
            this.Main.Tick += new System.EventHandler(this.Main_Tick);
            // 
            // Move
            // 
            this.Move.Interval = 10;
            this.Move.Tick += new System.EventHandler(this.Move_Tick);
            // 
            // Design
            // 
            this.Design.Enabled = true;
            this.Design.Interval = 10;
            this.Design.Tick += new System.EventHandler(this.Design_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 851);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label Options;
        private System.Windows.Forms.PictureBox Title;
        private Timer Jump;
        private Timer Main;
        private Timer Move;
        private Timer Design;
    }
}

