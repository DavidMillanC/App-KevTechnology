using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Logica.Sistema;
using Entidades;
using Entidades.Sistema;

namespace Presentacion.Formularios
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
            this.CenterToParent();
            mostrarCategorias("");
        }
        public Categoria cat = new Categoria();
        CategoriaLN CategoriaLN = new CategoriaLN();
        Categoria categoria = new Categoria();
        public int opc;
        public string idCategoria;

        public void mostrarCategorias(string mensaje)
        {
            dataGridView1.DataSource = CategoriaLN.MostrarCategoriaFiltro(mensaje);
        }

        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public Categoria crearObjetoCategoria()
        {
            int id = cat.IdCategoria;
            string nombre = textBox1.Text;
            string descrip = textBox2.Text;

            Categoria oc = new Categoria(id,nombre,descrip);
            return oc;
        }

        public void nuevaCategoria()
        {
            try
            {
                opc = 1;
                Categoria oc = crearObjetoCategoria();
                CategoriaLN.CreateCategoria(oc);
                MessageBox.Show("Se ha ingresado la Categoria...");                
                mostrarCategorias("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Paciente..." + ex.Message);                
            }
        }
        private bool validarDatos()
        {
            bool verificar = true;
            if (textBox2.Text.Trim().Length == 0 && textBox1.Text.Trim().Length == 0)
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
                    nuevaCategoria();
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
                cat = dataGridView1.CurrentRow.DataBoundItem as Categoria;
                idCategoria = cat.IdCategoria.ToString();
                textBox1.Text = cat.Nombre;
                textBox2.Text = cat.Descripcion;                
            }
        }

        private void actualizar()
        {
            try
            {
                Categoria oc = crearObjetoCategoria();
                CategoriaLN.UpdateCategoria(oc);
                MessageBox.Show("Se ha actualizado la categoria seleccionada...");
                mostrarCategorias("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoria seleccionada " + ex.Message);

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
                        Categoria oc = dataGridView1.CurrentRow.DataBoundItem as Categoria;
                        if (CategoriaLN.DeleteCategoria(oc))
                        {
                            MessageBox.Show("Se ha eliminado la categoria seleccionada...");
                        }
                    }
                }
                mostrarCategorias("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoria seleccionada " + ex.Message);
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
