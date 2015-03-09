using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKit;
using WebKit.DOM;

namespace JJA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webKitBrowser1.Navigate(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('102550','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('709663341','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('700749152','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
        }
    }
}
