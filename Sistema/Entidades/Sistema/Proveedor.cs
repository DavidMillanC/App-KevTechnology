using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Proveedor
    {
        private int idProveedor;
        private string nombre;
        private string representante;
        private string direccion;
        private string ciudad;
        private string telefono;

        public Proveedor()
        {
        }

        public Proveedor(int idProveedor, string nombre, string representante, string direccion, string ciudad, string telefono)
        {
            this.IdProveedor = idProveedor;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Representante = representante ?? throw new ArgumentNullException(nameof(representante));
            this.Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            this.Ciudad = ciudad ?? throw new ArgumentNullException(nameof(ciudad));
            this.Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
        }

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Representante { get => representante; set => representante = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
