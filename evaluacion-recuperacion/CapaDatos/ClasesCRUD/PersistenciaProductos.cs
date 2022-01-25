using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos.Modelos;

namespace CapaDatos.ClasesCRUD
{
    public static class PersistenciaProductos
    {

        public static List<Producto> ListaProductos { get; set; }

        /// <summary>
        /// Método para crear productos aleatoreamente.
        /// </summary>
        public static void CrearProductos()
        {
            Random random = new Random();
            int numero;
            for (int i = 1; i <= 10; i++)
            {

                Producto producto = new Producto();
                producto.Identificador = i;
                numero = random.Next(20);
                char letra = (char)(((int)'A') + random.Next(26));
                producto.Descripcion = "PRODUCTO" + letra + numero + i;
                producto.Precio = numero;

                Random existencia = new Random();
                producto.Existencia = existencia.Next(100);
                ListaProductos.Add(producto);

                //Modificar el método para agregar categorías aleatoreas
            }
        }

        //CRUD
        //CREATE
        public static void GuardarProducto(Producto producto)
        {
            ListaProductos.Add(producto);
        }

        //UPDATE
        public static void ModificarProducto(int identificador, string descripcion, string categoria)
        {
            Producto producto = ListaProductos.Find(x => x.Identificador == identificador);
            producto.Descripcion = descripcion;
            producto.Categoria = categoria;
        }

        //DELETE
        public static void EliminarProducto(int identificador)
        {
            ListaProductos.RemoveAll(producto => producto.Identificador == identificador);
        }

        //READ
        //UN OBJETO
        public static Producto BuscarProducto(int identificador)
        {

            return ListaProductos.Find(producto => producto.Identificador == identificador);
        }

        //LISTADO DE OBJETOS FORMATEADOS SEGÚN REQUERIMIENTO
        public static string RetornarProductosEnString()
        {
            return ListaProductos.Aggregate("", (acumulador, producto) => acumulador += $"{producto.Identificador} \t {producto.Descripcion} \t {producto.Categoria} \n");
        }

       

    }
}
