﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ModelParameter;

namespace PluginTest.UnitTest
{
    [TestFixture]
    class SprocketParameterTest
    {
        private SprocketParameters sprocketParameter;

        [SetUp]
        public void SetParameter()
        {
            sprocketParameter = new SprocketParameters();
        }

        [Test(Description = "Позитивный тест метода Parameter")]
        public void TestParameter()
        {
            var result = true;
            var message = "";
            if (sprocketParameter.Parameter(NameParameter.CircleRadius).MinValue != 60)
            {
                result = false;
                message = "Ошибка. Не верное создание минимального значения радиуса внешней окружности";
            }
            if (sprocketParameter.Parameter(NameParameter.CircleRadius).MaxValue != 300)
            {
                result = false;
                message = "Ошибка. Не верное создание максимального значения радиуса внешней окружности";
            }
            if (sprocketParameter.Parameter(NameParameter.CircleRadius).Value != 180)
            {
                result = false;
                message = "Ошибка. Не верное создание текущего значения радиуса внешней окружности";
            }
            Assert.IsTrue(result, message);
        }

    
        

        [Test(Description = "Позитивный тест метода перечисления ToString")]
        public void TestToString()
        {
            var expected = "CylinderRadius";
            var actual = NameParameter.CylinderRadius.ToString();
            Assert.AreEqual(expected, actual, "Метод перечисления ToString работает некорректно");
        }

        [Test(Description = "Позитивный тест конструктора SprocketParameters")]
        public void TestSprocketParameters()
        {
            var result = true;
            var values = new List<(NameParameter name, double min, double max)>
            {
                (NameParameter.CircleRadius, 60, 300),
                (NameParameter.CylinderRadius, 20, 150),
                (NameParameter.HoleRadius, 10, 75),
                (NameParameter.CircleThickness, 5, 20),
                (NameParameter.CylinderThickness, 0, 40),
                (NameParameter.ExcavationDepth, 0, 18),
                (NameParameter.NumberOfTeeth, 7, 30)
            };

            foreach (var value in values)
            {
                if (sprocketParameter.Parameter(value.name).MaxValue != value.max ||
                    sprocketParameter.Parameter(value.name).MinValue != value.min ||
                    sprocketParameter.Parameter(value.name).Value != (value.max + value.min)/2)
                {
                    result = false;
                }
            }
            Assert.IsTrue(result, "Конструктор SprocketParameters не создает корректный экземпляр класса");
        }

        [Test(Description = "Позитивный тест метода RecalculateParameter")]
        public void TestRecalculateParameter()
        {
            var CircleRadius = 300;
            var expected = CircleRadius / 2;
            var minValue = 20;
            sprocketParameter.Parameter(NameParameter.CylinderRadius).Value = expected;
            sprocketParameter.RecalculateParameter(sprocketParameter.Parameter(NameParameter.CylinderRadius).Value,expected,minValue);
            var actual = sprocketParameter.Parameter(NameParameter.CylinderRadius).Value;
            Assert.AreEqual(expected, actual, "Метод RecalculateCylinderRadius работает некорректно");
        }

    }
}
