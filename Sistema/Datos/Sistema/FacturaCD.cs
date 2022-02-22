using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Datos.Sistema
{
    public class FacturaCD
    {
        public static List<CP_ListarFacturaResult> ListarRepuestoFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarFactura(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<Factura> ListarFactura()
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.Factura.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarFactura(Entidades.Sistema.Factura oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_InsertarFactura(oc.IdFactura,oc.Cedula,oc.Fecha,oc.Subtotal,oc.Iva,oc.Descuento,oc.Total);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        public static void ActualizarFactura(Entidades.Sistema.Factura oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_ActualizarFactura(oc.IdFactura,oc.Cedula, oc.Fecha, oc.Subtotal, oc.Iva, oc.Descuento, oc.Total);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al actualizar Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarFactura(Entidades.Sistema.Factura oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_EliminarFactura(oc.IdFactura);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
