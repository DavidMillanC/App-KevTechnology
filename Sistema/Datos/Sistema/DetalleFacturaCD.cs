using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Datos.Sistema
{
    public class DetalleFacturaCD
    {
        public static List<CP_ListarDetalle_FacturaResult> ListarDetalleFacturaFiltro(string busqueda)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    return DB.CP_ListarDetalle_Factura(busqueda).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Detalle-Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }
        

        public static void InsertarDetalleFactura(Entidades.Sistema.DetalleFactura oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_InsertarDetalle_Factura(oc.IdFactura,oc.IdProducto,oc.Cantidad,oc.Precio);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Detalle-Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }
       

        public static void EliminarDetalleFactura(Entidades.Sistema.DetalleFactura oc)
        {
            SystemsERDataContext DB = null;
            try
            {
                using (DB = new SystemsERDataContext())
                {
                    DB.CP_EliminarDetalle_Factura(oc.IdFactura);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Detalle-Factura.", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
