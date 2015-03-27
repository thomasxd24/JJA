using System;using System.Collections.Generic;
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
        public string missingProductTable { get; set; }

        public Form2(DataTable missingProductTable)
        {
            InitializeComponent();
            dataGridView1.DataSource = missingProductTable;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
