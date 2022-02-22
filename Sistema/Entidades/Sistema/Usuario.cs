using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Usuario
    {
        //private int idUsuario;
        private string nombreUsuario;
        private string contrasena;

        public Usuario()
        {
        }

        public Usuario( string nombreUsuario, string contrasena)
        {
          //  this.IdUsuario = idUsuario;
            this.NombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            this.Contrasena = contrasena ?? throw new ArgumentNullException(nameof(contrasena));
        }

        //public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
