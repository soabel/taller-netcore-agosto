using System;
using Taller.Facturacion.Productos.Domain;
using Xunit;

namespace Taller.Facturacion.Productos.UnitTest.Domain
{
    public class CalculadoraTest
    {

        [Fact]
        public void Sumar_ok() {
            //AAA: Arrange, Act, Assert

            //A: Arrange
            var calc = new Calculadora();
            int a = 5;
            int b = 4;

            var expected = 9;

            //A: Act
            var actual = calc.sumar(a, b);

            //A: Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Sumar_NoOk() {
            //A: Arrange
            var calc = new Calculadora();
            int a = 5;
            int b = 4;

            var expected = 7;

            //A: Act
            var actual = calc.sumar(a, b);

            //A: Assert
            Assert.NotEqual(expected, actual);

        }


        //[Fact]
        //public void EsPar_False()
        //{
        //    //AAA: Arrange, Act, Assert

        //    //A: Arrange
        //    var calc = new Calculadora();
        //    int a = 5;

        //    var expected = false;

        //    //A: Act
        //    var actual = calc.esPar(a);

        //    //A: Assert
        //    Assert.Equal(expected, actual);

        //}

        //[Fact]
        //public void EsPar_Ok()
        //{
        //    //AAA: Arrange, Act, Assert

        //    //A: Arrange
        //    var calc = new Calculadora();
        //    int a = 4;

        //    var expected = true;

        //    //A: Act
        //    var actual = calc.esPar(a);

        //    //A: Assert
        //    Assert.Equal(expected, actual);

        //}


        [Theory]
        [InlineData(4,true)]
        [InlineData(5,false)]
        public void EsPar_Multiple(int numero, bool expected)
        {
            //AAA: Arrange, Act, Assert

            //A: Arrange
            var calc = new Calculadora();
          
            //A: Act
            var actual = calc.esPar(numero);

            //A: Assert
            Assert.Equal(expected, actual);

        }


        [Fact]
        public void Dividir_Ok()
        {
            //A: Arrange
            var calc = new Calculadora();
            int a = 10;
            int b = 2;

            var expected = 5;

            //A: Act
            var actual = calc.dividir(a, b);

            //A: Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Dividir_Cero()
        {
            //A: Arrange
            var calc = new Calculadora();
            int a = 10;
            int b = 0;
         
            //Assert.Throws<DivideByZeroException>(() => calc.Dividir(dividendo, divisor));


            //A: Act , A: Assert
            Assert.Throws<CustomAritmeticException>(() => calc.dividir(a, b));

        }


    }
}
