using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void principalPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Net.HttpWebRequest wreq;
            wreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://github.com/JPaulBR/RoyalGameOfUr/blob/master/Royal/Resources/corner.gif?raw=true");
            wreq.AllowWriteStreamBuffering = true;
            using (var response = wreq.GetResponse())
            using (var stream = response.GetResponseStream())
                this.chip4.BackgroundImage = Bitmap.FromStream(stream);
        }
    }
}
