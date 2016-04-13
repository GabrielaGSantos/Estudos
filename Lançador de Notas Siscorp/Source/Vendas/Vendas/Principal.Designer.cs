namespace Vendas
{
    partial class Principal
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
            this.bLancar = new System.Windows.Forms.Button();
            this.lNumero = new System.Windows.Forms.Label();
            this.tNumero = new System.Windows.Forms.Label();
            this.tData = new System.Windows.Forms.Label();
            this.lData = new System.Windows.Forms.Label();
            this.tCNPJ = new System.Windows.Forms.Label();
            this.lCNPJ = new System.Windows.Forms.Label();
            this.lCond = new System.Windows.Forms.Label();
            this.lTipo = new System.Windows.Forms.Label();
            this.tTipo = new System.Windows.Forms.Label();
            this.lValor = new System.Windows.Forms.Label();
            this.tValor = new System.Windows.Forms.Label();
            this.lEO = new System.Windows.Forms.Label();
            this.tEO = new System.Windows.Forms.Label();
            this.lICMSPor = new System.Windows.Forms.Label();
            this.tICMSPor = new System.Windows.Forms.Label();
            this.lSubsT = new System.Windows.Forms.Label();
            this.tSubsT = new System.Windows.Forms.Label();
            this.listaNotas = new System.Windows.Forms.CheckedListBox();
            this.Menus = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procurarPastaXML = new System.Windows.Forms.FolderBrowserDialog();
            this.bProx = new System.Windows.Forms.Button();
            this.bAnt = new System.Windows.Forms.Button();
            this.lPasta = new System.Windows.Forms.Label();
            this.tPasta = new System.Windows.Forms.Label();
            this.tICMSV = new System.Windows.Forms.Label();
            this.lICMSV = new System.Windows.Forms.Label();
            this.tNat = new System.Windows.Forms.Label();
            this.lNat = new System.Windows.Forms.Label();
            this.tCond = new System.Windows.Forms.ComboBox();
            this.lNatual = new System.Windows.Forms.Label();
            this.lNtotal = new System.Windows.Forms.Label();
            this.lDest = new System.Windows.Forms.Label();
            this.tDest = new System.Windows.Forms.ComboBox();
            this.bBuscar = new System.Windows.Forms.Button();
            this.Menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // bLancar
            // 
            this.bLancar.Location = new System.Drawing.Point(15, 349);
            this.bLancar.Name = "bLancar";
            this.bLancar.Size = new System.Drawing.Size(346, 23);
            this.bLancar.TabIndex = 0;
            this.bLancar.Text = "Lançar Nota";
            this.bLancar.UseVisualStyleBackColor = true;
            this.bLancar.Click += new System.EventHandler(this.bLancar_Click);
            // 
            // lNumero
            // 
            this.lNumero.AutoSize = true;
            this.lNumero.Location = new System.Drawing.Point(12, 66);
            this.lNumero.Name = "lNumero";
            this.lNumero.Size = new System.Drawing.Size(47, 13);
            this.lNumero.TabIndex = 2;
            this.lNumero.Text = "Número:";
            // 
            // tNumero
            // 
            this.tNumero.AutoSize = true;
            this.tNumero.Location = new System.Drawing.Point(57, 66);
            this.tNumero.Name = "tNumero";
            this.tNumero.Size = new System.Drawing.Size(13, 13);
            this.tNumero.TabIndex = 3;
            this.tNumero.Text = "_";
            // 
            // tData
            // 
            this.tData.AutoSize = true;
            this.tData.Location = new System.Drawing.Point(42, 95);
            this.tData.Name = "tData";
            this.tData.Size = new System.Drawing.Size(13, 13);
            this.tData.TabIndex = 5;
            this.tData.Text = "_";
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.Location = new System.Drawing.Point(12, 95);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(33, 13);
            this.lData.TabIndex = 4;
            this.lData.Text = "Data:";
            // 
            // tCNPJ
            // 
            this.tCNPJ.AutoSize = true;
            this.tCNPJ.Location = new System.Drawing.Point(71, 123);
            this.tCNPJ.Name = "tCNPJ";
            this.tCNPJ.Size = new System.Drawing.Size(13, 13);
            this.tCNPJ.TabIndex = 7;
            this.tCNPJ.Text = "_";
            // 
            // lCNPJ
            // 
            this.lCNPJ.AutoSize = true;
            this.lCNPJ.Location = new System.Drawing.Point(12, 123);
            this.lCNPJ.Name = "lCNPJ";
            this.lCNPJ.Size = new System.Drawing.Size(62, 13);
            this.lCNPJ.TabIndex = 6;
            this.lCNPJ.Text = "CNPJ/CPF:";
            // 
            // lCond
            // 
            this.lCond.AutoSize = true;
            this.lCond.Location = new System.Drawing.Point(12, 180);
            this.lCond.Name = "lCond";
            this.lCond.Size = new System.Drawing.Size(92, 13);
            this.lCond.TabIndex = 8;
            this.lCond.Text = "Cond Pagamento:";
            // 
            // lTipo
            // 
            this.lTipo.AutoSize = true;
            this.lTipo.Location = new System.Drawing.Point(12, 210);
            this.lTipo.Name = "lTipo";
            this.lTipo.Size = new System.Drawing.Size(34, 13);
            this.lTipo.TabIndex = 10;
            this.lTipo.Text = "Tipo: ";
            // 
            // tTipo
            // 
            this.tTipo.AutoSize = true;
            this.tTipo.Location = new System.Drawing.Point(40, 210);
            this.tTipo.Name = "tTipo";
            this.tTipo.Size = new System.Drawing.Size(13, 13);
            this.tTipo.TabIndex = 11;
            this.tTipo.Text = "_";
            // 
            // lValor
            // 
            this.lValor.AutoSize = true;
            this.lValor.Location = new System.Drawing.Point(12, 238);
            this.lValor.Name = "lValor";
            this.lValor.Size = new System.Drawing.Size(34, 13);
            this.lValor.TabIndex = 12;
            this.lValor.Text = "Valor:";
            // 
            // tValor
            // 
            this.tValor.AutoSize = true;
            this.tValor.Location = new System.Drawing.Point(42, 238);
            this.tValor.Name = "tValor";
            this.tValor.Size = new System.Drawing.Size(13, 13);
            this.tValor.TabIndex = 13;
            this.tValor.Text = "_";
            // 
            // lEO
            // 
            this.lEO.AutoSize = true;
            this.lEO.Location = new System.Drawing.Point(12, 263);
            this.lEO.Name = "lEO";
            this.lEO.Size = new System.Drawing.Size(25, 13);
            this.lEO.TabIndex = 14;
            this.lEO.Text = "EO:";
            // 
            // tEO
            // 
            this.tEO.AutoSize = true;
            this.tEO.Location = new System.Drawing.Point(32, 263);
            this.tEO.Name = "tEO";
            this.tEO.Size = new System.Drawing.Size(13, 13);
            this.tEO.TabIndex = 15;
            this.tEO.Text = "_";
            // 
            // lICMSPor
            // 
            this.lICMSPor.AutoSize = true;
            this.lICMSPor.Location = new System.Drawing.Point(12, 290);
            this.lICMSPor.Name = "lICMSPor";
            this.lICMSPor.Size = new System.Drawing.Size(53, 13);
            this.lICMSPor.TabIndex = 16;
            this.lICMSPor.Text = "ICMS (%):";
            // 
            // tICMSPor
            // 
            this.tICMSPor.AutoSize = true;
            this.tICMSPor.Location = new System.Drawing.Point(61, 290);
            this.tICMSPor.Name = "tICMSPor";
            this.tICMSPor.Size = new System.Drawing.Size(13, 13);
            this.tICMSPor.TabIndex = 17;
            this.tICMSPor.Text = "_";
            // 
            // lSubsT
            // 
            this.lSubsT.AutoSize = true;
            this.lSubsT.Location = new System.Drawing.Point(12, 319);
            this.lSubsT.Name = "lSubsT";
            this.lSubsT.Size = new System.Drawing.Size(84, 13);
            this.lSubsT.TabIndex = 18;
            this.lSubsT.Text = "Subs Tributaria: ";
            // 
            // tSubsT
            // 
            this.tSubsT.AutoSize = true;
            this.tSubsT.Location = new System.Drawing.Point(91, 319);
            this.tSubsT.Name = "tSubsT";
            this.tSubsT.Size = new System.Drawing.Size(13, 13);
            this.tSubsT.TabIndex = 19;
            this.tSubsT.Text = "_";
            // 
            // listaNotas
            // 
            this.listaNotas.FormattingEnabled = true;
            this.listaNotas.Items.AddRange(new object[] {
            "NENHUMA NOTA SELECIONADA"});
            this.listaNotas.Location = new System.Drawing.Point(367, 53);
            this.listaNotas.Name = "listaNotas";
            this.listaNotas.Size = new System.Drawing.Size(343, 349);
            this.listaNotas.TabIndex = 20;
            // 
            // Menus
            // 
            this.Menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.Menus.Location = new System.Drawing.Point(0, 0);
            this.Menus.Name = "Menus";
            this.Menus.Size = new System.Drawing.Size(725, 24);
            this.Menus.TabIndex = 21;
            this.Menus.Text = "Menus";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarNotasToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // carregarNotasToolStripMenuItem
            // 
            this.carregarNotasToolStripMenuItem.Name = "carregarNotasToolStripMenuItem";
            this.carregarNotasToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.carregarNotasToolStripMenuItem.Text = "Carregar Notas";
            this.carregarNotasToolStripMenuItem.Click += new System.EventHandler(this.carregarNotasToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // procurarPastaXML
            // 
            this.procurarPastaXML.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // bProx
            // 
            this.bProx.Location = new System.Drawing.Point(191, 378);
            this.bProx.Name = "bProx";
            this.bProx.Size = new System.Drawing.Size(170, 23);
            this.bProx.TabIndex = 22;
            this.bProx.Text = "Próxima";
            this.bProx.UseVisualStyleBackColor = true;
            this.bProx.Click += new System.EventHandler(this.bProx_Click);
            // 
            // bAnt
            // 
            this.bAnt.Location = new System.Drawing.Point(15, 379);
            this.bAnt.Name = "bAnt";
            this.bAnt.Size = new System.Drawing.Size(170, 23);
            this.bAnt.TabIndex = 23;
            this.bAnt.Text = "Anterior";
            this.bAnt.UseVisualStyleBackColor = true;
            this.bAnt.Click += new System.EventHandler(this.bAnt_Click);
            // 
            // lPasta
            // 
            this.lPasta.AutoSize = true;
            this.lPasta.Location = new System.Drawing.Point(15, 413);
            this.lPasta.Name = "lPasta";
            this.lPasta.Size = new System.Drawing.Size(99, 13);
            this.lPasta.TabIndex = 25;
            this.lPasta.Text = "Pasta Selecionada:";
            // 
            // tPasta
            // 
            this.tPasta.AutoSize = true;
            this.tPasta.Location = new System.Drawing.Point(110, 413);
            this.tPasta.Name = "tPasta";
            this.tPasta.Size = new System.Drawing.Size(13, 13);
            this.tPasta.TabIndex = 26;
            this.tPasta.Text = "_";
            // 
            // tICMSV
            // 
            this.tICMSV.AutoSize = true;
            this.tICMSV.Location = new System.Drawing.Point(159, 290);
            this.tICMSV.Name = "tICMSV";
            this.tICMSV.Size = new System.Drawing.Size(13, 13);
            this.tICMSV.TabIndex = 28;
            this.tICMSV.Text = "_";
            // 
            // lICMSV
            // 
            this.lICMSV.AutoSize = true;
            this.lICMSV.Location = new System.Drawing.Point(126, 290);
            this.lICMSV.Name = "lICMSV";
            this.lICMSV.Size = new System.Drawing.Size(36, 13);
            this.lICMSV.TabIndex = 27;
            this.lICMSV.Text = "ICMS:";
            // 
            // tNat
            // 
            this.tNat.AutoSize = true;
            this.tNat.Location = new System.Drawing.Point(61, 38);
            this.tNat.Name = "tNat";
            this.tNat.Size = new System.Drawing.Size(13, 13);
            this.tNat.TabIndex = 30;
            this.tNat.Text = "_";
            // 
            // lNat
            // 
            this.lNat.AutoSize = true;
            this.lNat.Location = new System.Drawing.Point(12, 38);
            this.lNat.Name = "lNat";
            this.lNat.Size = new System.Drawing.Size(53, 13);
            this.lNat.TabIndex = 29;
            this.lNat.Text = "Natureza:";
            // 
            // tCond
            // 
            this.tCond.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tCond.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tCond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tCond.Location = new System.Drawing.Point(110, 177);
            this.tCond.Name = "tCond";
            this.tCond.Size = new System.Drawing.Size(248, 21);
            this.tCond.TabIndex = 31;
            // 
            // lNatual
            // 
            this.lNatual.AutoSize = true;
            this.lNatual.Location = new System.Drawing.Point(634, 413);
            this.lNatual.Name = "lNatual";
            this.lNatual.Size = new System.Drawing.Size(13, 13);
            this.lNatual.TabIndex = 32;
            this.lNatual.Text = "0";
            // 
            // lNtotal
            // 
            this.lNtotal.AutoSize = true;
            this.lNtotal.Location = new System.Drawing.Point(668, 413);
            this.lNtotal.Name = "lNtotal";
            this.lNtotal.Size = new System.Drawing.Size(21, 13);
            this.lNtotal.TabIndex = 33;
            this.lNtotal.Text = "/ 0";
            // 
            // lDest
            // 
            this.lDest.AutoSize = true;
            this.lDest.Location = new System.Drawing.Point(12, 150);
            this.lDest.Name = "lDest";
            this.lDest.Size = new System.Drawing.Size(32, 13);
            this.lDest.TabIndex = 34;
            this.lDest.Text = "Dest:";
            // 
            // tDest
            // 
            this.tDest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tDest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tDest.Location = new System.Drawing.Point(43, 147);
            this.tDest.Name = "tDest";
            this.tDest.Size = new System.Drawing.Size(315, 21);
            this.tDest.TabIndex = 35;
            // 
            // bBuscar
            // 
            this.bBuscar.Location = new System.Drawing.Point(611, 27);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(96, 20);
            this.bBuscar.TabIndex = 37;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(725, 443);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.tDest);
            this.Controls.Add(this.lDest);
            this.Controls.Add(this.lNtotal);
            this.Controls.Add(this.lNatual);
            this.Controls.Add(this.tCond);
            this.Controls.Add(this.tNat);
            this.Controls.Add(this.lNat);
            this.Controls.Add(this.tICMSV);
            this.Controls.Add(this.lICMSV);
            this.Controls.Add(this.tPasta);
            this.Controls.Add(this.lPasta);
            this.Controls.Add(this.bAnt);
            this.Controls.Add(this.bProx);
            this.Controls.Add(this.listaNotas);
            this.Controls.Add(this.tSubsT);
            this.Controls.Add(this.lSubsT);
            this.Controls.Add(this.tICMSPor);
            this.Controls.Add(this.lICMSPor);
            this.Controls.Add(this.tEO);
            this.Controls.Add(this.lEO);
            this.Controls.Add(this.tValor);
            this.Controls.Add(this.lValor);
            this.Controls.Add(this.tTipo);
            this.Controls.Add(this.lTipo);
            this.Controls.Add(this.lCond);
            this.Controls.Add(this.tCNPJ);
            this.Controls.Add(this.lCNPJ);
            this.Controls.Add(this.tData);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.tNumero);
            this.Controls.Add(this.lNumero);
            this.Controls.Add(this.bLancar);
            this.Controls.Add(this.Menus);
            this.MainMenuStrip = this.Menus;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.ShowInTaskbar = false;
            this.Text = "Lançador de Notas de Venda para Siscorp";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Menus.ResumeLayout(false);
            this.Menus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLancar;
        private System.Windows.Forms.Label lNumero;
        private System.Windows.Forms.Label tNumero;
        private System.Windows.Forms.Label tData;
        private System.Windows.Forms.Label lData;
        private System.Windows.Forms.Label tCNPJ;
        private System.Windows.Forms.Label lCNPJ;
        private System.Windows.Forms.Label lCond;
        private System.Windows.Forms.Label lTipo;
        private System.Windows.Forms.Label tTipo;
        private System.Windows.Forms.Label lValor;
        private System.Windows.Forms.Label tValor;
        private System.Windows.Forms.Label lEO;
        private System.Windows.Forms.Label tEO;
        private System.Windows.Forms.Label lICMSPor;
        private System.Windows.Forms.Label tICMSPor;
        private System.Windows.Forms.Label lSubsT;
        private System.Windows.Forms.Label tSubsT;
        private System.Windows.Forms.CheckedListBox listaNotas;
        private System.Windows.Forms.MenuStrip Menus;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog procurarPastaXML;
        private System.Windows.Forms.Button bProx;
        private System.Windows.Forms.Button bAnt;
        private System.Windows.Forms.Label lPasta;
        private System.Windows.Forms.Label tPasta;
        private System.Windows.Forms.Label tICMSV;
        private System.Windows.Forms.Label lICMSV;
        private System.Windows.Forms.Label tNat;
        private System.Windows.Forms.Label lNat;
        private System.Windows.Forms.ComboBox tCond;
        private System.Windows.Forms.Label lNatual;
        private System.Windows.Forms.Label lNtotal;
        private System.Windows.Forms.Label lDest;
        private System.Windows.Forms.ComboBox tDest;
        private System.Windows.Forms.Button bBuscar;
    }
}

