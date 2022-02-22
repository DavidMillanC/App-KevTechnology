using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Sistema;
using Logica.Sistema;

namespace Presentacion.Formularios
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
            this.CenterToParent();
            mostrarProveedores("");
        }

        public Proveedor p = new Proveedor();
        ProveedorLN proveedorLN = new ProveedorLN();
        Proveedor proveedor = new Proveedor();
        public int opc;
        public string idProve;

        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        public void mostrarProveedores(string buscar)
        {
            dataGridView1.DataSource = proveedorLN.MostrarProveedorFitro(buscar);
        }
        public Proveedor crearObjetoProveedor()
        {
            int id = p.IdProveedor;
            string nombre = textBox1.Text;
            string representante = textBox2.Text;
            string direccion = textBox3.Text;
            string ciudad = textBox4.Text;
            string telefono = textBox5.Text;

            Proveedor oc = new Proveedor(id,nombre,representante,direccion,ciudad,telefono);
            return oc;
        }

        public void nuevoProveedor()
        {
            try
            {
                opc = 1;
                Proveedor oc = crearObjetoProveedor();
                proveedorLN.CreateProveedor(oc);               
                mostrarProveedores("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ", ex.Message);
            }
        }
        private bool validarDatos()
        {
            bool verificar = true;
            if (textBox2.Text.Trim().Length == 0 && textBox1.Text.Trim().Length == 0 &&
                textBox5.Text.Trim().Length == 0 && textBox4.Text.Trim().Length == 0 &&
                textBox3.Text.Trim().Length == 0)
            {
                verificar = false;
            }
            return verificar;
        }

        private void guardar()
        {
            try
            {
                if (validarDatos())
                {
                    nuevoProveedor();
                }
                else
                {                    
                    MessageBox.Show("Los campos con (*) son obligatorios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
            limpiar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                p = dataGridView1.CurrentRow.DataBoundItem as Proveedor;
                idProve = p.IdProveedor.ToString();
                textBox1.Text = p.Nombre;
                textBox2.Text = p.Representante;
                textBox3.Text = p.Direccion;
                textBox4.Text = p.Ciudad;
                textBox5.Text = p.Telefono;                
            }
        }

        private void actualizar()
        {
            try
            {
                Proveedor oc = crearObjetoProveedor();
                proveedorLN.UpdateProveedor(oc);
                MessageBox.Show("Se ha actualizado el Paciente seleccionado...");
                mostrarProveedores("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el Paciente seleccionado " + ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizar();
            limpiar();
        }


        private void eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DialogResult res = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        Proveedor oc = dataGridView1.CurrentRow.DataBoundItem as Proveedor;
                        if (proveedorLN.DeleteProveedor(oc))
                        {
                            MessageBox.Show("Se ha eliminado el Paciente seleccionado...");
                        }
                    }
                }
                mostrarProveedores("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Paciente seleccionado " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eliminar();
            limpiar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Principal oc = new Principal();
            oc.Show();
            this.Close();
        }
    }
}
