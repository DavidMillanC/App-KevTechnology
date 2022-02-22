using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades.Sistema;

namespace Logica.Sistema
{
    public class DetalleFacturaLN
    {
        public List<DetalleFactura> MostrarDetalleFacturaFiltro(string busqueda)
        {
            List<DetalleFactura> Lista = new List<DetalleFactura>();
            DetalleFactura oc;
            try
            {
                List<CP_ListarDetalle_FacturaResult> auxLista = DetalleFacturaCD.ListarDetalleFacturaFiltro(busqueda);
                foreach (CP_ListarDetalle_FacturaResult aux in auxLista)
                {

                    oc = new DetalleFactura(aux.IdFactura,aux.IdProducto,aux.Cantidad.GetValueOrDefault(),aux.Precio);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar DetalleFactura.", ex);
            }
            return Lista;
        }


        public bool CreateDetalleFactura(DetalleFactura oc)
        {
            try
            {
                DetalleFacturaCD.InsertarDetalleFactura(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear DetalleFactura.", ex);
            }
        }
       

        public bool DeleteDetalleFactura(DetalleFactura oc)
        {
            try
            {
                DetalleFacturaCD.EliminarDetalleFactura(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar DetalleFactura.", ex);
            }
        }
    }
}
