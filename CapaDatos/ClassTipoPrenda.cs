using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDatos
{
    public class ClassTipoPrenda
    {
        public static List<CLASIFICAR_ROPA> ListadoPrendas = new List<CLASIFICAR_ROPA>()
        {
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 1, CATEGORIA_PRENDA = "Camisa"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 2, CATEGORIA_PRENDA = "Pantalon"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 3, CATEGORIA_PRENDA = "Zapatos"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 4, CATEGORIA_PRENDA = "Corbatas"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 5, CATEGORIA_PRENDA = "Medias"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 6, CATEGORIA_PRENDA = "Camisetas"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 7, CATEGORIA_PRENDA = "Ropa interior masculina"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 8, CATEGORIA_PRENDA = "Ropa interior femenina"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 9, CATEGORIA_PRENDA = "Sweater"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 10, CATEGORIA_PRENDA = "Enaguas"},
            new CLASIFICAR_ROPA(){ CATEGORIA_NUMERO = 11, CATEGORIA_PRENDA = "Medias"}
        };
    }
}
