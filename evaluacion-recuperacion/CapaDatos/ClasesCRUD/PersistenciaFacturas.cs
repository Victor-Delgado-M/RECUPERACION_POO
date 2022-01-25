using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos.Modelos;

namespace CapaDatos.ClasesCRUD
{
    public static class PersistenciaFacturas
    {
        public static List<Factura> ListaFacturas { get; set; }

        /// <summary>
        /// Método para crear productos aleatoreamente.
        /// </summary>
        public static void AgregarFacturas()
        {
            List<DetalleFactura> detalleFacturas = new List<DetalleFactura>();


            int numero;
            for (int i = 1; i <= 2; i++)
            {
                Random random = new Random();
                Producto producto = new Producto();
                producto.Identificador = i;
                numero = random.Next(20);
                char letra = (char)(((int)'A') + random.Next(26));
                producto.Descripcion = "PRODUCTO " + letra + numero + i;
                producto.Precio = numero;
                producto.Existencia = random.Next(100);

                CabeceraFactura cabeceraFactura = new CabeceraFactura();
                cabeceraFactura.NumeroFactura = $"00{i}-001";
                cabeceraFactura.ClienteCabecera = new Cliente { Apellidos = "APELLIDO" + numero + 1 + letra, Nombres = "NOMBRE" + numero + i, Cedula = $"{i}{i}{i}{i}{i}{i}", Edad = i, Email = "", Contrasena = "" };
                cabeceraFactura.EmpresaCabecera = new Empresa { Direccion = "Manta", RazonSocial = $"{i}{i}{i}{i}{i}{i}0001" };


                for (int j = 1; j <= 3; j++)
                {
                    Random detalleRamdom = new Random();

                    DetalleFactura detalleFactura = new DetalleFactura();
                    detalleFactura.ProductoCarrito = producto;
                    detalleFactura.Cantidad = detalleRamdom.Next(10) + 1;

                    detalleFacturas.Add(detalleFactura);
                }

                ListaFacturas.Add(new Factura { Cabecera = cabeceraFactura, Detalle = detalleFacturas });

                //Modificar el método para agregar categorías aleatoreas
            }
        }

        //CRUD
        //CREATE
        public static void GuardarFactura()
        {

        }

        //UPDATE
        public static void ModificarFactura()
        {

        }

        //DELETE
        public static void EliminarFactura()
        {

        }

        //READ
        //UN OBJETO
        public static void BuscarUnaFactura()
        {

        }

        //LISTADO DE OBJETOS FORMATEADOS SEGÚN REQUERIMIENTO
        public static string RetornarFacturasEnString()
        {
            return ListaFacturas.Aggregate("", (acumulador, factura) => acumulador += $"{factura.Cabecera.ClienteCabecera.Apellidos} \t {factura.Cabecera.ClienteCabecera.Nombres} \t {factura.Cabecera.EmpresaCabecera.RazonSocial} \n");
        }


        //1) Los datos de los clientes del listado de facturas ordenados alfabeticamente de A a Z. (2 Puntos)
        public static string ClientesOrdenados()
        {
            string resultado = "";
            var item = ListaFacturas.OrderBy(x => x.Cabecera.ClienteCabecera.Apellidos).ToList();
            item.ForEach(x => resultado += x.Cabecera.ClienteCabecera.Apellidos + " " + x.Cabecera.ClienteCabecera.Nombres + " " + x.Cabecera.ClienteCabecera.Edad  + " " + x.Cabecera.ClienteCabecera.Cedula + "\n");
            return resultado;
        }



        //2) Los datos de los productos agregados a una factura en particular localizada a través del número de factura. (2 Puntos)
        public static string DatosFactura(string numeroDeFactura)
        {
            string resultado = "";
            var item = (from x in ListaFacturas where x.Cabecera.NumeroFactura == numeroDeFactura select x.Detalle).ToList();
            item.ForEach(x => x.ForEach(a => resultado += a.ProductoCarrito.Identificador + "---" + a.ProductoCarrito.Descripcion + "---" + 
            a.ProductoCarrito.Categoria + "---" + a.ProductoCarrito.Precio + "\n"));
            return resultado;
        }



        //3) El total de los productos agregados al detalle de cada una de las facturas. (2 Puntos)
        public static string TotalProductos()
        {
            string resultado = "";
            var item = (from x in ListaFacturas select x.Detalle).ToList();
            item.ForEach(x => resultado += suma(x) + "\n");
            return resultado;
        }

        private static decimal suma(List<DetalleFactura> lista)
        {
            decimal suma = 0;
            lista.ForEach(x => suma += x.ProductoCarrito.Precio);
            return suma;
        }





        //4) El subtotal (precio por cantidad) de la primera factura ingresada en la lista de facturas. (2 Puntos)
        public static decimal SubTotal()
        {
            decimal suma = 0;
            var item = ListaFacturas.Find(x => x.Cabecera.NumeroFactura == "001-001");
            item.Detalle.ForEach(x => suma += x.ProductoCarrito.Precio * x.Cantidad);
            return suma;
        }



        //5) Una vez encontrado el subtotal, aumentarle el valor del IVA. (2 puntos)
        public static decimal Iva()
        {
            var sub = (SubTotal() * 12) / 100;
            var sape = SubTotal() + sub;
            return sape;
        }


    }
}
