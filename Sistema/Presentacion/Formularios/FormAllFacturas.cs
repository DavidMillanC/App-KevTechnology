using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Sistema;

namespace Presentacion.Formularios
{
    public partial class FormAllFacturas : Form
    {
        public FormAllFacturas()
        {
            InitializeComponent();
            this.CenterToParent();
            FacturaLN facturaLN = new FacturaLN();
            dataGridView1.DataSource= facturaLN.MostrarFactura();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Principal oc = new Principal();
            oc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmFactura oc = new FrmFactura();
            oc.Show();
            this.Hide();
        }
    }
}
