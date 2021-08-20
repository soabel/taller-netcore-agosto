using System;
namespace Taller.Facturacion.Productos.Domain
{
    public class Calculadora
    {
        public int sumar(int a, int b) {
            return a + b;
        }

        public bool esPar(int a) {
            return a % 2 == 0;
        }

        public int dividir(int a, int b) {

            if(a ==0)
                throw new CustomAritmeticException("El dividendo es cero");

            if (b == 0)
                throw new CustomAritmeticException("Division por cero");

            return a / b;
        }
    }


    public class CustomAritmeticException : Exception {
        public CustomAritmeticException(string message): base(message) {
        }
    }

   

}
