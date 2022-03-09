
namespace projekt1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.canva = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDodajWielokat = new System.Windows.Forms.Button();
            this.buttonDodajOkrag = new System.Windows.Forms.Button();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.buttonZablokujDlugosc = new System.Windows.Forms.Button();
            this.buttonZablokujSrodekOkregu = new System.Windows.Forms.Button();
            this.buttonZablokujPromienOkregu = new System.Windows.Forms.Button();
            this.buttonWyrownajDwieKrawedzie = new System.Windows.Forms.Button();
            this.buttonDodajRownolegloscDwochKrawedzi = new System.Windows.Forms.Button();
            this.buttonDodajRelacjeStycznosci = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonUsunRelacje = new System.Windows.Forms.Button();
            this.buttonPrzesunWielokat = new System.Windows.Forms.Button();
            this.buttonDodajWierzcholek = new System.Windows.Forms.Button();
            this.buttonUsunWierzcholek = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canva)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.canva);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1482, 779);
            this.splitContainer1.SplitterDistance = 1065;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // canva
            // 
            this.canva.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canva.BackColor = System.Drawing.Color.White;
            this.canva.Location = new System.Drawing.Point(0, 0);
            this.canva.Name = "canva";
            this.canva.Size = new System.Drawing.Size(1065, 779);
            this.canva.TabIndex = 0;
            this.canva.TabStop = false;
            this.canva.Paint += new System.Windows.Forms.PaintEventHandler(this.canva_Paint);
            this.canva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canva_MouseClick);
            this.canva.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canva_MouseDoubleClick);
            this.canva.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canva_MouseMove);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajWielokat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajOkrag, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonUsun, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonZablokujDlugosc, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonZablokujSrodekOkregu, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.buttonZablokujPromienOkregu, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.buttonWyrownajDwieKrawedzie, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajRownolegloscDwochKrawedzi, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajRelacjeStycznosci, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.buttonUsunRelacje, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.buttonPrzesunWielokat, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajWierzcholek, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonUsunWierzcholek, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 19;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(416, 779);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // buttonDodajWielokat
            // 
            this.buttonDodajWielokat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDodajWielokat.Location = new System.Drawing.Point(3, 3);
            this.buttonDodajWielokat.Name = "buttonDodajWielokat";
            this.buttonDodajWielokat.Size = new System.Drawing.Size(410, 29);
            this.buttonDodajWielokat.TabIndex = 0;
            this.buttonDodajWielokat.Text = "Dodaj wielokąt";
            this.buttonDodajWielokat.UseVisualStyleBackColor = true;
            this.buttonDodajWielokat.Click += new System.EventHandler(this.buttonDodajWielokat_Click);
            // 
            // buttonDodajOkrag
            // 
            this.buttonDodajOkrag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDodajOkrag.Location = new System.Drawing.Point(3, 38);
            this.buttonDodajOkrag.Name = "buttonDodajOkrag";
            this.buttonDodajOkrag.Size = new System.Drawing.Size(410, 29);
            this.buttonDodajOkrag.TabIndex = 3;
            this.buttonDodajOkrag.Text = "Dodaj okrąg";
            this.buttonDodajOkrag.UseVisualStyleBackColor = true;
            this.buttonDodajOkrag.Click += new System.EventHandler(this.buttonDodajOkrag_Click);
            // 
            // buttonUsun
            // 
            this.buttonUsun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUsun.Location = new System.Drawing.Point(3, 73);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(410, 29);
            this.buttonUsun.TabIndex = 2;
            this.buttonUsun.Text = "Usuń figurę";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // buttonZablokujDlugosc
            // 
            this.buttonZablokujDlugosc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZablokujDlugosc.Location = new System.Drawing.Point(3, 213);
            this.buttonZablokujDlugosc.Name = "buttonZablokujDlugosc";
            this.buttonZablokujDlugosc.Size = new System.Drawing.Size(410, 29);
            this.buttonZablokujDlugosc.TabIndex = 4;
            this.buttonZablokujDlugosc.Text = "Zablokuj długość krawędzi";
            this.buttonZablokujDlugosc.UseVisualStyleBackColor = true;
            this.buttonZablokujDlugosc.Click += new System.EventHandler(this.buttonZablokujDlugosc_Click);
            // 
            // buttonZablokujSrodekOkregu
            // 
            this.buttonZablokujSrodekOkregu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZablokujSrodekOkregu.Location = new System.Drawing.Point(3, 248);
            this.buttonZablokujSrodekOkregu.Name = "buttonZablokujSrodekOkregu";
            this.buttonZablokujSrodekOkregu.Size = new System.Drawing.Size(410, 29);
            this.buttonZablokujSrodekOkregu.TabIndex = 5;
            this.buttonZablokujSrodekOkregu.Text = "Zablokuj środek okręgu";
            this.buttonZablokujSrodekOkregu.UseVisualStyleBackColor = true;
            this.buttonZablokujSrodekOkregu.Click += new System.EventHandler(this.buttonZablokujSrodekOkregu_Click);
            // 
            // buttonZablokujPromienOkregu
            // 
            this.buttonZablokujPromienOkregu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZablokujPromienOkregu.Location = new System.Drawing.Point(3, 283);
            this.buttonZablokujPromienOkregu.Name = "buttonZablokujPromienOkregu";
            this.buttonZablokujPromienOkregu.Size = new System.Drawing.Size(410, 29);
            this.buttonZablokujPromienOkregu.TabIndex = 6;
            this.buttonZablokujPromienOkregu.Text = "Zablokuj promień okręgu";
            this.buttonZablokujPromienOkregu.UseVisualStyleBackColor = true;
            this.buttonZablokujPromienOkregu.Click += new System.EventHandler(this.buttonZablokujPromienOkregu_Click);
            // 
            // buttonWyrownajDwieKrawedzie
            // 
            this.buttonWyrownajDwieKrawedzie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWyrownajDwieKrawedzie.Location = new System.Drawing.Point(3, 318);
            this.buttonWyrownajDwieKrawedzie.Name = "buttonWyrownajDwieKrawedzie";
            this.buttonWyrownajDwieKrawedzie.Size = new System.Drawing.Size(410, 29);
            this.buttonWyrownajDwieKrawedzie.TabIndex = 7;
            this.buttonWyrownajDwieKrawedzie.Text = "Wyrównaj dwie krawędzie";
            this.buttonWyrownajDwieKrawedzie.UseVisualStyleBackColor = true;
            this.buttonWyrownajDwieKrawedzie.Click += new System.EventHandler(this.buttonWyrownajDwieKrawedzie_Click);
            // 
            // buttonDodajRownolegloscDwochKrawedzi
            // 
            this.buttonDodajRownolegloscDwochKrawedzi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDodajRownolegloscDwochKrawedzi.Location = new System.Drawing.Point(3, 353);
            this.buttonDodajRownolegloscDwochKrawedzi.Name = "buttonDodajRownolegloscDwochKrawedzi";
            this.buttonDodajRownolegloscDwochKrawedzi.Size = new System.Drawing.Size(410, 29);
            this.buttonDodajRownolegloscDwochKrawedzi.TabIndex = 8;
            this.buttonDodajRownolegloscDwochKrawedzi.Text = "Dodaj równoległość dwóch krawędzi";
            this.buttonDodajRownolegloscDwochKrawedzi.UseVisualStyleBackColor = true;
            this.buttonDodajRownolegloscDwochKrawedzi.Click += new System.EventHandler(this.buttonDodajRownolegloscDwochKrawedzi_Click);
            // 
            // buttonDodajRelacjeStycznosci
            // 
            this.buttonDodajRelacjeStycznosci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDodajRelacjeStycznosci.Location = new System.Drawing.Point(3, 388);
            this.buttonDodajRelacjeStycznosci.Name = "buttonDodajRelacjeStycznosci";
            this.buttonDodajRelacjeStycznosci.Size = new System.Drawing.Size(410, 29);
            this.buttonDodajRelacjeStycznosci.TabIndex = 12;
            this.buttonDodajRelacjeStycznosci.Text = "Dodaj relację styczności";
            this.buttonDodajRelacjeStycznosci.UseVisualStyleBackColor = true;
            this.buttonDodajRelacjeStycznosci.Click += new System.EventHandler(this.buttonDodajRelacjeStycznosci_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(3, 747);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(410, 29);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonUsunRelacje
            // 
            this.buttonUsunRelacje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUsunRelacje.Location = new System.Drawing.Point(3, 423);
            this.buttonUsunRelacje.Name = "buttonUsunRelacje";
            this.buttonUsunRelacje.Size = new System.Drawing.Size(410, 29);
            this.buttonUsunRelacje.TabIndex = 13;
            this.buttonUsunRelacje.Text = "Usuń relację";
            this.buttonUsunRelacje.UseVisualStyleBackColor = true;
            this.buttonUsunRelacje.Click += new System.EventHandler(this.buttonUsunRelacje_Click);
            // 
            // buttonPrzesunWielokat
            // 
            this.buttonPrzesunWielokat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrzesunWielokat.Location = new System.Drawing.Point(3, 108);
            this.buttonPrzesunWielokat.Name = "buttonPrzesunWielokat";
            this.buttonPrzesunWielokat.Size = new System.Drawing.Size(410, 29);
            this.buttonPrzesunWielokat.TabIndex = 11;
            this.buttonPrzesunWielokat.Text = "Przesuń wielokąt";
            this.buttonPrzesunWielokat.UseVisualStyleBackColor = true;
            this.buttonPrzesunWielokat.Click += new System.EventHandler(this.buttonPrzesunWielokat_Click);
            // 
            // buttonDodajWierzcholek
            // 
            this.buttonDodajWierzcholek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDodajWierzcholek.Location = new System.Drawing.Point(3, 143);
            this.buttonDodajWierzcholek.Name = "buttonDodajWierzcholek";
            this.buttonDodajWierzcholek.Size = new System.Drawing.Size(410, 29);
            this.buttonDodajWierzcholek.TabIndex = 9;
            this.buttonDodajWierzcholek.Text = "Dodaj wierzchołek";
            this.buttonDodajWierzcholek.UseVisualStyleBackColor = true;
            this.buttonDodajWierzcholek.Click += new System.EventHandler(this.buttonDodajWierzcholek_Click);
            // 
            // buttonUsunWierzcholek
            // 
            this.buttonUsunWierzcholek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUsunWierzcholek.Location = new System.Drawing.Point(3, 178);
            this.buttonUsunWierzcholek.Name = "buttonUsunWierzcholek";
            this.buttonUsunWierzcholek.Size = new System.Drawing.Size(410, 29);
            this.buttonUsunWierzcholek.TabIndex = 10;
            this.buttonUsunWierzcholek.Text = "Usuń wierzchołek";
            this.buttonUsunWierzcholek.UseVisualStyleBackColor = true;
            this.buttonUsunWierzcholek.Click += new System.EventHandler(this.buttonUsunWierzcholek_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 803);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.Text = "Edytor graficzny";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canva)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox canva;
        private System.Windows.Forms.Button buttonDodajWielokat;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Button buttonDodajOkrag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonZablokujDlugosc;
        private System.Windows.Forms.Button buttonZablokujSrodekOkregu;
        private System.Windows.Forms.Button buttonZablokujPromienOkregu;
        private System.Windows.Forms.Button buttonWyrownajDwieKrawedzie;
        private System.Windows.Forms.Button buttonDodajRownolegloscDwochKrawedzi;
        private System.Windows.Forms.Button buttonDodajWierzcholek;
        private System.Windows.Forms.Button buttonUsunWierzcholek;
        private System.Windows.Forms.Button buttonPrzesunWielokat;
        private System.Windows.Forms.Button buttonDodajRelacjeStycznosci;
        private System.Windows.Forms.Button buttonUsunRelacje;
    }
}

