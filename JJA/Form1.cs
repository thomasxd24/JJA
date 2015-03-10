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
            MainwebBrowser.Navigate(URLTextBox.Text);
        }

        private void RechercheButton_Click(object sender, EventArgs e)
        {
                
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('102550','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('709663341','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
            webKitBrowser1.StringByEvaluatingJavaScriptFromString("updateProduct('700749152','4','/products/update',1,110,'divAlertQteDispoMessage',0,900,'divAlertNbRowsMessage');");
        }
        
        private void ValiderButton_Click(object sender, EventArgs e)
        {
            
        }
        
        private void PathChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        
        public DataTable exceldata(string filepath)
        {
            DataTable dtexcel = new DataTable();
            string HDR = "No";
            string strConn;
            if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=0\"";
            else
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=0\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
            string query = "SELECT  * FROM [sheet1$]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                daexcel.Fill(dtexcel);
            }
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
