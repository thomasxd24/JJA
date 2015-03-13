using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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


        public void URLButton_Click(object sender, EventArgs e)
        {
            MainwebBrowser.Navigate(URLTextBox.Text);
        }

        private void RechercheButton_Click(object sender, EventArgs e)
        {
            MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                "submitAjaxForm('searchProductsContent','searchProductsForm',function() {adjustHeight(); addClickPopin();},function() {adjustHeight(); addClickPopin();});");
        }

        private async void ValiderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PathTextBox.Text))
            {
                MessageBox.Show("Vous n'avez pas entré l'emplacement du fichier!", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                DisableControl();
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval = 1000;
                ValiderButton.Enabled = false;
                DataTable dt = LoadXls(openFileDialog1.FileName);
                if (dt != null)
                {
                    progressBar1.Maximum = dt.Rows.Count*2;
                    foreach (DataRow row in dt.Rows)
                    {
                        string text = row[0].ToString();
                        MainwebBrowser.StringByEvaluatingJavaScriptFromString("updateProduct('" + text +
                                                                              "','0','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
                        await Task.Delay(1500);
                    }
                }


            }
        }

        private void PathChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Excel Worksheets (*.xls,*.xlsx)|*.xls; *.xlsx";
            openFileDialog1.ShowDialog();
            PathTextBox.Text = openFileDialog1.FileName;
        }

        private DataTable LoadXls(string strFile)
        {
            DataTable dtXLS = new DataTable("importedexcel");

            try
            {
                string strConnectionString = "";

                if (strFile.Trim().EndsWith(".xlsx"))
                {
                    strConnectionString =
                        string.Format(
                            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";",
                            strFile);
                }
                else if (strFile.Trim().EndsWith(".xls"))
                {
                    strConnectionString =
                        string.Format(
                            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";",
                            strFile);
                }

                OleDbConnection SQLConn = new OleDbConnection(strConnectionString);
                SQLConn.Open();

                OleDbDataAdapter SQLAdapter = new OleDbDataAdapter();
                string sql = "SELECT * FROM [sheet1$]";

                OleDbCommand selectCMD = new OleDbCommand(sql, SQLConn);
                SQLAdapter.SelectCommand = selectCMD;

                SQLAdapter.Fill(dtXLS);
                SQLConn.Close();

            }
            catch (Exception ex)
            {

                    MessageBox.Show("Vous êtes en train d'utiliser/ouvrir le fichier excel, il faut le fermer pour que nous puissions l'utiliser.");
            }
            return dtXLS;

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            MainwebBrowser.Navigate("http://easy-rea.com/");
            await Task.Delay(3000);
            URLTextBox.Text = MainwebBrowser.Url.ToString();
            MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                "document.getElementById('login_login').value = 'aubiere'");
            MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                "document.getElementById('login_password').value = 'tonio'");
            MainwebBrowser.StringByEvaluatingJavaScriptFromString("document.forms['loginForm'].submit()");

        }

        private void QuantitéAdd_Click(object sender, EventArgs e)
        {
            MainwebBrowser.StringByEvaluatingJavaScriptFromString("updateProduct('" + ProductTextBox + "','0','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
        }

        private void ProductTextBox_TextChanged(object sender, EventArgs e)
        {
            MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                "document.getElementById('products_reference').value = '" + ProductTextBox.Text + "';");
        }

        private void ProductTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RechercheButton_Click(this, new EventArgs());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int rowcount = LoadXls(openFileDialog1.FileName).Rows.Count;
            if (progressBar1.Value != rowcount*2)
            {
                progressBar1.Value++;
            }
            else if (progressBar1.Value == rowcount*2)
            {
                timer1.Stop();
                ValiderButton.Enabled = true;
                EnableControl();
                Form3 from3 = new Form3();
                from3.ShowDialog();
                progressBar1.Value = 0;
                MainwebBrowser.Reload();
            }
            else
            {
                MessageBox.Show("L'action n'est pas lancée, ou votre fichier excel est vide.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quand vous saisissez 'Commander', Vous devez saisir la reference EXACT du produit.");
        }


        public async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PathTextBox.Text))
            {
                MessageBox.Show("Vous n'avez pas entré l'emplacement du fichier!", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MainwebBrowser.Navigate("http://easy-rea.com/cart/detail");
                await Task.Delay(4000);
                MainwebBrowser.Reload();
                await Task.Delay(2000);
                StringBuilder sb = new StringBuilder();
                DataTable dt = LoadXls(openFileDialog1.FileName);
                foreach (DataRow row in dt.Rows)
                {
                    string text = row[0].ToString();
                    string caps = text.ToUpper();
                    MainwebBrowser.StringByEvaluatingJavaScriptFromString("function GetMissingProduct() {if (document.getElementById('product" + caps + "') == null) { return '" + caps + "'; }};");
                    string missingProduct = (string)MainwebBrowser.Document.InvokeScriptMethod("GetMissingProduct");
                    if (missingProduct != null)
                    {
                    sb.Append(missingProduct + Environment.NewLine);
                    }

                }
               string  missingProductString = sb.ToString();
               Form2 f = new Form2(missingProductString);
               f.Show();


            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisableControl();
        }

        public void DisableControl()
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void EnableControl()
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 from3 = new Form3();
            from3.ShowDialog();
        }
    }
}

// RechercheButton (button2)
// RechercheTextBox 
// QuantitéAdd
// URLTextBox(textBox1)
// URLButton(button1)
// PathTextBox
// PathChoose
// ValiderButton
// MainwebBrowser
