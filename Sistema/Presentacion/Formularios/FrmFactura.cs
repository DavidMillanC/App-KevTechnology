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
    public partial class FrmFactura : Form
    {
        public static List<DetalleFactura> listaDetallesFacturas = new List<DetalleFactura>();
        public DetalleFactura detalleFactura;
        FacturaLN facturaLN = new FacturaLN();
        RepuestoLN repuestoLN = new RepuestoLN();
        DetalleFacturaLN detalleFacturaLN = new DetalleFacturaLN();
        public FrmFactura()
        {
            InitializeComponent();
            mostrarDetalles();
            this.CenterToParent();            
            textBox10.Text = recorreFactura().ToString();
            textBox2.Text = DateTime.Now.ToShortDateString();

        }
        public FrmFactura(DetalleFactura detalle)
        {
            InitializeComponent();
            mostrarDetalles();
            this.CenterToParent();            
            textBox10.Text = recorreFactura().ToString();
            textBox2.Text = DateTime.Now.ToShortDateString();
            detalleFactura = detalle;
            insertarDetalle(detalleFactura);
            
        }
        //Metodos para lista adicional************************
        public void insertarDetalle(DetalleFactura detalle)
        {
            listaDetallesFacturas.Add(detalle);
        }

        public bool EliminarDetalle(DetalleFactura detalle)
        {
            try
            {
                listaDetallesFacturas.Remove(detalle);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show("Error al eliminar Repuesto. ", ex.Message);                
            }
        }
        //*****************************************************

        public void mostrarDetalles()
        {
            dataGridView1.DataSource = listaDetallesFacturas.ToList();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            mostrarDetalles();
            subTotal();
            iva();
            descuento();
            totalPago();
        }

        public int recorreFactura()
        {
            int numero = 1;
            for (int i = 0; i < facturaLN.MostrarFactura().Count; i++)
            {
                numero = numero + 1;
            }
            return numero;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            InventarioRepuestos op = new InventarioRepuestos(int.Parse(textBox10.Text), listaDetallesFacturas);
            op.Show();
            this.Hide();
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
                        DetalleFactura oc = dataGridView1.CurrentRow.DataBoundItem as DetalleFactura;
                        if (EliminarDetalle(oc))
                        {
                            MessageBox.Show("Se ha eliminado el detalle seleccionado...");
                        }
                    }
                }
                mostrarDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el detalle seleccionado" + ex.Message);
            }
        }
        public void limpiar()
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            eliminar();
            subTotal();
            iva();
            descuento();
            totalPago();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                detalleFactura = dataGridView1.CurrentRow.DataBoundItem as DetalleFactura;
                textBox8.Text = detalleFactura.IdProducto.ToString();
                textBox7.Text = detalleFactura.Cantidad.ToString();
                textBox9.Text = detalleFactura.Precio.ToString();
            }
        }

        public void subTotal()
        {
            decimal valor=0;
            for (int i = 0; i < listaDetallesFacturas.Count; i++)
            {
                valor = valor + (listaDetallesFacturas[i].Cantidad * listaDetallesFacturas[i].Precio);
            }
            textBox4.Text = valor.ToString();
        }
        public void iva()
        {
            textBox3.Text = ((decimal.Parse(textBox4.Text) * 12) / 100).ToString();
        }
        public void descuento()
        {
            textBox6.Text = ((decimal.Parse(textBox4.Text)*2)/100).ToString();
        }
        public void totalPago()
        {
            textBox5.Text = ((decimal.Parse(textBox4.Text) + decimal.Parse(textBox3.Text)) - decimal.Parse(textBox6.Text)).ToString();
        }



        public Factura crearObjetoFactura()
        {
            int id = int.Parse(textBox10.Text);
            string cedula = textBox1.Text;
            string fecha = textBox2.Text;
            decimal subtotal = decimal.Parse(textBox4.Text);
            decimal iva = decimal.Parse(textBox3.Text);
            decimal descuento = decimal.Parse(textBox6.Text);
            decimal total = decimal.Parse(textBox5.Text);

            Factura oc = new Factura(id,cedula,DateTime.Parse(fecha),subtotal,iva,descuento,total);
            return oc;
        }
        public void insertarDetalles()
        {            
            DetalleFactura detalle;
            for (int i = 0; i < listaDetallesFacturas.Count; i++)
            {
                detalleFacturaLN.CreateDetalleFactura(listaDetallesFacturas[i]);
                 detalle = listaDetallesFacturas[i];
                for (int j = 0; j < repuestoLN.MostrarRepuesto().Count; j++)
                {
                    if (repuestoLN.MostrarRepuesto()[j].IdRepuesto == detalle.IdProducto)
                    {
                        Repuesto oc = new Repuesto(repuestoLN.MostrarRepuesto()[j].IdRepuesto, repuestoLN.MostrarRepuesto()[j].Nombre,
                            repuestoLN.MostrarRepuesto()[j].IdCategoria, repuestoLN.MostrarRepuesto()[j].IdProveedor, repuestoLN.MostrarRepuesto()[j].PrecioFabrica,
                            repuestoLN.MostrarRepuesto()[j].PrecioVenta,(repuestoLN.MostrarRepuesto()[j].Stock - detalle.Cantidad));
                        textBox7.Text = oc.Stock.ToString();
                        repuestoLN.UpdateRepuesto(oc);
                    }
                }
            }
        }
        public void nuevaFactura()
        {
            try
            {
                //opc = 1;
                Factura oc = crearObjetoFactura();
                facturaLN.CreateFactura(oc);
                insertarDetalles();                
                MessageBox.Show("Se ha ingresado la factura...");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la factura..." + ex.Message);
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
                    nuevaFactura();
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

        private void button4_Click(object sender, EventArgs e)
        {
            guardar();
            FormAllFacturas oc = new FormAllFacturas();
            oc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listaDetallesFacturas = new List<DetalleFactura>();
            FormAllFacturas oc = new FormAllFacturas();
            oc.Show();
            this.Hide();
        }

    }
}
