using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.ControlBox = false;
        }


        private async void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = "10";
            await Task.Delay(1000);
            label2.Text = "9";
            await Task.Delay(1000);
            label2.Text = "8";
            await Task.Delay(1000);
            label2.Text = "7";
            await Task.Delay(1000);
            label2.Text = "6";
            await Task.Delay(1000);
            label2.Text = "5";
            await Task.Delay(1000);
            label2.Text = "4";
            await Task.Delay(1000);
            label2.Text = "3";
            await Task.Delay(1000);
            label2.Text = "2";
            await Task.Delay(1000);
            label2.Text = "1";
            await Task.Delay(1000);
            this.Close();
        }
    }
}
