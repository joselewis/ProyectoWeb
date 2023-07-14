using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDatos
{
    public class ClassGeneroRopa
    {
        public static List<GENERO_ROPA> ListadoGenero = new List<GENERO_ROPA>()
        {
            new GENERO_ROPA(){ NUMERO_GENERO = 1, GENERO_PRENDA = "Masculino"},
            new GENERO_ROPA(){ NUMERO_GENERO = 2, GENERO_PRENDA = "Femenino"},
            new GENERO_ROPA(){ NUMERO_GENERO = 3, GENERO_PRENDA = "Unisex"}
        };
    }
}
