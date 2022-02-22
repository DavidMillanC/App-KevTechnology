using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Datos.Sistema
{
    public class RepuestoCD
    {
        public static List<CP_ListarRepuestoResult> ListarRepuestoFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarRepuesto(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Repuesto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Repuesto> ListarRepuesto()
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.Repuesto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Repuesto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarRepuesto(Entidades.Sistema.Repuesto oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_InsertarRepuesto(oc.Nombre,oc.IdCategoria,oc.IdProveedor,oc.PrecioFabrica,oc.PrecioVenta,oc.Stock);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Repuesto.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarRepuesto(Entidades.Sistema.Repuesto oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_ActualizarRepuesto(oc.IdRepuesto,oc.Nombre, oc.IdCategoria, oc.IdProveedor, oc.PrecioFabrica, oc.PrecioVenta, oc.Stock);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar Repuesto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarRepuesto(Entidades.Sistema.Repuesto oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_EliminarRepuesto(oc.IdRepuesto);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Repuesto.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
