using System;
using System.Collections.Generic;

namespace CapaDatos.Modelos
{
    public class Factura
    {
        //Cabecera de Factura
        public CabeceraFactura Cabecera { get; set; }
        //Detalle de carrito
        //Lista de detalle de carrito (Producto y la cantidad)
        public List<DetalleFactura> Detalle { get; set; }

        public Factura()
        {
            this.Detalle = new List<DetalleFactura>();
        }
    }
}
