using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Sistema
{
    public class UsuarioCD
    {
        public static List<CP_ListarUsuarioResult> ListarLoginFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarUsuario(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Login.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Usuario> ListarLogin()
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.Usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Login.", ex);
            }
            finally
            {
                DB = null;
            }
        }

    }
}
