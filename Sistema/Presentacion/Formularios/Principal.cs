using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategoria ob = new FrmCategoria();
            ob.Show();
            this.Hide();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FrmProveedores ob = new FrmProveedores();
            ob.Show();
            this.Hide();
        }

        private void btnRepuestos_Click(object sender, EventArgs e)
        {
            FrmRepuestos ob = new FrmRepuestos();
            ob.Show();
            this.Hide();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            FormAllFacturas ob = new FormAllFacturas();
            ob.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login ob = new Login();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuReportes op = new MenuReportes();
            op.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login oc = new Login();
            oc.Show();
            this.Close();
        }
    }
}
