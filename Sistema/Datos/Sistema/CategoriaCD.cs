using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Datos.Sistema
{
    public class CategoriaCD
    {
        public static List<CP_ListarCategoriaResult> ListarCategoriaFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarCategoria(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Categoria.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Categoria> ListarCategoria()
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.Categoria.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Catergorias.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarCategoria(Entidades.Sistema.Categoria oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_InsertarCategoria(oc.Nombre,oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Categoria.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarCategoria(Entidades.Sistema.Categoria oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_ActualizarCategoria(oc.IdCategoria,oc.Nombre,oc.Descripcion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar Categoria.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarCategoria(Entidades.Sistema.Categoria oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_EliminarCategoria(oc.IdCategoria);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Categoria.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
