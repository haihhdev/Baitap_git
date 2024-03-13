using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float data1, data2;
        string pheptinh;

        private void button17_Click(object sender, EventArgs e)
        {
            if (pheptinh == "cong")
            {
                data2 = data1 + float.Parse(lblResult.Text);
                lblOut.Text = data1.ToString() + " + " + float.Parse(lblResult.Text) + " = ";
                lblResult.Text = data2.ToString();
            }
            if (pheptinh == "tru")
            {
                data2 = data1 - float.Parse(lblResult.Text);
                lblOut.Text = data1.ToString() + " - " + float.Parse(lblResult.Text) + " = ";
                lblResult.Text = data2.ToString();
            }
            if (pheptinh == "nhan")
            {
                data2 = data1 * float.Parse(lblResult.Text);
                lblOut.Text = data1.ToString() + " * " + float.Parse(lblResult.Text) + " = ";
                lblResult.Text = data2.ToString();
            }
            if (pheptinh == "mod")
            {
                data2 = data1 % float.Parse(lblResult.Text);
                lblOut.Text = data1.ToString() + " mod " + float.Parse(lblResult.Text) + " = ";
                lblResult.Text = data2.ToString();
            }
            if (pheptinh == "chia")
            {
                if (float.Parse(lblResult.Text) == 0)
                {
                   
                    MessageBox.Show("Math Error");
                }
                else
                {
                    data2 = data1 / float.Parse(lblResult.Text);
                    lblOut.Text = data1.ToString() + " / " + float.Parse(lblResult.Text) + " = ";
                    lblResult.Text = data2.ToString();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + "9";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblOut.Text = " ";
            lblResult.Text = " ";

        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            pheptinh = "cong";
            data1 = float.Parse(lblResult.Text);
            lblResult.Text = " ";
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            pheptinh = "tru";
            data1 = float.Parse(lblResult.Text);
            lblResult.Text = " ";
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            pheptinh = "nhan";
            data1 = float.Parse(lblResult.Text);
            lblResult.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pheptinh = "mod";
            data1 = float.Parse(lblResult.Text);
            lblResult.Text = " ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblResult.Text=lblResult.Text.Substring(0, lblResult.Text.Length - 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text + ".";
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            pheptinh = "chia";
            data1 = float.Parse(lblResult.Text);
            lblResult.Text = " ";
            
        }
    }
}
