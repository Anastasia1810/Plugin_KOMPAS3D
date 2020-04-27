using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParameter;
using NUnit.Framework;

namespace PluginTest.UnitTest
{
    [TestFixture]
    public class ParameterTest
    {
        private Parameter parameter;

        [SetUp]
        public void SetParameter()
        {
            parameter = new Parameter("Название параметра", 10, 30, 15);
        }
        [Test(Description = "Позитивный тест геттера MinValue")]
        public void TestMinValueGet_CorrectValue()
        {
            var expected = 25;
            parameter.MinValue = expected;
            var actual = parameter.MinValue;

            Assert.AreEqual(expected, actual, "Геттер Minvalue возвращает неправильное название");
        }

        [Test(Description = "Позитивный тест сеттера MinValue")]
        public void TestMinValueSet_CorrectValue()
        {
            var expected = 10;
            parameter.MinValue = expected;
            var actual = parameter.MinValue;

            Assert.AreEqual(expected, actual, "Сеттер Minvalue возвращает неправильное название");
        }

        [Test(Description = "Позитивный тест геттера MaxValue")]
        public void TestMaxValueGet_CorrectValue()
        {
            var expected = 30;
            parameter.MaxValue = expected;
            var actual = parameter.MaxValue;

            Assert.AreEqual(expected, actual, "Геттер Maxvalue возвращает неправильное название");
        }

        [Test(Description = "Позитивный тест сеттера MaxValue")]
        public void TestMaxValueSet_CorrectValue()
        {
            var expected = 25;
            parameter.MaxValue = expected;
            var actual = parameter.MaxValue;

            Assert.AreEqual(expected, actual, "Сеттер Maxvalue возвращает неправильное название");
        }

        [Test(Description = "Позитивный тест геттера Value")]
        public void TestValueGet_CorrectValue()
        {
            var expected = 20;
            parameter.Value = expected;

            Assert.AreEqual(expected, parameter.Value, "Геттер Value возвращает неправильное название");
        }
        
        [Test(Description = "Позитивный тест сеттера Value")]
        public void TestValueSet_CorrectValue()
        {
            var expected = 20;
            parameter.Value = expected;

            Assert.AreEqual(expected, parameter.Value, "Сеттер Value возвращает неправильное название");
        }
        
        [Test(Description = " Позитивный тест конструктора Parameter")]
        public void TestParameterConstructor()
        {
            string messege = "";
            var result = true;
            
            if (parameter.MinValue != 10)
            {
                result = false;
                messege = "Значение не соответсвует" + "MinValue";
            }

            if (parameter.MaxValue != 30)
            {
                result = false;
                messege = "Значение не соответсвует" + "MaxValue";
            }
            
            if (parameter.Value != 15)
            {
                result = false;
                messege = "Значение не соотвествует" + "Value ";
            }
            Assert.IsTrue(result, messege);
        }

        [TestCase("-20", "Должно возникать исключение, если значение отрицательное",
          TestName = "Присвоение Value отрицательного значения")]
        [TestCase("50",
          "Должно возникать исключение, если Value больше максимального значения",
          TestName = "Присвоение Value значение больше максимального")]
        public void TestValueSet_ArgumentExeption(string wrongValue, string message)
        {
            Assert.Throws<ArgumentException>(
            () => { parameter.Value = double.Parse(wrongValue); },
            message);
        }
    }
}
