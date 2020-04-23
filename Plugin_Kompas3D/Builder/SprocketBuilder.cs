using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using Parameter;

namespace Builder
{
    public class SprocketBuilder
    {
        private KompasObject _kompasObject;

        private SprocketParameters _sprocketParameters;

        public SprocketBuilder(SprocketParameters parameters, KompasObject kompas)
        {
            //Получение параметров звездочки
            _sprocketParameters = parameters;
            //Получение объекта KOMPAS 3D
            _kompasObject = kompas;
            //Создание звездочки
            CreateModel();
        }

        private void CreateModel()
        { 
        
        }


    }
}
