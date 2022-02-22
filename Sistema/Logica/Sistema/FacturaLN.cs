using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades.Sistema;
using Factura = Entidades.Sistema.Factura;

namespace Logica.Sistema
{
    public class FacturaLN
    {
        public List<Factura> MostrarFacturaFiltro(string busqueda)
        {
            List<Factura> Lista = new List<Factura>();
            Factura oc;
            try
            {
                List<CP_ListarFacturaResult> auxLista = FacturaCD.ListarRepuestoFiltro(busqueda);
                foreach (CP_ListarFacturaResult aux in auxLista)
                {

                    oc = new Factura(aux.IdFactura,aux.CedulaCliente,aux.Fecha,aux.Subtotal.GetValueOrDefault(),aux.Iva.GetValueOrDefault()
                        ,aux.Descuento.GetValueOrDefault(),aux.Total.GetValueOrDefault());
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Factura.", ex);
            }
            return Lista;
        }

        public List<Factura> MostrarFactura()
        {
            List<Factura> Lista = new List<Factura>();
            Factura oc;
            try
            {
                List<Datos.Factura> auxLista = FacturaCD.ListarFactura();
                foreach (Datos.Factura aux in auxLista)
                {

                    oc = new Factura(aux.IdFactura, aux.CedulaCliente, aux.Fecha, aux.Subtotal.GetValueOrDefault(), aux.Iva.GetValueOrDefault()
                        , aux.Descuento.GetValueOrDefault(), aux.Total.GetValueOrDefault());
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Factura.", ex);
            }
            return Lista;
        }

        public bool CreateFactura(Factura oc)
        {
            try
            {
                FacturaCD.InsertarFactura(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Factura.", ex);
            }
        }
        public bool UpdateFactura(Factura oc)
        {
            try
            {
                FacturaCD.ActualizarFactura(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar Factura.", ex);
            }
        }

        public bool DeleteFactura(Factura oc)
        {
            try
            {
                FacturaCD.EliminarFactura(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Factura.", ex);
            }
        }
    }
}
