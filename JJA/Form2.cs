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
    public partial class Form2 : Form
    {
        public string missingProductString { get; set; }

        public Form2(string missingProductString)
        {
            InitializeComponent();
            richTextBox1.Text = missingProductString;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Produit Réference");
            DataRow dr = dt.NewRow();
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string text = richTextBox1.Lines[i];
                dr["Produit Réference"] = text;
            }
            dt.Rows.Add(dr);
        }
    }
}
