using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sky_jump
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            Title.Image = Image.FromFile("Title.png");
            Title.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Title.Width / 2, 120);
            Options.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Options.Width / 2, 500);
            Exit.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Exit.Width / 2, 550);
            Start.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Start.Width / 2, 500);
        }
        PictureBox Background = new PictureBox();
        Button back = new Button();
        PictureBox player = new PictureBox();
        PictureBox lside = new PictureBox();
        PictureBox rside = new PictureBox();
        Label score = new Label();
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        Random rnd = new Random();
        int scorecount = 0;
        private void Start_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Cursor.Hide();
            Start.Text = "Restart";
            isesc = false;
            Controls.Add(score);
            scorecount = 0;
            score.Location = new Point(0, 0);
            score.TextAlign = ContentAlignment.MiddleCenter;
            score.Font = new Font("Consolas", 24F, FontStyle.Bold, GraphicsUnit.Point);
            score.Text = $"Score: {scorecount}";
            score.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2 - 400, 100);
            score.BackColor = Color.SaddleBrown;

            player.Size = new Size(60, 120);
            player.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - player.Width / 2, Screen.PrimaryScreen.Bounds.Bottom - player.Height - 70);
            plat[0] = new PictureBox();
            lside.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2 - 400, Screen.PrimaryScreen.Bounds.Height);
            lside.BackColor = Color.SaddleBrown;
            rside.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2 - 400, Screen.PrimaryScreen.Bounds.Height);
            rside.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 + 400, 0);
            rside.BackColor = Color.SaddleBrown;
            Controls.Add(lside);
            Controls.Add(rside);
            for (int i = 1; i < plat.Length; i++)
            {
                plat[i] = new PictureBox();
                plat[i].Size = new Size(100, 20);
                Platforms(i);

                Controls.Add(plat[i]);
                plat[i].Location = new Point(rnd.Next(Screen.PrimaryScreen.Bounds.Width / 2 - 400, Screen.PrimaryScreen.Bounds.Width / 2 + 280), Screen.PrimaryScreen.Bounds.Top + i * (Screen.PrimaryScreen.Bounds.Height / 6));

            }
            plat[0].Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - plat[0].Width / 2, Screen.PrimaryScreen.Bounds.Bottom - 50);
            plat[0].Size = new Size(100, 20);
            plat[0].BackColor = Color.Gray;
            plat[0].Tag = "normal";
            Controls.Add(plat[0]);
            player.Image = Image.FromFile(@"player\player12.png");
            Controls.Add(player);


            Jump.Enabled = true;
            Main.Enabled = true;
            Move.Enabled = true;
            Design.Enabled = true;

        }

        private void Options_Click(object sender, EventArgs e)
        {

            Background.Image = Image.FromFile("white.png");
            Controls.Add(Background);
            Controls.Add(back);
            Background.Size = new Size(ActiveForm.Width, ActiveForm.Height);
            Background.BringToFront();
            back.Click += back_Click;

            back.Size = new Size(77, 77);
            back.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            back.Location = new Point(75, 75);
            back.Image = Image.FromFile("backarrow.png");
            back.TabStop = false;
            back.FlatStyle = FlatStyle.Flat;
            back.FlatAppearance.BorderSize = 0;
            back.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);


            GraphicsPath p = new GraphicsPath();
            p.AddEllipse(1, 1, 77, 77);
            back.Region = new Region(p);
            back.BringToFront();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Controls.Remove(Background);
            Controls.Remove(back);
        }
        #region Menuevents
        private void Start_MouseEnter(object sender, EventArgs e)
        {
            Start.BackColor = Color.LightGray;
        }
        private void Start_MouseLeave(object sender, EventArgs e)
        {
            Start.BackColor = Color.White;
        }
        private void Options_MouseEnter(object sender, EventArgs e)
        {
            Options.BackColor = Color.LightGray;
        }
        private void Options_MouseLeave(object sender, EventArgs e)
        {
            Options.BackColor = Color.White;
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.BackColor = Color.LightGray;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = Color.White;
        }
        #endregion 
        PictureBox[] plat = new PictureBox[7];

        bool left = false;
        bool right = false;
        bool isesc = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!isesc)
                {
                    Cursor.Show();
                    Jump.Stop();
                    Main.Stop();
                    Move.Stop();
                    Design.Stop();
                    Background.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Background.Image = Image.FromFile("white.png");

                    Controls.Add(Start);
                    Controls.Add(Title);
                    Controls.Add(Exit);
                    Controls.Add(Background);
                    Background.BringToFront();
                    Exit.BringToFront();
                    Title.BringToFront();
                    Start.BringToFront();
                    isesc = true;
                }
                else
                {
                    Cursor.Hide();
                    Jump.Start();
                    Main.Start();
                    Move.Start();
                    Design.Start();
                    Controls.Remove(Start);
                    Controls.Remove(Title);
                    Controls.Remove(Exit);
                    Controls.Remove(Options);
                    Controls.Remove(Background);

                    isesc = false;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        int speed = 12;
        bool avoid = false;
        int count = 0;

        bool anim = false;
        private void Jump_Tick(object sender, EventArgs e)
        {
            if (!anim)
            {
                if (count % 4 == 0)
                {
                    speed--;
                }
                count++;
            }
            if (left)
            {
                player.Left -= 6;
            }
            else if (right)
            {
                player.Left += 6;
            }
            foreach (Control i in Controls)
            {
                if (i.Right > player.Left && i.Left < player.Right && player.Bottom < i.Top && player.Bottom + 1 > i.Top + speed)
                {
                    player.Top = i.Top - player.Height + 1;
                    anim = true;
                    speed = 12;
                    if (i.Tag.ToString() == "rubber")
                    {
                        speed = 26;
                    }

                    avoid = true;
                    break;
                }
            }
            if (!avoid && !anim)
            {

                if (speed > 0 && player.Top < Screen.PrimaryScreen.Bounds.Height / 2)
                {
                    for (int p = 0; p < plat.Length; p++)
                    {
                        plat[p].Top += speed;

                    }
                    score.Text = $"Score: {scorecount += speed}";
                    if (scorecount > 4000)
                    {
                        moveprob = 9;
                        weakprob = 8;
                        movespeed = 4;
                    }
                    if (scorecount > 8000)
                    {
                        moveprob = 7;
                        weakprob = 6;
                        movespeed = 5;
                    }
                    if (scorecount > 14000)
                    {
                        moveprob = 5;
                        weakprob = 5;
                        movespeed = 6;
                    }
                    if (scorecount > 20000)
                    {
                        moveprob = 4;
                        weakprob = 4;
                        movespeed = 7;
                    }
                    if (scorecount > 25000)
                    {
                        moveprob = 3;
                        weakprob = 3;
                        movespeed = 8;
                    }
                    if (scorecount > 30000)
                    {
                        moveprob = 2;
                        weakprob = 2;
                        movespeed = 9;
                    }
                }
                else
                {
                    player.Top -= speed;
                }
            }
            avoid = false;

        }
        Label Death = new Label();
        int weakprob = 10;
        int moveprob = 12;

        bool[] movel = new bool[7];
        bool[] mover = new bool[7];
        private void Main_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < plat.Length; i++)
            {
                if (plat[i].Top > Screen.PrimaryScreen.Bounds.Height)
                {
                    if (plat[i].Tag.ToString().Contains("removed"))
                    {
                        Controls.Add(plat[i]);
                        plat[i].BringToFront();
                        plat[i].Tag = "weak";
                    }
                    plat[i].Location = new Point(rnd.Next(Screen.PrimaryScreen.Bounds.Width / 2 - 400, Screen.PrimaryScreen.Bounds.Width / 2 + 300), rnd.Next(-30, -20));
                    Platforms(i);

                }
            }

            if (player.Right < Screen.PrimaryScreen.Bounds.Width / 2 - 400)
            {
                player.Left = Screen.PrimaryScreen.Bounds.Width / 2 + 400;
            }
            else if (player.Left > Screen.PrimaryScreen.Bounds.Width / 2 + 400)
            {
                player.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 400 - player.Width;
            }
            if (player.Top > Screen.PrimaryScreen.Bounds.Height)
            {
                Controls.Clear();
                Controls.Add(Start);
                Controls.Add(Exit);
                Controls.Add(Death);
                Cursor.Show();
                weakprob = 12;
                moveprob = 15;
                Death.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - Title.Width / 2, 150);
                Death.Text = "You Died";
                Controls.Add(score);
                score.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - score.Width / 2, 350);
                Death.ForeColor = Color.Red;
                Death.TextAlign = ContentAlignment.MiddleCenter;
                score.BackColor = Color.White;
                Death.Size = new Size(800, 200);
                Death.Font = new Font("Consolas", 72F, FontStyle.Bold, GraphicsUnit.Point);
                Start.Text = "Restart";
                speed = 12;
                avoid = false;
                count = 0;
                left = false;
                right = false;

                Jump.Enabled = false;
                Main.Enabled = false;
                Move.Enabled = false;
                Design.Enabled = false;
            }
        }
        private void Platforms(int a)
        {
            if (rnd.Next(0, moveprob) == 0)
            {
                plat[a].BackColor = Color.LightGreen;
                plat[a].Tag = "move";
                mover[a] = true;
                movel[a] = false;
            }
            else if (rnd.Next(0, weakprob) == 0)
            {

                plat[a].BackColor = Color.LightBlue;
                plat[a].Tag = "weak";
            }
            else
            {
                plat[a].BackColor = Color.Gray;
                plat[a].Tag = "normal";
            }
            if (rnd.Next(0, 30) == 0)
            {
                plat[a].BackColor = Color.Salmon;
                plat[a].Tag = "rubber";
            }
        }
        int movespeed = 3;
        private void Move_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < plat.Length; i++)
            {
                if (plat[i].Tag.ToString().Contains("move"))
                {
                    if (plat[i].Left + 10 < Screen.PrimaryScreen.Bounds.Width / 2 - 400)
                    {
                        movel[i] = false;
                        mover[i] = true;
                    }
                    else if (plat[i].Right + 10 > Screen.PrimaryScreen.Bounds.Width / 2 + 400)
                    {
                        movel[i] = true;
                        mover[i] = false;
                    }
                    if (mover[i])
                    {
                        plat[i].Left += movespeed;
                    }
                    else if (movel[i])
                    {
                        plat[i].Left -= movespeed;
                    }
                }
            }
        }
        int animcount = 1;
        private void Design_Tick(object sender, EventArgs e)
        {
            if (anim)
            {
                player.Image = Image.FromFile(@"player\player" + animcount + ".png");
                animcount++;
            }
            if (animcount == 13)
            {
                for (int i = 0; i < plat.Length; i++)
                {
                    if (plat[i].Right > player.Left && plat[i].Left < player.Right && player.Bottom == plat[i].Top + 1)
                    {
                        if (plat[i].Tag.ToString() == "weak")
                        {
                            Controls.Remove(plat[i]);
                            plat[i].Left = -2000;
                            plat[i].Tag = "weak.removed";
                        }

                        break;
                    }
                }
                animcount = 1;
                anim = false;
            }
        }
    }
}
