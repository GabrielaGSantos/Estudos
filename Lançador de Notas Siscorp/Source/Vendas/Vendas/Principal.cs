using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

// Escrito por Vitor Bruno de Oliveira Barth
// Nos últimos dias de 2015
// Criado para ler uma NFe de venda da Valença da Bahia Maricultura e AAT International e lançar no sistema Siscorp via RDP 

namespace Vendas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        // Único meio de enviar teclas por RDP que eu descobri:  
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const int KEYEVENTF_KEYUP = 0x0002;

        // Variáveis públicas 
        int contador = 0;
        string vers = "Release 4.1.0";
        string CompilationTime = "10/03/2016 - 16:41";
        string pasta = "";
        string[] notas = new string[0];
        string nome, endereco, cidade, cep, estado, NotaBuscar;
        

        // Faz a janela ficar em segundo plano SEMPRE
        protected override CreateParams CreateParams
        {

            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        // Carregar o formulário
        private void Principal_Load(object sender, EventArgs e)
        {
            // Janela sempre na frente das outras
            this.TopMost = true;

            // Resize bloqueado
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Não permite o usuário selecionar as notas
            listaNotas.SelectionMode = SelectionMode.None;

            // Botões bloqueados ara evitar crashes
            bAnt.Enabled = false;
            bProx.Enabled = false;
            bLancar.Enabled = false;
            bBuscar.Enabled = false;
        }

        // Apertar botão lançar
        public void bLancar_Click(object sender, EventArgs e)
        {
            bLancar.Enabled = false;
           string numero, data, cnpj, pagamento, tipo, nparcelas, valor, EO, ICMS;
            bool substritbutaria;

            // Ler os valores dos labels preenchidos no método LerNota()

            if (tNat.Text == "Vendas" || tNat.Text == "Venda")
            {
                numero = tNumero.Text;
                data = tData.Text;
                cnpj = tCNPJ.Text;
                tipo = tTipo.Text;
                valor = tValor.Text;
                EO = tEO.Text;
                if (EO == "816701")
                {
                    pagamento = "AV";
                }
                else {
                    if (tCond.Items.Count == 1)
                        pagamento = tCond.Items[0].ToString().Remove(3);
                    else
                        pagamento = tCond.Items.Count + "A";
                }
                ICMS = tICMSPor.Text;
                substritbutaria = bool.Parse(tSubsT.Text);
                nparcelas = tCond.Items.Count.ToString();

                string[] parcelas = new string[Convert.ToInt32(nparcelas)];

                for (int i = 0; i < Convert.ToInt32(nparcelas); i++)
                    parcelas[i] = tCond.Items[i].ToString();


                lancarNota(numero, data, cnpj, pagamento, tipo, valor, EO, Convert.ToInt32(nparcelas), parcelas, ICMS, substritbutaria);

                bProx.PerformClick();
            }

            else
                bProx.PerformClick();

            bLancar.Enabled = true;
        }

        // Ações para queando for apertada a nota
        public void pressKey(string sKey)
        {
            if (sKey == "A")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x1E, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x9E, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "B")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x30, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xB0, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "C")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x2E, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xAE, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "D")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x20, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA0, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "E")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x12, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x92, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "F")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x21, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA1, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "G")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x22, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA2, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "H")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x23, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA3, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "I")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x17, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x97, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "J")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x24, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA4, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "K")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x25, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA5, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "L")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x26, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xA6, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "M")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x32, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xB2, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "N")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x31, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xB1, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "O")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x18, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x98, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "P")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x19, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x99, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "Q")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x10, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x90, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "R")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x13, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x93, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "S")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x1F, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x97, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "T")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x14, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x94, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "U")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x16, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x96, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "V")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x2F, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xAF, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "W")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x11, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x91, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "X")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x2D, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xAD, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "Y")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x15, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x95, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "Z")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x2C, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0xAC, KEYEVENTF_KEYUP, 0);
            }

            // ESPECIAL

            if (sKey == "Ent")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("E")), 0x1C, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("E")), 0x9C, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "Tab")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x0F, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x8F, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "CtrlA")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("C")), 0x1D, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("A")), 0x1E, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("A")), 0x9E, KEYEVENTF_KEYUP, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("C")), 0x9D, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == ",")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("V")), 0x33, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("V")), 0xB3, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "ShiftTab")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("S")), 0x2A, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x0F, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x8F, KEYEVENTF_KEYUP, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("S")), 0xAA, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "AltT")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("A")), 0x38, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x14, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("T")), 0x94, KEYEVENTF_KEYUP, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("A")), 0xB8, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "Up")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("D")), 0x48, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("D")), 0xC8, 0, 0);
            }
            if (sKey == "Esc")
            {
                keybd_event(Convert.ToByte(Convert.ToChar("E")), 0x01, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar("E")), 0x81, 0, 0);
            }

            // NUMBERS
            if (sKey == "1")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x02, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x82, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "2")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x03, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x83, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "3")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x04, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x84, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "4")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x05, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x85, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "5")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x06, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x86, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "6")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x07, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x87, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "7")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x08, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x88, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "8")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x09, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x89, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "9")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x0A, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x8A, KEYEVENTF_KEYUP, 0);
            }
            if (sKey == "0")
            {
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x0B, 0, 0);
                keybd_event(Convert.ToByte(Convert.ToChar(sKey)), 0x8B, KEYEVENTF_KEYUP, 0);
            }
        }

        // Converte uma string em um array de chars e realiza um pressKey pra cada tecla
        public void digitar(string valor)
        {
            char[] matrizTexto = valor.ToCharArray();

            for (int i = 0; i < valor.Length; i++)
                pressKey(Convert.ToString(matrizTexto[i]).ToUpper());
        }

        // Digita a nota no RDP
        public void lancarNota(string numero, string data, string cnpj, string pagamento, string tipo, string valor, string EO, int nparcelas, string[] parcelas, string ICMS, bool substritbutaria)
        {
            // Chegar em Documento
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(0.1).TotalMilliseconds);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(0.1).TotalMilliseconds);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(0.1).TotalMilliseconds);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(0.1).TotalMilliseconds);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(0.1).TotalMilliseconds);
            pressKey("CtrlA");

            // Digitar documento
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            digitar(numero);
            pressKey("Ent");

            // Digitar data
            digitar(data);
            pressKey("Ent");

            // Digitar CNPF/CPF
            digitar(cnpj);
            pressKey("Ent");

            // Digitar data
            digitar(data);
            pressKey("Ent");
            pressKey("Ent");

            // Digitar cond de pagamento
            digitar(pagamento);
            pressKey("Ent");
            pressKey("Tab");
            pressKey("Ent");
            pressKey("Ent");

            // Digitar Tipo
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            digitar(tipo);
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(.8).TotalMilliseconds);
            pressKey("Ent");
            pressKey("Ent");
            digitar("1");
            pressKey("Ent");

            // Digitar Valor
            digitar(valor);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            digitar(EO);
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            pressKey("Ent");
            pressKey("Ent");
            pressKey("Ent");
            pressKey("Ent");
            pressKey("Ent");
            pressKey("Ent");

            // Digitar o ICMS
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(.5).TotalMilliseconds);
            digitar(ICMS);
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            pressKey("Ent");
            pressKey("Ent");
            pressKey("Ent");

            pressKey("Ent");

            pressKey("Ent");

            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            pressKey("Ent");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            pressKey("Esc");
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);

            // Lança as parcelas
            if (nparcelas > 1)
            {
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                pressKey("AltT");
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                pressKey("P");
                string[] parcelaAtual = new string[3];

                parcelas[0].Replace(" | ", "|");
                parcelaAtual = parcelas[Convert.ToInt32(nparcelas) - 1].Split('|');

                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                digitar(parcelaAtual[2]);
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                pressKey("Tab");

                digitar(parcelaAtual[1]);
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);


                for (int i = 1; i < nparcelas; i++)
                {
                    pressKey("ShiftTab");

                    pressKey("Up");

                    parcelas[Convert.ToInt32(nparcelas)-1-i].Replace(" | ", "|");
                    parcelaAtual = parcelas[Convert.ToInt32(nparcelas) - 1 - i].Split('|');

                    System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                    digitar(parcelaAtual[2]);
                    System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                    pressKey("Tab");

                    digitar(parcelaAtual[1]);
                    System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);

                }
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1.2).TotalMilliseconds);
                pressKey("Esc");
            }

            // Substituição tributária
            if (EO != "816701")
            {
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1.2).TotalMilliseconds);
                pressKey("Ent");
                if (substritbutaria)
                    pressKey("Ent");
                else
                    pressKey("Tab");
                System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
                pressKey("Tab");
            }

            // Finaliza

            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            pressKey("Ent");
        }   

        // Calcula a condição de pagamento (apenas para 1 pagamento)
        public string condPagamento(string saida, string pagto)
        {
            string cond = "0";

            char[] matrizSaida = saida.ToCharArray();

            int diaSaida = Convert.ToInt32(matrizSaida[0] + "" + matrizSaida[1]);
            int mesSaida = Convert.ToInt32(matrizSaida[2] + "" + matrizSaida[3]);
            int anoSaida = Convert.ToInt32(matrizSaida[4] + "" + matrizSaida[5] + "" + matrizSaida[6] + "" + matrizSaida[7]);

            char[] matrizPagto = pagto.ToCharArray();

            int diaPagto = Convert.ToInt32(matrizPagto[0] + "" + matrizPagto[1]);
            int mesPagto = Convert.ToInt32(matrizPagto[2] + "" + matrizPagto[3]);
            int anoPagto = Convert.ToInt32(matrizPagto[4] + "" + matrizPagto[5] + "" + matrizPagto[6] + "" + matrizPagto[7]);

            DateTime dataPagto = new DateTime(anoPagto, mesPagto, diaPagto);
            DateTime dataSaida = new DateTime(anoSaida, mesSaida, diaSaida);

            cond = Convert.ToString((dataPagto - dataSaida).Days);


            if (cond == "0")
                return "AV";

            else if (Convert.ToInt32(cond) < 10)
                return "0" + cond;

            else
                return cond;
        }

        // Ação Arquivo -> Carregar Notas
        private void carregarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpa o CheckboxList
            listaNotas.Items.Clear();
            tCond.Items.Clear();

            // Mostra o dialogo de pasta e coloca a pasta selecionada na string pasta
            procurarPastaXML.ShowDialog();
            pasta = procurarPastaXML.SelectedPath;
            tPasta.Text = pasta;

            // Se pasta não for selecionada, não crasha
            if (tPasta.Text == "")
            {
                pasta = "";
                tPasta.Text = "_";
            }

            // Se pasta for selecionada, tenta pegar os XML
            else
                notas = Directory.GetFiles(@pasta, "*.xml");

            listaNotas.Items.Remove("NENHUMA NOTA SELECIONADA");

            // Se tiver notas na pasta vai criar um checkbox pra cada e vai ler a primeira nota
            for (int i = 0; i < notas.Length; i++)
            {
                listaNotas.Items.Add(notas[i].Remove(0, pasta.Length+1));
                bLancar.Enabled = true;
                bProx.Enabled = true;
                bBuscar.Enabled = true;
                listaNotas.SetItemChecked(0, true);
                contador = 1;
                tCond.Items.Clear();
                lerNota();
            }

            // Se não tiver notas vai aparecer um erro e não crashar
            if (listaNotas.Items.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo XML na pasta selecionada", "Erro");
                pasta = "";
                tPasta.Text = "_";
                listaNotas.Items.Add("NENHUMA NOTA SELECIONADA");
            }

            // Numero de notas
            lNtotal.Text = ("/ " + listaNotas.Items.Count);
            lNatual.Text = "1";
        }
         
        // Ação quando clica o botão Próximo
        private void bProx_Click(object sender, EventArgs e)
        {
            // Marca o peóximo item e aumenta o contador
            if (Convert.ToInt32(lNtotal.Text.Replace("/ ", "")) != 1)
            {
                listaNotas.SetItemChecked(contador, true);
                contador++;

                // Condições para bloquear os botões se atingir os limites
                if (contador == listaNotas.Items.Count)
                    bProx.Enabled = false;
                if (contador > 1)
                    bAnt.Enabled = true;
                if (contador > listaNotas.Items.Count)
                    contador = listaNotas.Items.Count;
                if (contador <= 1)
                {
                    bAnt.Enabled = false;
                    contador = 1;
                }

                tCond.Items.Clear();
                tDest.Items.Clear();

                // Ler a nota
                lerNota();

                // Nota Atual
                lNatual.Text = (Convert.ToInt32(lNatual.Text) + 1).ToString();
            }
        }

        // Ação quando clica o botão Anterior
        private void bAnt_Click(object sender, EventArgs e)
        {
            // Diminui o contador e desmarca a nota anterior
            contador--;
            listaNotas.SetItemChecked(contador, false);

            // Condições para bloquear os botões se atingir os limites
            if (contador < listaNotas.Items.Count)
                bProx.Enabled = true;
            if (contador <= 1)
            {
                bAnt.Enabled = false;
                contador = 1;
            }

            tCond.Items.Clear();
            tDest.Items.Clear();

            // Ler a nota
            lerNota();

            // Nota Atual
            lNatual.Text = (Convert.ToInt32(lNatual.Text) - 1).ToString();
        }

        // Ler o XML e mandar pros Labels
        private void lerNota()
        {
            string natureza = "", numero = "", filial = "", eo = "", data = "", cnpje = "", cnpj = "", pagamento = "", tipo = "", valor = "", ICMSp = "", ICMSv = "", dParcela = "", vParcela = "";
            bool substritbutaria = true;

            // Carrega o XML
            XmlDocument NotaXML = new XmlDocument();
            NotaXML.Load(notas[contador - 1]);

            // Carrega o nó *ide*
            XmlNodeList ide = NotaXML.GetElementsByTagName("ide");

            // Puxa as informações do nó *ide*
            foreach (XmlNode node in ide)
            {
                XmlElement info = (XmlElement)node;
                numero = info.GetElementsByTagName("nNF")[0].InnerText;
                natureza = info.GetElementsByTagName("natOp")[0].InnerText;
                data = info.GetElementsByTagName("dhEmi")[0].InnerText;
            }

            // Converte a data de AAAAMMDD pra DDMMAAAA
            data = (data.Remove(10).Replace("-", ""));
            char[] dataArray = data.ToCharArray();
            data = Convert.ToString(dataArray[6] + "" + dataArray[7] + "" + dataArray[4] + "" + dataArray[5] + "" + dataArray[0] + "" + dataArray[1] + "" + dataArray[2] + "" + dataArray[3]);

            // Define os valores dos Labels para serem lidos no metodo lancarNota()
            tNat.Text = natureza;
            tNumero.Text = numero;
            tData.Text = data;

            if (natureza == "Vendas" || natureza == "Venda")
            {

                // Carrega o nó *emit*
                XmlNodeList emit = NotaXML.GetElementsByTagName("emit");

                // Puxa as informações do nó *emit*
                foreach (XmlNode node in emit)
                {
                    XmlElement info = (XmlElement)node;
                    cnpje = info.GetElementsByTagName("CNPJ")[0].InnerText;
                }

                // Verifica a filial e define EO
                if (cnpje == "13600911000100")
                {
                    eo = "067501";
                }
                else if (cnpje == "13600911000444")
                {
                    filial = "A";
                    eo = "067502";
                }
                else if (cnpje == "13600911000525")
                {
                    filial = "B";
                    numero = "0" + numero;
                    eo = "067503";
                }
                else if (cnpje == "02288814000107")
                {
                    numero = "0000" + numero;
                    eo = "816701";
                }

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tNumero.Text = "0" + numero + filial;
                tEO.Text = eo;

                // Carrega o nó *dest*
                XmlNodeList dest = NotaXML.GetElementsByTagName("dest");

                // Puxa as informações do nó *dest*
                foreach (XmlNode node in dest)
                {
                    XmlElement info = (XmlElement)node;
                    try
                    {
                        cnpj = info.GetElementsByTagName("CNPJ")[0].InnerText;
                    }
                    catch
                    {
                        cnpj = info.GetElementsByTagName("CPF")[0].InnerText;
                    }
                    nome = info.GetElementsByTagName("xNome")[0].InnerText;
                    endereco = info.GetElementsByTagName("xLgr")[0].InnerText;
                    endereco = endereco + " " + info.GetElementsByTagName("nro")[0].InnerText;
                    endereco = endereco + " " + info.GetElementsByTagName("xBairro")[0].InnerText;
                    cidade = info.GetElementsByTagName("xMun")[0].InnerText;
                    try {
                        cep = info.GetElementsByTagName("CEP")[0].InnerText;
                    }
                    catch
                    {
                        cep = "0000000";
                    }
                    estado = info.GetElementsByTagName("UF")[0].InnerText;
                }

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tCNPJ.Text = cnpj;
                tDest.Items.Add(nome);
                tDest.Items.Add(endereco);
                tDest.Items.Add(cidade + " " + estado + " " + cep);

                // Carrega o nó *prod*
                XmlNodeList prod = NotaXML.GetElementsByTagName("prod");

                // Puxa as informações do nó *prod*
                foreach (XmlNode node in prod)
                {
                    XmlElement info = (XmlElement)node;
                    tipo = info.GetElementsByTagName("xProd")[0].InnerText;
                }

                // Verifica o tipo do produto 
                if (tipo.Contains("CONG") || tipo.Contains("S/C."))
                    tipo = "cong";
                else if (tipo.Contains("FRESC") || tipo.Contains("DESC"))
                    tipo = "fresco";
                else if (tipo.Contains("Tilapia"))
                    tipo = "alevinos";

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tTipo.Text = tipo;

                // Carrega o nó *ICMS*
                XmlNodeList ICMS = NotaXML.GetElementsByTagName("ICMS");

                // Puxa as informações do nó *ICMS*
                foreach (XmlNode node in ICMS)
                {
                    XmlElement info = (XmlElement)node;
                    try {
                        ICMSp = info.GetElementsByTagName("pICMS")[0].InnerText;
                    }
                    catch
                    {
                        ICMSp = "0";
                    }
                }

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tICMSPor.Text = ICMSp;

                // Carrega o nó *ICMSTot*
                XmlNodeList ICMSTot = NotaXML.GetElementsByTagName("ICMSTot");

                // Puxa as informações do nó *ICMSTot*
                foreach (XmlNode node in ICMSTot)
                {
                    XmlElement info = (XmlElement)node;
                    if (substritbutaria || (info.GetElementsByTagName("vDesc")[0].InnerText != "0.00"))
                        valor = info.GetElementsByTagName("vProd")[0].InnerText;
                    else
                        valor = info.GetElementsByTagName("vNF")[0].InnerText;
                    if (info.GetElementsByTagName("vST")[0].InnerText == "0.00")
                        substritbutaria = false;

                    ICMSv = info.GetElementsByTagName("vICMS")[0].InnerText;

                }

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tValor.Text = valor.Replace('.', ',');
                tSubsT.Text = substritbutaria.ToString();
                tICMSV.Text = ICMSv.Replace('.', ',');

                // Carrega o nó *cobr*
                XmlNodeList dup = NotaXML.GetElementsByTagName("dup");

                // Puxa as informações do nó *cobr*
                if  (eo != "816701")
                {
                    foreach (XmlNode node in dup)
                    {
                        XmlElement info = (XmlElement)node;
                        dParcela = info.GetElementsByTagName("dVenc")[0].InnerText;
                        dParcela = dParcela.Replace("-", "");
                        dataArray = dParcela.ToCharArray();
                        dParcela = Convert.ToString(dataArray[6] + "" + dataArray[7] + "" + dataArray[4] + "" + dataArray[5] + "" + dataArray[0] + "" + dataArray[1] + "" + dataArray[2] + "" + dataArray[3]);

                        vParcela = info.GetElementsByTagName("vDup")[0].InnerText;

                        pagamento = condPagamento(data, dParcela);

                        tCond.Items.Add(pagamento + " | " + vParcela.Replace('.', ',') + " | " + dParcela);

                        tCond.SelectedIndex = 0;
                        tDest.SelectedIndex = 0;
                    }
                }
                
                else
                {
                    pagamento = "AV";
                    tCond.Items.Add(pagamento);
                    tCond.SelectedIndex = 0;
                    tDest.SelectedIndex = 0;
                }

                // Define os valores dos Labels para serem lidos no metodo lancarNota()
                tValor.Text = valor.Replace('.', ',');
                tSubsT.Text = substritbutaria.ToString();
                tICMSV.Text = ICMSv.Replace('.', ',');

            }
        }

        // Ação quando Arquivo -> Sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ação Sobre
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desenvolvido por Vitor Bruno de Oliveira Barth \nVersão: " + vers + "\nCompilada em: " + CompilationTime, "Sobre");
        }

        // Ação Buscar
        private void bBuscar_Click(object sender, EventArgs e)
        {
            Form Busca = new Buscar();
            Busca.ShowDialog();
            NotaBuscar = Buscar.ValorDigitado;

            listaNotas.Items.Clear();

            for (int i = 0; i < notas.Length; i++)
            {
                listaNotas.Items.Add(notas[i].Remove(0, pasta.Length + 1));
                bLancar.Enabled = true;
                bProx.Enabled = true;
                listaNotas.SetItemChecked(0, true);
                contador = 1;
                tCond.Items.Clear();
                lerNota();
            }

            // Numero de notas
            lNtotal.Text = ("/ " + listaNotas.Items.Count);
            lNatual.Text = "1";

            lerNota();
            BuscarNota();


        }

        // Buscar a nota digitada
        private void BuscarNota()
        {
            if (listaNotas.Items.Count != 1 && (contador.ToString() != lNtotal.Text.Replace("/ ", "")))
            {
                if (contador.ToString() == lNtotal.Text.Replace("/ ", ""))
                {
                    MessageBox.Show("Nota não encontrada");
                }
                else if (!tNumero.Text.Contains(NotaBuscar))
                {
                    bProx.PerformClick();
                    BuscarNota();
                }  
            }
            else
            {
                MessageBox.Show("Nota não encontrada");
            }
        }
    }
}
