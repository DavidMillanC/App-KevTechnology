using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades.Sistema;
using Repuesto = Entidades.Sistema.Repuesto;

namespace Logica.Sistema
{
    public class RepuestoLN
    {
        public List<Repuesto> MostrarRepuestoFiltro(string busqueda)
        {
            List<Repuesto> Lista = new List<Repuesto>();
            Repuesto oc;
            try
            {
                List<CP_ListarRepuestoResult> auxLista = RepuestoCD.ListarRepuestoFiltro(busqueda);
                foreach (CP_ListarRepuestoResult aux in auxLista)
                {

                    oc = new Repuesto(aux.IdRepuesto,aux.Nombre,aux.IdCategoria,aux.IdProveedor,aux.PrecioFabrica,aux.PrecioVenta,aux.Stock);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Repuesto.", ex);
            }
            return Lista;
        }

        public List<Repuesto> MostrarRepuesto()
        {
            List<Repuesto> Lista = new List<Repuesto>();
            Repuesto oc;
            try
            {
                List<Datos.Repuesto> auxLista = RepuestoCD.ListarRepuesto();
                foreach (Datos.Repuesto aux in auxLista)
                {

                    oc = new Repuesto(aux.IdRepuesto, aux.Nombre, aux.IdCategoria, aux.IdProveedor, aux.PrecioFabrica, aux.PrecioVenta, aux.Stock);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Repuesto.", ex);
            }
            return Lista;
        }

        public bool CreateRepuesto(Repuesto oc)
        {
            try
            {
                RepuestoCD.InsertarRepuesto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Repuesto.", ex);
            }
        }
        public bool UpdateRepuesto(Repuesto oc)
        {
            try
            {
                RepuestoCD.ActualizarRepuesto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar Repuesto.", ex);
            }
        }

        public bool DeleteRepuesto(Repuesto oc)
        {
            try
            {
                RepuestoCD.EliminarRepuesto(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Repuesto.", ex);
            }
        }
    }
}
