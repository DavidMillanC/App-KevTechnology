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
    public partial class FrmRepuestos : Form
    {
        
        public FrmRepuestos()
        {
            InitializeComponent();
            this.CenterToParent();
            mostrarRepuesto("");           
        }

        CategoriaLN categoriaLN = new CategoriaLN();
        ProveedorLN proveedorLN = new ProveedorLN();        
        public Repuesto repuesto = new Repuesto();
        RepuestoLN repuestoLN = new RepuestoLN();
        public int opc;
        public string idRep;


        public void mostrarRepuesto(string mensaje)
        {
            dataGridView1.DataSource = repuestoLN.MostrarRepuestoFiltro(mensaje);
        }

        public void rellenarComboCategoria()
        {
            for (int i = 0; i < categoriaLN.MostrarCategoria().Count; i++)
            {
                comboBox1.Items.Add(categoriaLN.MostrarCategoria()[i].Nombre);                
            }
        }

        public void rellenarComboProveedor()
        {
            for (int i = 0; i < proveedorLN.MostrarProveedores().Count; i++)
            {
                comboBox2.Items.Add(proveedorLN.MostrarProveedores()[i].Nombre);                
            }
        }

        public int busarIdCategoria()
        {
            int id=0;
            for (int i = 0; i < categoriaLN.MostrarCategoria().Count; i++)
            {
                if (categoriaLN.MostrarCategoria()[i].Nombre.Equals(comboBox1.Text))
                {
                    id = categoriaLN.MostrarCategoria()[i].IdCategoria;
                }
            }
            return id;
        }

        public string buscarNameCategoria(Repuesto repuesto)
        {
            string name = "";
            for (int i = 0; i < categoriaLN.MostrarCategoria().Count; i++)
            {
                if (categoriaLN.MostrarCategoria()[i].IdCategoria == repuesto.IdCategoria)
                {
                    name = categoriaLN.MostrarCategoria()[i].Nombre;
                }
            }
            return name;
        }

        public int busarIdProveedor()
        {
            int id = 0;
            for (int i = 0; i < proveedorLN.MostrarProveedores().Count; i++)
            {
                if (proveedorLN.MostrarProveedores()[i].Nombre.Equals(comboBox2.Text))
                {
                    id = proveedorLN.MostrarProveedores()[i].IdProveedor;
                }
            }
            return id;
        }

        public string buscarNameProveedor(Repuesto repuesto)
        {
            string name = "";
            for (int i = 0; i < proveedorLN.MostrarProveedores().Count; i++)
            {
                if (proveedorLN.MostrarProveedores()[i].IdProveedor == repuesto.IdProveedor)
                {
                    name = proveedorLN.MostrarProveedores()[i].Nombre;
                }
            }
            return name;
        }

        public void limpiar()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        public Repuesto crearObjetoRepuesto()
        {
            int idRe = repuesto.IdRepuesto;
            string nombre = textBox1.Text;
            int idCategoria = busarIdCategoria();
            int idProveedor = busarIdProveedor();
            decimal precioFab = decimal.Parse(textBox4.Text);
            decimal precioVenta = decimal.Parse(textBox5.Text);
            int stock = int.Parse(textBox6.Text);

            Repuesto oc = new Repuesto(idRe, nombre, idCategoria, idProveedor, precioFab, precioVenta, stock);
            return oc;
        }

        public void nuevaRepuesto()
        {
            try
            {
                opc = 1;
                Repuesto oc = crearObjetoRepuesto();
                repuestoLN.CreateRepuesto(oc);
                MessageBox.Show("Se ha ingresado el repuesto...");
                mostrarRepuesto("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el repuesto..." + ex.Message);
            }
        }
        private bool validarDatos()
        {
            bool verificar = true;
            if (textBox1.Text.Trim().Length == 0 && textBox4.Text.Trim().Length == 0 &&
                textBox5.Text.Trim().Length == 0 && textBox6.Text.Trim().Length == 0)
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
                    nuevaRepuesto();
                }
                else
                {
                    MessageBox.Show("Los campos con (*) son obligatorios");
                    //label11.Text = "Los campos con (*) son obligatorios";
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
                repuesto = dataGridView1.CurrentRow.DataBoundItem as Repuesto;
                idRep = repuesto.IdCategoria.ToString();
                textBox1.Text = repuesto.Nombre;
                comboBox1.Text = buscarNameCategoria(repuesto);
                comboBox2.Text = buscarNameProveedor(repuesto);
                textBox4.Text = repuesto.PrecioFabrica.ToString();
                textBox5.Text = repuesto.PrecioVenta.ToString();
                textBox6.Text = repuesto.Stock.ToString();
            }
        }

        private void actualizar()
        {
            try
            {
                Repuesto oc = crearObjetoRepuesto();
                repuestoLN.UpdateRepuesto(oc);
                MessageBox.Show("Se ha actualizado el repuesto seleccionado...");
                mostrarRepuesto("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el repuesto seleccionado" + ex.Message);

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
                        Repuesto oc = dataGridView1.CurrentRow.DataBoundItem as Repuesto;
                        if (repuestoLN.DeleteRepuesto(oc))
                        {
                            MessageBox.Show("Se ha eliminado el repuesto seleccionado...");
                        }
                    }
                }
                mostrarRepuesto("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el repuesto seleccionado" + ex.Message);
            }
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            rellenarComboCategoria();
            rellenarComboProveedor();
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
