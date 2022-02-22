using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class DetalleFactura
    {
        private int idFactura;
        private int idProducto;
        private int cantidad;
        private decimal precio;

        public DetalleFactura()
        {
        }

        public DetalleFactura(int idFactura, int idProducto, int cantidad, decimal precio)
        {
            this.IdFactura = idFactura;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public int IdFactura { get => idFactura; set => idFactura = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
