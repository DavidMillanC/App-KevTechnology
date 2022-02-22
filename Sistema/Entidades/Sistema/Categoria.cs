using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Categoria
    {
        private int idCategoria;
        private string nombre;
        private string descripcion;

        public Categoria()
        {
        }

        public Categoria(int idCategoria, string nombre, string descripcion)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
        }

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
