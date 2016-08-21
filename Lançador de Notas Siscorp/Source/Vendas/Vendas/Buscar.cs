using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendas
{
    public partial class Buscar : Form
    {
        public static string ValorDigitado;
        public Buscar()
        {
            InitializeComponent();
            // Janela sempre na frente das outras
            this.TopMost = true;

            // Resize bloqueado
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ValorDigitado = tBuscar.Text;
            this.Close();
        }

        private void tBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button1.PerformClick();
            }

        }
    }
}
