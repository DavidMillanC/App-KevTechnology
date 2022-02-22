using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades;
using Usuario = Entidades.Sistema.Usuario;

namespace Logica.Sistema
{
    public class UsuarioLN
    {
        public List<Entidades.Sistema.Usuario> MostrarUsuarioFitro(string busqueda)
        {
            List<Usuario> Lista = new List<Usuario>();
            Usuario oc;
            try
            {
                List<CP_ListarUsuarioResult> auxLista = UsuarioCD.ListarLoginFiltro(busqueda);
                foreach (CP_ListarUsuarioResult aux in auxLista)
                {

                    oc = new Usuario(aux.Usuario,aux.Contraseña);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Login.", ex);
            }
            return Lista;
        }
        public List<Usuario> MostrarUsuario()
        {
            List<Usuario> Lista = new List<Usuario>();
            Usuario oc;
            try
            {
                List<Datos.Usuario> auxLista = UsuarioCD.ListarLogin();
                foreach (Datos.Usuario aux in auxLista)
                {

                    oc = new Usuario(aux.Usuario1, aux.Contraseña);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Login.", ex);
            }
            return Lista;
        }
    }
}
