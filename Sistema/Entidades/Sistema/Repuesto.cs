using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Repuesto
    {
        private int idRepuesto;
        private string nombre;
        private int idCategoria;
        private int idProveedor;
        private decimal precioFabrica;
        private decimal precioVenta;
        private int stock;

        public Repuesto()
        {
        }

        public Repuesto(int idRepuesto, string nombre, int idCategoria, int idProveedor, decimal precioFabrica, decimal precioVenta, int stock)
        {
            this.IdRepuesto = idRepuesto;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.IdCategoria = idCategoria;
            this.IdProveedor = idProveedor;
            this.PrecioFabrica = precioFabrica;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
        }

        public int IdRepuesto { get => idRepuesto; set => idRepuesto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public decimal PrecioFabrica { get => precioFabrica; set => precioFabrica = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
