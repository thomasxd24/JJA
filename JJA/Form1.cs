using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JJA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _checkcancelled = false;

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
                _checkcancelled = false;
                DisableControl();
                timer1.Enabled = true;
                timer1.Start();
                button5.Visible = true;
                button5.Enabled = true;
                timer1.Interval = 1000;
                ValiderButton.Enabled = false;
                DataTable dt = LoadXls(openFileDialog1.FileName);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string text = row["Référence"].ToString();
                        string qtestring = row["Nb# Colis"].ToString();
                        int qte;
                        int.TryParse(qtestring, out qte);
                            if (text.Any(char.IsDigit) & _checkcancelled == false)
                            {
                                if (qte < 1)
                                {
                                    if (
                                        MessageBox.Show("La Product: " + row["Libellé"].ToString() +
                                                        " avec la Référence : " + text +
                                                        ","+Environment.NewLine+" Vous avez demandé de commmander " + qtestring +
                                                        " Carton "+Environment.NewLine+".Vous voulez commander 1 carton ou ne commander pas?","Attention",MessageBoxButtons.YesNo) ==
                                        DialogResult.Yes)
                                    {
                                        qte = 1;
                                    }
                                    
                                }
                                progressBar1.Maximum = dt.Rows.Count*2;
                                MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                                    string.Format(
                                        "updateProduct('{0}','0','/products/update',{1},110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');",
                                        text, qte));
                                label5.Text = "Sur:";
                                label4.Text = row["Libellé"].ToString();
                                label3.Text = text;
                                await Task.Delay(1500);
                            }
                            else
                            {
                                timer1.Stop();
                                timer1.Enabled = false;
                                label4.Text = "Annulé...";
                                await Task.Delay(2000);
                                label4.Text = "Libre";
                                break;

                            }
                    }
                }
                else
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    progressBar1.Value = 0;
                    EnableControl();
                    button5.Visible = false;
                    label4.Text = "Annulé...";
                    await Task.Delay(2000);
                    label4.Text = "Libre";
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
            var dtXLS = new DataTable("importedexcel");

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

                var SQLConn = new OleDbConnection(strConnectionString);
                SQLConn.Open();

                var SQLAdapter = new OleDbDataAdapter();
                DataTable dtSchema = SQLConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                string sql = string.Format("SELECT * FROM [{0}]", Sheet1);

                var selectCMD = new OleDbCommand(sql, SQLConn);
                SQLAdapter.SelectCommand = selectCMD;

                SQLAdapter.Fill(dtXLS);
                SQLConn.Close();
            }
            catch (Exception ex)
            {
                progressBar1.Maximum = 0;
                MessageBox.Show(
                    "Vous êtes en train d'utiliser/ouvrir le fichier excel, il faut le fermer pour que nous puissions l'utiliser.Oringinal Original Erruer:"+ ex.ToString());
                dtXLS = null;
            }
            return dtXLS;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainwebBrowser.Navigate("http://easy-rea.com/");
        }

        private void QuantitéAdd_Click(object sender, EventArgs e)
        {
            MainwebBrowser.StringByEvaluatingJavaScriptFromString("updateProduct('" + ProductTextBox +
                                                                  "','0','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
        }

        private void ProductTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainwebBrowser.Url.ToString() == "http://easy-rea.com/products/index")
            {
                MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                    "document.getElementById('products_reference').value = '" + ProductTextBox.Text + "';");
            }
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
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else if (progressBar1.Value == progressBar1.Maximum)
            {

                timer1.Stop();
                ValiderButton.Enabled = true;
                EnableControl();
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
                var sb = new StringBuilder();
                DataTable dt = LoadXls(openFileDialog1.FileName);
                foreach (DataRow row in dt.Rows)
                {
                    string text = row["Référence"].ToString();
                    string caps = text.ToUpper();
                    if (caps.Any(char.IsDigit) & _checkcancelled == false)
                    {
                        MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                            "function GetMissingProduct() {if (document.getElementById('product" + caps +
                            "') == null) { return '" + caps + "'; }};");
                        var missingProduct = (string) MainwebBrowser.Document.InvokeScriptMethod("GetMissingProduct");
                        if (missingProduct != null)
                        {
                            sb.Append(missingProduct + Environment.NewLine);
                        }
                    }
                }
                string missingProductString = sb.ToString();
                var f = new Form2(missingProductString);
                f.Show();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Vous n'avez pas saisir les produit réference!", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                DisableControl();
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval = 1000;
                progressBar1.Maximum = richTextBox1.Lines.Length*2;
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    string text = richTextBox1.Lines[i];
                    MainwebBrowser.StringByEvaluatingJavaScriptFromString("updateProduct('" + text +
                                                                          "','0','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
                    label3.Text = "Sur " + text;
                    await Task.Delay(1500);
                }
            }
        }

        private void DisableControl()
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            MainwebBrowser.Enabled = false;
        }

        private void EnableControl()
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            MainwebBrowser.Enabled = true;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Vous n'avez pas saisir les produit réference!", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MainwebBrowser.Navigate("http://easy-rea.com/cart/detail");
                await Task.Delay(2000);
                MainwebBrowser.Reload();
                await Task.Delay(2000);
                var sb = new StringBuilder();
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    string text = richTextBox1.Lines[i];
                    string caps = text.ToUpper();
                    MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                        "function GetMissingProduct() {if (document.getElementById('product" + caps +
                        "') == null) { return '" + caps + "'; }};");
                    var missingProduct = (string) MainwebBrowser.Document.InvokeScriptMethod("GetMissingProduct");
                    if (missingProduct != null)
                    {
                        sb.Append(missingProduct + Environment.NewLine);
                    }
                }
                string missingProductString = sb.ToString();
                var f = new Form2(missingProductString);
                f.Show();
            }
        }

        private void MainwebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (MainwebBrowser.Url.AbsoluteUri == "http://easy-rea.com/")
            {
                MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                    "document.getElementById('login_login').value = 'aubiere'");
                MainwebBrowser.StringByEvaluatingJavaScriptFromString(
                    "document.getElementById('login_password').value = 'tonio'");
                MainwebBrowser.StringByEvaluatingJavaScriptFromString("document.forms['loginForm'].submit()");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ValiderButton.Enabled = true;
            EnableControl();
            progressBar1.Value = 0;
            _checkcancelled = true;
            button5.Visible = false;
            label5.Text = null;
            label3.Text = null;
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