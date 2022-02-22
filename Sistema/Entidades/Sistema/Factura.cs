using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Factura
    {
        private int idFactura;
        private string cedula;
        private DateTime fecha;
        private decimal subtotal;
        private decimal iva;
        private decimal descuento;
        private decimal total;

        public Factura()
        {
        }

        public Factura(int idFactura, string cedula, DateTime fecha, decimal subtotal, decimal iva, decimal descuento, decimal total)
        {
            this.IdFactura = idFactura;
            this.Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            this.Fecha = fecha;
            this.Subtotal = subtotal;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
        }

        public int IdFactura { get => idFactura; set => idFactura = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
