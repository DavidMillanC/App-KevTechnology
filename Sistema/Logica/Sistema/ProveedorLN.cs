using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades.Sistema;
using Proveedor = Entidades.Sistema.Proveedor;

namespace Logica.Sistema
{
    public class ProveedorLN
    {
        public List<Proveedor> MostrarProveedorFitro(string busqueda)
        {
            List<Proveedor> Lista = new List<Proveedor>();
            Proveedor oc;
            try
            {
                List<CP_ListarProveedorResult> auxLista = ProveedorCD.ListarProveedorFiltro(busqueda);
                foreach (CP_ListarProveedorResult aux in auxLista)
                {

                    oc = new Proveedor(aux.IdProveedor, aux.Nombre, aux.Representante, aux.Direccion, aux.Ciudad, aux.Teléfono);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Proveedor.", ex);
            }
            return Lista;
        }

        public List<Proveedor> MostrarProveedores()
        {
            List<Proveedor> Lista = new List<Proveedor>();
            Proveedor oc;
            try
            {
                List<Datos.Proveedor> auxLista = ProveedorCD.ListarProveedor();
                foreach (Datos.Proveedor aux in auxLista)
                {

                    oc = new Proveedor(aux.IdProveedor, aux.Nombre, aux.Representante, aux.Direccion, aux.Ciudad, aux.Teléfono);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Proveedor.", ex);
            }
            return Lista;
        }

        public bool CreateProveedor(Proveedor oc)
        {
            try
            {
                ProveedorCD.InsertarProveedor(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Proveedor.", ex);
            }
        }
        public bool UpdateProveedor(Proveedor oc)
        {
            try
            {
                ProveedorCD.ActualizarProveedor(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar Proveedor.", ex);
            }
        }

        public bool DeleteProveedor(Proveedor oc)
        {
            try
            {
                ProveedorCD.EliminarProveedor(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Proveedor.", ex);
            }
        }
    }
}
