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
using Entidades.Sistema;

namespace Presentacion.Formularios
{
    public partial class InventarioRepuestos : Form
    {
        public static List<DetalleFactura> listaAdicional;
        public InventarioRepuestos(int idFactura, List<DetalleFactura> lista)
        {
            InitializeComponent();
            this.CenterToParent();
            listaAdicional = lista;
            mostrarRepuestos("");
            textBox4.Text = "1";
            textBox1.Text = idFactura.ToString();
        }        
        public int verifica=0;
        public int acumulador=0;
        public DetalleFactura detalleFactura;
        RepuestoLN repuestoLN = new RepuestoLN();
        public Repuesto repuesto = new Repuesto();


        public void mostrarRepuestos(string mensaje)
        {
            dataGridView1.DataSource = repuestoLN.MostrarRepuestoFiltro(mensaje);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                repuesto = dataGridView1.CurrentRow.DataBoundItem as Repuesto;
                textBox2.Text = repuesto.IdRepuesto.ToString();
                textBox3.Text = repuesto.Nombre;
                textBox5.Text = repuesto.PrecioVenta.ToString();
                //detalleFactura = new DetalleFactura(int.Parse(textBox1.Text),int.Parse(textBox2.Text),int.Parse(textBox4.Text),
                  //  decimal.Parse(textBox5.Text));
                //recorriendoLista();                
            }
        }

        public void recorriendoLista()
        {            
            for (int i = 0; i < listaAdicional.Count; i++)
            {
                if (listaAdicional[i].IdProducto == repuesto.IdRepuesto)
                {
                    verifica = (verifica + listaAdicional[i].Cantidad) + int.Parse(textBox4.Text);
                    //verifica = verifica + int.Parse(textBox4.Text);
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            detalleFactura = new DetalleFactura(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox4.Text),
                  decimal.Parse(textBox5.Text));
            recorriendoLista();
            if (int.Parse(textBox4.Text) > repuesto.Stock || verifica > repuesto.Stock )
            {
                MessageBox.Show("Cantidad no disponible en el stock del repuesto seleccionado...");
                verifica = 0;
            }
            else
            {
                detalleFactura.Cantidad = int.Parse(textBox4.Text);                
                FrmFactura op = new FrmFactura(detalleFactura);
                op.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmFactura oc = new FrmFactura();
            oc.Show();
            this.Close();
        }


    }
}
