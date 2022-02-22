using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosExcepciones:ApplicationException
    {
        /// Construye una instancia en base a un mensaje de error y la una excepción original.
        /// <param name="mensaje">El mensaje de error.</param>
        /// <param name="original">La excepción original.</param>
        public DatosExcepciones(string mensaje, Exception original)
            : base(mensaje, original)
        {
        }

        /// Construye una instancia en base a un mensaje de error.
        /// <param name="mensaje">El mensaje de error.</param>
        public DatosExcepciones(string mensaje)
            : base(mensaje)
        {
        }
    }
}
