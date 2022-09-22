using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zalpa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap bm;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            if (fDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    System.IO.FileStream fs = new System.IO.FileStream(fDialog.FileName, System.IO.FileMode.Open);
                    bm = new Bitmap(fs);
                    pictureBox1.Image = bm;
                    fDialog.Dispose();
                    radioButton1.Checked = true;
                    radioButton4.Checked = true;
                    radioButton1_CheckedChanged(sender, e);
                }
                catch
                {

                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && pictureBox1.Image != null)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmR = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton4.Checked == true)
                        {
                            bmR.SetPixel(i, j, GetColor(255, 0, 0, color.R, color.G, color.B));
                        }
                        else
                        {
                            bmR.SetPixel(i, j, GetColor(255, 0, 0, color.R, color.G, color.B, isGray: true));
                        }
                    }
                }
                pictureBox1.Image = bmR;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                radioButton1.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true && pictureBox1.Image != null)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmR = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton4.Checked == true)
                        {
                            bmR.SetPixel(i, j, GetColor(0, 255, 0, color.R, color.G, color.B));
                        }
                        else
                        {
                            bmR.SetPixel(i, j, GetColor(0, 255, 0, color.R, color.G, color.B, isGray: true));
                        }
                    }
                }
                pictureBox1.Image = bmR;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                radioButton2.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true && pictureBox1.Image != null)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmR = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton4.Checked == true)
                        {
                            bmR.SetPixel(i, j, GetColor(0, 0, 255, color.R, color.G, color.B));
                        }
                        else
                        {
                            bmR.SetPixel(i, j, GetColor(0, 0, 255, color.R, color.G, color.B, isGray: true));
                        }
                    }
                }
                pictureBox1.Image = bmR;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                radioButton3.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true && pictureBox1.Image == null)
            {
                radioButton4.Checked = false;
            }
            else if (radioButton4.Checked == true && pictureBox1.Image != null)
            {
                if (radioButton1.Checked == true)
                {
                    radioButton1_CheckedChanged(sender, e);
                }
                else if (radioButton2.Checked == true)
                {
                    radioButton2_CheckedChanged(sender, e);
                }
                else if (radioButton3.Checked == true)
                {
                    radioButton3_CheckedChanged(sender, e);
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true && pictureBox1.Image == null)
            {
                radioButton5.Checked = false;
            }
            else if (radioButton5.Checked == true && pictureBox1.Image != null)
            {
                if (radioButton1.Checked == true)
                {
                    radioButton1_CheckedChanged(sender, e);
                }
                else if (radioButton2.Checked == true)
                {
                    radioButton2_CheckedChanged(sender, e);
                }
                else if (radioButton3.Checked == true)
                {
                    radioButton3_CheckedChanged(sender, e);
                }
            }
        }

        private Color GetColor(int targetR, int targetG, int targetB, int realR, int realG, int realB, bool isGray = false)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            if (!isGray)
            {
                r = realR;
                g = realG;
                b = realB;
                if (r >= targetR)
                {
                    r = targetR;
                }
                if (g >= targetG)
                {
                    g = targetG;
                }
                if (b >= targetB)
                {
                    b = targetB;
                }
            }
            else
            {
                int SetVal = 0;
                int RMax = 0;
                int GMax = 0;
                int BMax = 0;
                if (realR > 0)
                {
                    RMax = targetR / realR;
                }
                if (realG > 0)
                {
                    GMax = targetG / realG;
                }
                if (realB > 0)
                {
                    BMax = targetB / realB;
                }
                if (BMax > GMax)
                {
                    if (BMax > RMax)
                    {
                        if (realB < targetB)
                        {
                            SetVal = realB;
                        }
                        else
                        {
                            SetVal = targetB;
                        }
                    }
                    else
                    {
                        if (realR < targetR)
                        {
                            SetVal = realR;
                        }
                        else
                        {
                            SetVal = targetR;
                        }
                    }
                }
                else
                {
                    if (GMax > RMax)
                    {
                        if (realG < targetG)
                        {
                            SetVal = realG;
                        }
                        else
                        {
                            SetVal = targetG;
                        }
                    }
                    else
                    {
                        if (realR < targetR)
                        {
                            SetVal = realR;
                        }
                        else
                        {
                            SetVal = targetR;
                        }
                    }
                }
                r = SetVal;
                g = SetVal;
                b = SetVal;
            }
            return System.Drawing.Color.FromArgb(r, g, b);
        }
    }
}
