using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioEstanteria.CLASES
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

    

        public Producto(string cod, string marca, float precio)
        {
             this.codigoDeBarra = cod;
             this.marca = marca;
             this.precio = precio;
        }

        public string GetMarca()
        {
            return this.marca;
        }

        public string GetCodigo()
        {
            return this.codigoDeBarra;
        }

        public float GetPrecio()
        {
            return this.precio;
        }

        public static string MostrarProducto(Producto p)
        {
            return String.Format("MARCA {0} CODIGO {1} PRECIO {2} ", p.marca, (string)p, p.precio);
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }

        public static bool operator ==(Producto p1,Producto p2)
        {
            bool retorno = false;
            if(!(p1 is null || p2 is null)){
                if ((p1.marca == p2.marca) && (p1.codigoDeBarra == p2.codigoDeBarra)) {
                    retorno = true;
                }
            }
           
            return retorno;
        }
        public static bool operator!=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator==(Producto p1, string aux)
        {
            bool retorno = false;
            if (p1.marca == aux)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator!=(Producto p1, string aux)
        {
            return  !(p1.marca == aux);
        }







    }

    public class Estante
    {
        private Producto[] productos;
        private int index;
    

        private Estante(int cantidad)
        {
            productos=new Producto[cantidad];
        }

        public Estante(int cantidad, int ubicacion) : this(cantidad)
        {
            this.index = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return (this.productos);
        }

        public static string MostrarEstante(Estante e1)
        {
            int i;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estante Ubicacion: {e1.index}/n");

            for (i = 0; i < e1.productos.Length; i++)
            {
                if (!Object.ReferenceEquals(e1.productos[i], null))
                {
                    sb.AppendLine(Producto.MostrarProducto(e1.productos[i]));
                    sb.AppendLine("/n");
                     
                }
            }

            return sb.ToString();
        }

        // SOBRE CARGA DE OPERADODORES ---->

        public static bool operator == (Estante e1, Producto p1)
        {
            bool retorno = false;
            int i;

            for (i = 0; i < e1.productos.Length; i++)
            {
                if (e1.productos[i] == p1)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;

        }

        public static bool operator != (Estante e1, Producto p1)
        {
           return !(e1 == p1);
        }

        public static bool operator +(Estante e1, Producto p1)
        {
            bool retorno = false; 
            int i;

            for (i = 0; i < e1.productos.Length; i++)
            {
                if (e1.productos[i]!=p1 && e1.productos[i] is null)
                {
                    e1.productos[i] = p1;
                    retorno = true;
                    break;
                }
            }

            return retorno;

        }

        public static Estante operator -(Estante e1, Producto p1)
        {
            int i;
            for (i = 0; i<e1.productos.Length; i++)
            {
                if (e1.productos[i] == p1)
                {
                    e1.productos[i] = null;
                    break;

                }
            }
            return e1;
        }








        



    }



}
