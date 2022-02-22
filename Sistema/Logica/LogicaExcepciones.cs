using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    class LogicaExcepciones : ApplicationException
    {
            /// Construye una instancia en base a un mensaje de error y la una excepción original.
            /// <param name="mensaje">El mensaje de error.</param>
            /// <param name="original">La excepción original.</param>
            public LogicaExcepciones(string mensaje, Exception original)
            : base(mensaje, original)
            {
            }

            /// Construye una instancia en base a un mensaje de error.
            /// <param name="mensaje">El mensaje de error.</param>
            public LogicaExcepciones(string mensaje)
                : base(mensaje)
            {
            }
        }
}
