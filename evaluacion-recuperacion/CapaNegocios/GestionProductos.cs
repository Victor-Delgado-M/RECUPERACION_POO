using System;
using System.Collections.Generic;
using CapaDatos.ClasesCRUD;
using CapaDatos.Modelos;

namespace CapaNegocios
{
    public class GestionProductos
    {
        public GestionProductos()
        {
            PersistenciaProductos.ListaProductos = new List<Producto>();
            PersistenciaProductos.CrearProductos();
        }

        public void GuardarProducto(int identificador, string descripcion, decimal precio, int existencia, string categoria)
        {
            PersistenciaProductos.GuardarProducto(new Producto(identificador, descripcion, precio, existencia, categoria));
        }

        public string ListarProductos()
        {
            return "IDENTIFICADOR\t\t\tDESCRIPCION\t\t\tCATEGORIA\n" + PersistenciaProductos.RetornarProductosEnString();
        }
    }
}
