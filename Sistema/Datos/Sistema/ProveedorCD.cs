using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos.Sistema
{
    public class ProveedorCD
    {
        public static List<CP_ListarProveedorResult> ListarProveedorFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarProveedor(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Proveedor.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Proveedor> ListarProveedor()
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.Proveedor.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Proveedores.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarProveedor(Entidades.Sistema.Proveedor oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_InsertarProveedor(oc.Nombre, oc.Representante, oc.Direccion, oc.Ciudad, oc.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Proveedor.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarProveedor(Entidades.Sistema.Proveedor oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_ActualizarProveedor(oc.IdProveedor, oc.Nombre, oc.Representante, oc.Direccion, oc.Ciudad, oc.Telefono);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar Proveedor.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarProveedor(Entidades.Sistema.Proveedor oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_EliminarProveedor(oc.IdProveedor);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Proveedor.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
