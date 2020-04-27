using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using ModelParameter;


namespace Builder
{
    /// <summary>
    /// Класс подключает экземпляры построителя модели к САПР Компас 3D и инициализирует их
    /// </summary>
    public class SprocketManager
    {
        /// <summary>
        /// Поле хранит экземпляр построителя 3D звездочки
        /// </summary>
        private SprocketBuilder _sprocketBuilder;

        KompasObject _kompasObject = null;

        /// <summary>
        /// Подключение к экземпляру КОМПАС-3D
        /// </summary>
        /// <returns></returns>
        private KompasObject OpenKompas3D()
        {

            try
            {
                _kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                _kompasObject.Visible = true;
            }
            catch
            {
                Type typeKompas = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(typeKompas);
                _kompasObject.Visible = true;
            }
            finally
            {
               _kompasObject.ActivateControllerAPI();
            }

            return _kompasObject;
        }

        /// <summary>
        /// Конструктор класса SprocketManager. Вызывает метод для инициализации экземпляра построителя 3D звездочки
        /// <param name="parameters"></param>
        public SprocketManager(SprocketParameters parameters)
        {
            InitializeSprocket(parameters);
        }

        /// <summary>
        /// Метод создает экземпляр класса построителя модели
        /// </summary>
        /// <param name="parameters"></param>
        private void InitializeSprocket(SprocketParameters parameters)
        {
            _sprocketBuilder = new SprocketBuilder(parameters, OpenKompas3D());
        }
    }
}
