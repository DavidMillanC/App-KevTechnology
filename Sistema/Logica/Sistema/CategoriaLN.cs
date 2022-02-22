using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Sistema;
using Entidades.Sistema;
using Categoria = Entidades.Sistema.Categoria;

namespace Logica.Sistema
{
    public class CategoriaLN
    {
        public List<Categoria> MostrarCategoriaFiltro(string busqueda)
        {
            List<Categoria> Lista = new List<Categoria>();
            Categoria oc;
            try
            {
                List<CP_ListarCategoriaResult> auxLista = CategoriaCD.ListarCategoriaFiltro(busqueda);
                foreach (CP_ListarCategoriaResult aux in auxLista)
                {

                    oc = new Categoria(aux.IdCategoria, aux.Nombre, aux.Descripcion);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Categoria.", ex);
            }
            return Lista;
        }

        public List<Categoria> MostrarCategoria()
        {
            List<Categoria> Lista = new List<Categoria>();
            Categoria oc;
            try
            {
                List<Datos.Categoria> auxLista = CategoriaCD.ListarCategoria();
                foreach (Datos.Categoria aux in auxLista)
                {

                    oc = new Categoria(aux.IdCategoria, aux.Nombre, aux.Descripcion);
                    Lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Categoria.", ex);
            }
            return Lista;
        }

        public bool CreateCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.InsertarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al crear Categoria.", ex);
            }
        }
        public bool UpdateCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.ActualizarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Actualizar Categoria.", ex);
            }
        }

        public bool DeleteCategoria(Categoria oc)
        {
            try
            {
                CategoriaCD.EliminarCategoria(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Categoria.", ex);
            }
        }
    }
}
