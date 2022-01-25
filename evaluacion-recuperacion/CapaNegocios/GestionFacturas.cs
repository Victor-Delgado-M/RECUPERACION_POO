using System;
using System.Collections.Generic;
using CapaDatos.ClasesCRUD;
using CapaDatos.Modelos;

namespace CapaNegocios
{
    public class GestionFacturas
    {
        public GestionFacturas()
        {
            PersistenciaFacturas.ListaFacturas = new List<Factura>();
            PersistenciaFacturas.AgregarFacturas();
        }

        public string RetornarFacturas()
        {
            string res = PersistenciaFacturas.RetornarFacturasEnString();
            return res;
        }




        public string ClientesOrdenados()
        {
            string resultado = PersistenciaFacturas.ClientesOrdenados();
            return resultado;
        }


        public string DatosFactura(string Factura)
        {
            string resultado = PersistenciaFacturas.DatosFactura(Factura);
            return resultado;
        }


        public string TotalProductos()
        {
            string resultado = PersistenciaFacturas.TotalProductos();
            return resultado;
        }



        public string SubTotal()
        {
            string resultado = PersistenciaFacturas.SubTotal().ToString();
            return resultado;
        }


        public string Iva()
        {
            string resultado = PersistenciaFacturas.Iva().ToString();
            return resultado;
        }


    }
}
