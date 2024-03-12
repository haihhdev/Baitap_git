using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Hãy chọn đường dẫn." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
                    txtpath.Text = fbd.SelectedPath;    
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if(webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }
    }
}
    