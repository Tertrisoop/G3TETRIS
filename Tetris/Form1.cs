﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Tetris t;
        private bool down;
        private bool right;
        private bool rolateright;
        private bool pause;
        private bool left;
        public static int highscore = 0;
        private int check;
        public Form1()
        {
            InitializeComponent();

        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newgame();
            music m = new music();
            m.bgsound();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Tetris();
        }

        private void XepGach_KeyDown(object sender, KeyEventArgs e)
        {
            string strKeyPress = null;
            strKeyPress = e.KeyCode.ToString();
            if (!t.end)
            {
                switch (strKeyPress.ToUpper())
                {
                    case "LEFT":
                        left = true;
                        break;
                    case "RIGHT":
                        right = true;
                        break;
                    case "UP":
                        rolateright = true;
                        break;
                    case "DOWN":
                        down = true;
                        break;
                    case "P":
                        fpause();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (strKeyPress.ToUpper())
                {
                    case "ENTER":

                        break;
                    default:
                        break;
                }
            }
        }

        private void XepGach_KeyUp(object sender, KeyEventArgs e)
        {
            string strKeyPress = null;
            strKeyPress = e.KeyCode.ToString();
            if (!t.end)
            {
                switch (strKeyPress.ToUpper())
                {
                    case "LEFT":
                        left = false;
                        break;
                    case "RIGHT":
                        right = false;
                        break;
                    case "DOWN":
                        down = false;
                        break;
                    case "UP":
                        rolateright = false;
                        break;
                    default:
                        break;
                }
                drawplayzone(t.matrix);
            }
        }

        public void drawplayzone(int[,] matrix)
        {
            Bitmap B = new Bitmap(playzone.Width, playzone.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics G = Graphics.FromImage(B);
            G.Clear(Color.Turquoise);
            for (int x = 0; x < constants.playzonecol; x++)
            {
                for (int y = 0; y < constants.playzonerow; y++)
                {
                    int net = matrix[y, x];
                    if (net != 0)
                    {
                        drawbox(G, y, x, constants.COLORES(net - 1));
                    }
                }
            }
            playzone.Image = B;
        }

        public void nextbrick(Brick p)
        {
            Bitmap B = new Bitmap(futurebrick.Width, futurebrick.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics G = Graphics.FromImage(B);
            G.Clear(Color.Black);
            for (int x = 0; x < constants.ybrick; x++)
            {
                for (int y = 0; y < constants.xbrick; y++)
                {
                    int net = t.BrickSiguiente[y, x];
                    if (net != 0)
                    {
                        drawbox(G, y, x, constants.COLORES(t.BrickSiguiente.color - 1));
                    }
                }
            }
            futurebrick.Image = B;
        }

        private void drawbox(Graphics G, int Y, int X, Color C)        //bảng vẽ
        {
            int x = (X * constants.witdh) + 1;
            int y = (Y * constants.heigth) + 1;
            SolidBrush Br = new SolidBrush(C);
            G.FillRectangle(Br, x, y, constants.heigth - 2, constants.heigth - 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t.pnumLineas < constants.scountlv)
            {
                showrealtime();
                lblNumLine.Text = t.numLineas.ToString();
                lblScore.Text = Tetris.score.ToString();
                if (down)
                    showrealtime();
                else
                {
                    down = true;
                    showrealtime();
                    down = false;
                }
                nextbrick(t.BrickSiguiente);
                if (t.end)
                {
                    music m = new music();
                    m.winner();
                    timer1.Stop();
                    timer2.Stop();
                    highscore = Tetris.score;
                    Form2 f2 = new Form2();
                    f2.addscore(highscore);
                    MessageBox.Show("Game Over!! your score "+highscore);
                    
                }
            }
            else
            {
                
                lblNumLine.Text = t.numLineas.ToString();
                lblScore.Text = Tetris.score.ToString();
                constuct();
                t.levelup();               
                lblv.Text = ((int)t.level + 1).ToString();
                timer1.Interval = constants.NIVELES(t.level);
                
            }
        }

        private void showrealtime()        //hiển thị cập nhật
        {
            if (down)
            {
                t.speed();
            }
            if (right)
            {
                t.moveright();
            }
            if (left)
            {
                t.moveleft();
            }
            if (rolateright)
            {
                t.rolateBrick();
                rolateright = false;
            }
           

            drawplayzone(t.matrix);
        }

        private void constuct()
        {
            right = false;
            left = false;
            rolateright = false;
            down = false;
            pause = false;
        }

        private void newgame()
        {
            constuct();
            t.newgame();
            lblScore.Text = "0";
            lblv.Text = "1";
            timer1.Interval = constants.NIVELES(t.level);
            drawplayzone(t.matrix);
            timer1.Start();
            timer2.Start();
        }

        private void fpause()
        {
            if (!t.end)
            {
                if (!pause)
                {
                    timer1.Stop();
                    timer2.Stop();
                }
                else
                {
                    timer1.Start();
                    timer2.Start();
                }
                pause = !pause;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (t.pnumLineas < constants.scountlv)
            {
                showrealtime();
            }
        }


        private void hIGHTSCOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        

        private void hƯỚNGDẪNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void pAUSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fpause();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }
    }
}
