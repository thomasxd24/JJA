using System.Windows.Forms;

namespace JJA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainwebBrowser = new WebKit.WebKitBrowser();
            this.ProductTextBox = new System.Windows.Forms.TextBox();
            this.RechercheButton = new System.Windows.Forms.Button();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathChoose = new System.Windows.Forms.Button();
            this.ValiderButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.QuantitéAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainwebBrowser
            // 
            this.MainwebBrowser.BackColor = System.Drawing.Color.White;
            this.MainwebBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainwebBrowser.Location = new System.Drawing.Point(0, 126);
            this.MainwebBrowser.Name = "MainwebBrowser";
            this.MainwebBrowser.Size = new System.Drawing.Size(1483, 725);
            this.MainwebBrowser.TabIndex = 0;
            this.MainwebBrowser.Url = null;
            // 
            // ProductTextBox
            // 
            this.ProductTextBox.Location = new System.Drawing.Point(222, 30);
            this.ProductTextBox.Name = "ProductTextBox";
            this.ProductTextBox.Size = new System.Drawing.Size(100, 20);
            this.ProductTextBox.TabIndex = 1;
            this.ProductTextBox.TextChanged += new System.EventHandler(this.ProductTextBox_TextChanged);
            this.ProductTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductTextBox_KeyDown);
            // 
            // RechercheButton
            // 
            this.RechercheButton.Location = new System.Drawing.Point(328, 16);
            this.RechercheButton.Name = "RechercheButton";
            this.RechercheButton.Size = new System.Drawing.Size(75, 23);
            this.RechercheButton.TabIndex = 3;
            this.RechercheButton.Text = "Recherche";
            this.RechercheButton.UseVisualStyleBackColor = true;
            this.RechercheButton.Click += new System.EventHandler(this.RechercheButton_Click);
            // 
            // URLTextBox
            // 
            this.URLTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.URLTextBox.Location = new System.Drawing.Point(0, 0);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(1483, 20);
            this.URLTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1483, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JJA Produit";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PathTextBox);
            this.groupBox3.Controls.Add(this.PathChoose);
            this.groupBox3.Controls.Add(this.ValiderButton);
            this.groupBox3.Location = new System.Drawing.Point(427, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 79);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commander plusieur Produit...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Comparer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1137, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(334, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(6, 29);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(221, 20);
            this.PathTextBox.TabIndex = 7;
            this.PathTextBox.Click += new System.EventHandler(this.PathChoose_Click);
            // 
            // PathChoose
            // 
            this.PathChoose.Location = new System.Drawing.Point(233, 29);
            this.PathChoose.Name = "PathChoose";
            this.PathChoose.Size = new System.Drawing.Size(75, 23);
            this.PathChoose.TabIndex = 6;
            this.PathChoose.Text = "Parcourir...";
            this.PathChoose.UseVisualStyleBackColor = true;
            this.PathChoose.Click += new System.EventHandler(this.PathChoose_Click);
            // 
            // ValiderButton
            // 
            this.ValiderButton.Location = new System.Drawing.Point(314, 16);
            this.ValiderButton.Name = "ValiderButton";
            this.ValiderButton.Size = new System.Drawing.Size(62, 58);
            this.ValiderButton.TabIndex = 5;
            this.ValiderButton.Text = "Valider";
            this.ValiderButton.UseVisualStyleBackColor = true;
            this.ValiderButton.Click += new System.EventHandler(this.ValiderButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.QuantitéAdd);
            this.groupBox2.Controls.Add(this.RechercheButton);
            this.groupBox2.Controls.Add(this.ProductTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 74);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rechercher une produit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuantitéAdd
            // 
            this.QuantitéAdd.Location = new System.Drawing.Point(328, 45);
            this.QuantitéAdd.Name = "QuantitéAdd";
            this.QuantitéAdd.Size = new System.Drawing.Size(75, 23);
            this.QuantitéAdd.TabIndex = 5;
            this.QuantitéAdd.Text = "Commander";
            this.QuantitéAdd.UseVisualStyleBackColor = true;
            this.QuantitéAdd.Click += new System.EventHandler(this.QuantitéAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Saisir une Produit JJA (Réference):";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Location = new System.Drawing.Point(815, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(316, 79);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Saisir les Produit manuellement ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(236, 58);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 58);
            this.button3.TabIndex = 8;
            this.button3.Text = "Valider";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Location = new System.Drawing.Point(1137, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(87, 45);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Autre option";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1320, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 851);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.MainwebBrowser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WebKit.WebKitBrowser MainwebBrowser;
        private System.Windows.Forms.TextBox ProductTextBox;
        private System.Windows.Forms.Button RechercheButton;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Label label1;
        private GroupBox groupBox2;
        private Button ValiderButton;
        private GroupBox groupBox3;
        private Button QuantitéAdd;
        private TextBox PathTextBox;
        private Button PathChoose;
        private Button button1;
        private ProgressBar progressBar1;
        private Timer timer1;
        private Button button2;
        private GroupBox groupBox4;
        private Button button3;
        private RichTextBox richTextBox1;
        private GroupBox groupBox5;
        private Button button4;
    }
}

